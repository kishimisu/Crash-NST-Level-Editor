using System.Numerics;

namespace Havok
{
    public record HkxSection(List<HkxPrimitive> Primitives);

    public record HkxPrimitive(Vector3 A, Vector3 B, Vector3 C, Vector3 D, int Material)
    {
        public Box3 Bounds = new Box3().SetFromPoints([A, B, C, D]);
    }
    
    public static class HavokCollisionsBuilder
    {
        /// <summary>
        /// Rebuild the BVH for an hknpStaticCompoundShape
        /// </summary>
        public static hknpStaticCompoundShape RebuildStaticCompoundShape(hknpStaticCompoundShape compoundShape)
        {
            if (compoundShape._boundingVolumeData == null) 
                return compoundShape;

            compoundShape._boundingVolumeData._nodes.Clear();

            if (compoundShape._elements.Count == 0) 
                return compoundShape;

            BVHNode root = BVHBuilder.Build(compoundShape._elements);

            List<hkcdStaticTreeCodec3Axis6> axis6Tree = root.BuildAxisTree<hkcdStaticTreeCodec3Axis6>();

            for (int i = 0; i < axis6Tree.Count; i++)
            {
                var node = axis6Tree[i];

                if ((node._hiData & 0x80) != 0) continue;

                int instanceIndex = node._loData | ((node._hiData & 0x7F) << 16);

                hknpShapeInstance shape = compoundShape._elements[instanceIndex];

                uint type = 0x3f000060;

                if (shape._transform.M41 != 0 || shape._transform.M42 != 0 || shape._transform.M43 != 0)
                {
                    type |= 0x2;
                }
                if (shape._transform.M11 != 1 || shape._transform.M12 != 0 || shape._transform.M13 != 0 ||
                    shape._transform.M21 != 0 || shape._transform.M22 != 1 || shape._transform.M23 != 0 ||
                    shape._transform.M31 != 0 || shape._transform.M32 != 0 || shape._transform.M33 != 1)
                {
                    type |= 0x4;
                }
                if (shape._scale.X != 1 || shape._scale.Y != 1 || shape._scale.Z != 1)
                {
                    type |= 0x8;
                }

                byte[] typeBytes = BitConverter.GetBytes(type);
                float typeFloat = BitConverter.ToSingle(typeBytes, 0);

                uint indexHex = 0x3f000000 | (uint)i;
                byte[] indexBytes = BitConverter.GetBytes(indexHex);
                float indexFloat = BitConverter.ToSingle(indexBytes, 0);

                shape._transform.M14 = typeFloat;
                shape._transform.M24 = shape._transform.M31;
                shape._transform.M44 = indexFloat;
            }

            compoundShape._boundingVolumeData._nodes.Clear();
            compoundShape._boundingVolumeData._nodes.AddRange(axis6Tree);
            compoundShape._boundingVolumeData._min = new Vector4(root.boundsMin.X, root.boundsMin.Y, root.boundsMin.Z, compoundShape._boundingVolumeData._min.W);
            compoundShape._boundingVolumeData._max = new Vector4(root.boundsMax.X, root.boundsMax.Y, root.boundsMax.Z, compoundShape._boundingVolumeData._max.W);

            compoundShape._min = new Vector4(root.boundsMin.X, root.boundsMin.Y, root.boundsMin.Z, compoundShape._min.W);
            compoundShape._max = new Vector4(root.boundsMax.X, root.boundsMax.Y, root.boundsMax.Z, compoundShape._max.W);
            compoundShape._numShapeKeyBits = (byte)Math.Max(1, 32 - BitOperations.LeadingZeroCount((uint)compoundShape._elements.Count-1));

            return compoundShape;
        }

        /// <summary>
        /// Remove faces from an hknpCompressedMeshShape and rebuild its sections and BVH
        /// </summary>
        public static hknpCompressedMeshShape RebuildCompressedMeshShape(hknpCompressedMeshShapeTree tree, HashSet<int> removedPrimitives)
        {
            // Unpack shared vertices

            var sharedVertices = new List<Vector3>();
            
            foreach (var v in tree._sharedVertices)
            {
                var (ux, uy, uz) = UnpackXYZ(v, 21, 21, 22);
                var fv = new Vector3(ux / 2097151f, uy / 2097151f, uz / 4194303f);
                
                float x = tree._min.X + (tree._max.X - tree._min.X) * fv.X;
                float y = tree._min.Y + (tree._max.Y - tree._min.Y) * fv.Y;
                float z = tree._min.Z + (tree._max.Z - tree._min.Z) * fv.Z;

                sharedVertices.Add(new Vector3(x, y, z));
            }

            // Build primitives

            var primitives = new List<HkxPrimitive>();
            int primitiveStart = 0;
            int sharedIndexStart = 0;

            foreach (var section in tree._sections)
            {
                int firstVertex = (int)section._firstPackedVertex;
                int primitiveCount = (int)(section._primitives & 0xFF);
                int dataRunStart = (int)(section._dataRuns >> 8);
                int numPackedVertices = section._numPackedVertices;
                int numSharedIndices = section._numSharedIndices;

                var GetVertex = (int index) =>
                {
                    // Shared vertex
                    if (index >= numPackedVertices)
                    {
                        int localSharedIndex = index - numPackedVertices;
                        int sharedVertexIndex = tree._sharedVerticesIndex[sharedIndexStart + localSharedIndex];

                        return sharedVertices[sharedVertexIndex];
                    }
                    // Packed vertex
                    else
                    {
                        var (ux, uy, uz) = UnpackXYZ(tree._packedVertices[firstVertex + index], 11, 11, 10);

                        float x = section._codecParms_0 + section._codecParms_3 * ux;
                        float y = section._codecParms_1 + section._codecParms_4 * uy;
                        float z = section._codecParms_2 + section._codecParms_5 * uz;

                        return new Vector3(x, y, z);
                    }
                };

                // Add primitives

                int dataRun = dataRunStart;
                int dataRunPrimitive = 0;

                for (int i = 0; i < primitiveCount; i++)
                {
                    int material = tree._primitiveDataRuns[dataRun]._value?._data ?? 0;

                    if (++dataRunPrimitive >= tree._primitiveDataRuns[dataRun]._count)
                    {
                        dataRunPrimitive = 0;
                        dataRun++;
                    }

                    if (removedPrimitives.Contains(primitiveStart + i))
                        continue;
                    
                    var primitive = tree._primitives[primitiveStart + i];

                    var a = GetVertex(primitive._indices_0);
                    var b = GetVertex(primitive._indices_1);
                    var c = GetVertex(primitive._indices_2);
                    var d = GetVertex(primitive._indices_3);

                    primitives.Add(new HkxPrimitive(a, b, c, d, material));
                }

                primitiveStart += primitiveCount;
                sharedIndexStart += numSharedIndices;
            }

            return RebuildCompressedMeshShape(primitives);
        }

        /// <summary>
        /// Build an hknpCompressedMeshShape given a list of quad primitives
        /// </summary>
        private static hknpCompressedMeshShape RebuildCompressedMeshShape(List<HkxPrimitive> primitives)
        {
            hknpCompressedMeshShape outShape = CreateEmptyCompressedMeshShape();
            hknpCompressedMeshShapeTree tree = outShape._data!._meshTree!;

            if (primitives.Count == 0)
                return outShape;

            // Split primitives into sections

            List<Vector3> vertices = ProcessVertices(ref primitives);

            List<HkxSection> sections = HavokSectionBuilder.BuildSections(primitives);

            // Find shared vertices

            var packedVertices = new List<Vector3>();
            var sharedVertices = new List<Vector3>();
            var sharedVerticesIndex = new List<ushort>();

            foreach (var v in vertices)
            {
                int referenceCount = 0;

                foreach (var s in sections)
                {
                    if (s.Primitives.Any(f => f.A == v || f.B == v || f.C == v || f.D == v))
                    {
                        referenceCount++;

                        if (referenceCount > 1)
                        {
                            sharedVertices.Add(v);
                            break;
                        }
                    }
                }
            }

            // Build havok sections

            var baseSections = new List<hkcdStaticMeshTreeBaseSection>();
            var basePrimitives = new List<hkcdStaticMeshTreeBasePrimitive>();
            var baseDataRuns = new List<hknpCompressedMeshShapeTreeDataRun>();

            var globalBounds = Box3.Infinity;

            uint firstPackedVertex = 0;
            uint numSharedIndicesCumul = 0;
            uint numPrimitivesCumul = 0;

            int triangleCount = 0;
            bool lastPrimitiveIsQuad = true;

            foreach (var s in sections)
            {
                var packedVerticesCache = new HashSet<Vector3>();
                var sharedVerticesCache = new HashSet<Vector3>();

                var packedBounds = Box3.Infinity;
                var sharedBounds = Box3.Infinity;

                byte numPackedVertices = 0;
                byte numSharedIndices = 0;

                // Count number of packed and shared vertices

                var AddVertex = (Vector3 v) =>
                {
                    sharedBounds.Encapsulate(v);

                    if (!sharedVertices.Contains(v))
                    {
                        packedBounds.Encapsulate(v);

                        if (packedVerticesCache.Add(v))
                        {
                            packedVertices.Add(v);
                            numPackedVertices++;
                        }
                    }
                    else if (sharedVerticesCache.Add(v))
                    {
                        numSharedIndices++;
                    }
                };

                foreach (var f in s.Primitives)
                {
                    AddVertex(f.A);
                    AddVertex(f.B);
                    AddVertex(f.C);
                    AddVertex(f.D);

                    lastPrimitiveIsQuad = f.A != f.B && f.A != f.C && f.A != f.D && f.B != f.C && f.B != f.D && f.C != f.D;
                    triangleCount += lastPrimitiveIsQuad ? 2 : 1;
                }

                var inset = Vector4.One * 0.01f;

                globalBounds.Encapsulate(sharedBounds.Min - inset.AsVector3());
                globalBounds.Encapsulate(sharedBounds.Max + inset.AsVector3());

                // Create havok section

                var baseSection = new hkcdStaticMeshTreeBaseSection()
                {
                    _min = new Vector4(sharedBounds.Min, 0) - inset,
                    _max = new Vector4(sharedBounds.Max, 0) + inset,
                    _codecParms_0 = packedBounds.Min.X,
                    _codecParms_1 = packedBounds.Min.Y,
                    _codecParms_2 = packedBounds.Min.Z,
                    _codecParms_3 = MathF.Abs(packedBounds.Max.X - packedBounds.Min.X) / 2047f,
                    _codecParms_4 = MathF.Abs(packedBounds.Max.Y - packedBounds.Min.Y) / 2047f,
                    _codecParms_5 = MathF.Abs(packedBounds.Max.Z - packedBounds.Min.Z) / 1023f,
                    _firstPackedVertex = firstPackedVertex,
                    _sharedVertices = (numSharedIndicesCumul << 8) | numPackedVertices,
                    _primitives = (numPrimitivesCumul << 8) | (uint)s.Primitives.Count,
                    _numPackedVertices = numPackedVertices,
                    _numSharedIndices = numSharedIndices,
                    _nodes = new hkMemory<hkcdStaticTreeCodec3Axis4>(),
                };

                baseSections.Add(baseSection);

                // Build primitives

                var localSharedVertices = new List<int>();

                var GetIndex = (Vector3 v) =>
                {
                    int sharedIndex = sharedVertices.IndexOf(v);

                    if (sharedIndex != -1)
                    {
                        if (!localSharedVertices.Contains(sharedIndex))
                            localSharedVertices.Add(sharedIndex);

                        int localIndex = localSharedVertices.IndexOf(sharedIndex);

                        return numPackedVertices + localIndex;
                    }
                    else
                    {
                        return packedVerticesCache.ToList().IndexOf(v);
                    }
                };

                var dataRunMaterials = new List<int>();
                var dataRunCounts = new List<int>();

                foreach (var f in s.Primitives)
                {
                    basePrimitives.Add(new hkcdStaticMeshTreeBasePrimitive()
                    {
                        _indices_0 = (byte)GetIndex(f.A),
                        _indices_1 = (byte)GetIndex(f.B),
                        _indices_2 = (byte)GetIndex(f.C),
                        _indices_3 = (byte)GetIndex(f.D),
                    });

                    if (dataRunMaterials.Count == 0 || dataRunMaterials[dataRunMaterials.Count - 1] != f.Material)
                    {
                        dataRunMaterials.Add(f.Material);
                        dataRunCounts.Add(1);
                    }
                    else
                    {
                        dataRunCounts[dataRunCounts.Count - 1]++;
                    }
                }

                foreach (int v in localSharedVertices)
                {
                    sharedVerticesIndex.Add((ushort)v);
                }

                // Build data runs
                
                baseSection._dataRuns = (uint)((baseDataRuns.Count << 8) | dataRunMaterials.Count);
                int dataRunCumul = 0;
                for (int i = 0; i < dataRunMaterials.Count; i++)
                {
                    baseDataRuns.Add(new hknpCompressedMeshShapeTreeDataRun()
                    {
                        _index = (byte)dataRunCumul,
                        _count = (byte)dataRunCounts[i],
                        _value = new hknpCompressedMeshShapeTreeDataRunData()
                        {
                            _data = (ushort)dataRunMaterials[i]
                        }
                    });

                    dataRunCumul += dataRunCounts[i];
                }

                // Build BVH nodes

                var axis4Tree = BVHBuilder.Build(s.Primitives).BuildAxisTree<hkcdStaticTreeCodec3Axis4>();

                baseSection._nodes.Set(axis4Tree);

                numSharedIndicesCumul += numSharedIndices;
                numPrimitivesCumul += (uint)s.Primitives.Count;
                firstPackedVertex += numPackedVertices;
            }

            // Compress packed vertices

            foreach (var s in baseSections)
            {
                for (int i = (int)s._firstPackedVertex; i < s._firstPackedVertex + s._numPackedVertices; i++)
                {
                    uint x = (uint)((packedVertices[i].X - s._codecParms_0) / s._codecParms_3);
                    uint y = (uint)((packedVertices[i].Y - s._codecParms_1) / s._codecParms_4);
                    uint z = (uint)((packedVertices[i].Z - s._codecParms_2) / s._codecParms_5);

                    uint p = (uint)PackXYZ(x, y, z, 11, 11, 10);
                    
                    tree._packedVertices.Add(p);
                }
            }

            // Compress shared vertices

            foreach (var v in sharedVertices)
            {
                float x = (v.X - globalBounds.Min.X) / (globalBounds.Max.X - globalBounds.Min.X);
                float y = (v.Y - globalBounds.Min.Y) / (globalBounds.Max.Y - globalBounds.Min.Y);
                float z = (v.Z - globalBounds.Min.Z) / (globalBounds.Max.Z - globalBounds.Min.Z);

                uint ux = (uint)(x * 2097151);
                uint uy = (uint)(y * 2097151);
                uint uz = (uint)(z * 4194303);

                ulong p = PackXYZ(ux, uy, uz, 21, 21, 22);

                tree._sharedVertices.Add(p);
            }

            // Rebuild sections BVH

            var axis5Tree = BVHBuilder.Build(baseSections).BuildAxisTree<hkcdStaticTreeCodec3Axis5>();

            for (int i = 0; i < baseSections.Count; i++)
            {
                baseSections[i]._leafIndex = (ushort)axis5Tree.FindIndex(e => e._hiData == 0 && e._loData == i);
            }

            tree._nodes.Set(axis5Tree);
            tree._sections.Set(baseSections);
            tree._primitives.Set(basePrimitives);
            tree._primitiveDataRuns.Set(baseDataRuns);
            tree._sharedVerticesIndex.Set(sharedVerticesIndex);

            // Compute tree properties

            var lastSection = tree._sections[tree._sections.Count - 1];

            tree._numPrimitiveKeys = triangleCount;

            tree._maxKeyValue = (uint)(
                  (tree._sections.Count - 1) * 256 
                + ((lastSection._primitives & 0xFF) - 1) * 2 
                + (lastPrimitiveIsQuad ? 1 : 0) 
            );
            
            int bitsPerKey = Math.Max(1, 32 - BitOperations.LeadingZeroCount(tree._maxKeyValue + 1));

            tree._bitsPerKey = bitsPerKey;
            outShape._numShapeKeyBits = (byte)bitsPerKey;

            tree._min = new Vector4(globalBounds.Min, -0.01f);
            tree._max = new Vector4(globalBounds.Max, 0.01f);

            return outShape;
        }

        private static hknpCompressedMeshShape CreateEmptyCompressedMeshShape()
        {
            float lf = BitConverter.UInt32BitsToSingle(0x7F7FFFEE);
            float hf = BitConverter.UInt32BitsToSingle(0xFF7FFFEE);

            return new hknpCompressedMeshShape()
            {
                _flags = 34210308,
                _convexRadius = 0.01f,
                _dispatchType = EEnum.SPHERE,
                _shapeTagCodecInfo = 4294967295,
                _data = new hknpCompressedMeshShapeData()
                {
                    _meshTree = new hknpCompressedMeshShapeTree()
                    {
                        _nodes = new hkMemory<hkcdStaticTreeCodec3Axis5>(),
                        _sections = new hkMemory<hkcdStaticMeshTreeBaseSection>(),
                        _primitives = new hkMemory<hkcdStaticMeshTreeBasePrimitive>(),
                        _primitiveDataRuns = new hkMemory<hknpCompressedMeshShapeTreeDataRun>(),
                        _packedVertices = new hkMemory<uint>(),
                        _sharedVertices = new hkMemory<ulong>(),
                        _sharedVerticesIndex = new hkMemory<ushort>(),
                    },
                    _simdTree = new hkcdSimdTree()
                    {
                        _nodes = new hkMemory<hkcdSimdTreeNode>()
                        {
                            new hkcdSimdTreeNode()
                            {
                                _lx = new Vector4(lf, lf, lf, lf),
                                _hx = new Vector4(hf, hf, hf, hf),
                                _ly = new Vector4(lf, lf, lf, lf),
                                _hy = new Vector4(hf, hf, hf, hf),
                                _lz = new Vector4(lf, lf, lf, lf),
                                _hz = new Vector4(hf, hf, hf, hf),
                            },
                            new hkcdSimdTreeNode()
                            {
                                _lx = new Vector4(lf, lf, lf, lf),
                                _hx = new Vector4(hf, hf, hf, hf),
                                _ly = new Vector4(lf, lf, lf, lf),
                                _hy = new Vector4(hf, hf, hf, hf),
                                _lz = new Vector4(lf, lf, lf, lf),
                                _hz = new Vector4(hf, hf, hf, hf),
                            }
                        }
                    }
                },
                _edgeWeldingMap = new hknpSparseCompactMapunsignedshort()
                {
                    _secondaryKeyMask = 4294967295,
                    _primaryKeyToIndex = new hkMemory<ushort>(),
                    _valueAndSecondaryKeys = new hkMemory<ushort>(),
                },
                _quadIsFlat = new hkBitField()
                {
                    _words = new hkMemory<uint>()
                },
                _triangleIsInterior = new hkBitField()
                {
                    _words = new hkMemory<uint>()
                }
            };
        }

        private static List<Vector3> ProcessVertices(ref List<HkxPrimitive> primitives, float mergeThreshold = 0.001f)
        {
            var vertices = new List<Vector3>();

            var AddUniqueVertex = (Vector3 v) =>
            {
                int id = vertices.FindIndex(e => Vector3.Distance(e, v) < mergeThreshold);
                if (id != -1) return vertices[id];

                vertices.Add(v);
                return v;
            };

            primitives = primitives
                .Select(p => new HkxPrimitive(
                    AddUniqueVertex(p.A), 
                    AddUniqueVertex(p.B), 
                    AddUniqueVertex(p.C), 
                    AddUniqueVertex(p.D), 
                    p.Material
                ))
                .ToList();

            return vertices;
        }

        public static (uint x, uint y, uint z) UnpackXYZ(ulong packed, int xBits, int yBits, int zBits)
        {
            uint xMask = (1u << xBits) - 1;
            uint yMask = (1u << yBits) - 1;
            uint zMask = (1u << zBits) - 1;

            uint x = (uint)(packed & xMask);
            uint y = (uint)((packed >> xBits) & yMask);
            uint z = (uint)((packed >> (xBits + yBits)) & zMask);

            return (x, y, z);
        }

        public static ulong PackXYZ(uint x, uint y, uint z, int xBits, int yBits, int zBits)
        {
            ulong xMask = (1ul << xBits) - 1;
            ulong yMask = (1ul << yBits) - 1;
            ulong zMask = (1ul << zBits) - 1;

            ulong packed =
                (x & xMask) |
                ((y & yMask) << xBits) |
                ((z & zMask) << (xBits + yBits));

            return packed;
        }
    }
}