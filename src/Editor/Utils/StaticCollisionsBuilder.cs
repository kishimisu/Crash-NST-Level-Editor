using Alchemy;
using Havok;

namespace NST
{
    /// <summary>
    /// Handles extracting and rebuilding static collisions in .pak archives
    /// </summary>
    public static class StaticCollisionsUtils
    {
        public const float HAVOK_SCALE = 0.0254f;
        public const float HAVOK_SCALE_INV = 39.37f;

        /// <summary>
        /// Get static collision data from an IgArchive
        /// </summary>
        /// <returns>A pair of (object reference, hashtable index)</returns>
        public static Dictionary<HashedReference, int> GetCollisionData(IgArchive archive)
        {
            IgArchiveFile? collisionFile = archive.FindCollisionFile();

            if (collisionFile == null) {
                return [];
            }

            IgzFile collisionIgz = collisionFile.ToIgzFile();

            var table = collisionIgz.FindObject<CStaticCollisionHashInstanceIdHashTable>()!;

            return GetCollisionData(table);
        }

        /// <summary>
        /// Get static collision data from an archive's CStaticCollision hash table
        /// </summary>
        /// <returns>A pair of (object reference, hashtable index)</returns>
        private static Dictionary<HashedReference, int> GetCollisionData(CStaticCollisionHashInstanceIdHashTable table)
        {
            Dictionary<HashedReference, int> collisionData = [];

            foreach ((u64 key, i16 id) in table.Dict)
            {
                u32 namespaceHash  = (u32)(key >> 32);
                u32 objectNameHash = (u32)(key & 0xFFFFFFFF);

                var reference = new HashedReference(namespaceHash, objectNameHash);

                collisionData.Add(reference, id);
            }

            return collisionData;
        }

        public static hknpShapeInstance? FindPrefabCollision(igEntity parentPrefab, igEntity child, hknpStaticCompoundShape compoundShape)
        {
            var transform = parentPrefab.GetTransformMatrix() * child.GetTransformMatrix();

            var position = new THREE.Vector3();
            transform.Decompose(position, new(), new());

            foreach (var shape in compoundShape._elements)
            {
                var havokPosition = new THREE.Vector3(shape._transform.M41, shape._transform.M42, shape._transform.M43);

                float distance = havokPosition.DistanceTo(position * HAVOK_SCALE);

                if (distance < 0.01f)
                {
                    return shape;
                }
            }

            return null;
        }

        /// <summary>
        /// Rebuild static collisions for an archive, more specifically
        /// the StaticCollision.igz and StaticCollision.hkx files.
        /// </summary>
        /// <param name="archive">The archive to rebuild</param>
        /// <param name="updatedCollisionData">The list of updated collisions</param>
        public static void RebuildCollisions(IgArchive archive, List<CollisionUpdateInfos> updatedCollisionData)
        {
            IgArchiveFile? collisionIgzFile = archive.FindCollisionFile(".igz");
            IgArchiveFile? collisionHkxFile = archive.FindCollisionFile(".hkx");

            if (collisionIgzFile == null) {
                Console.WriteLine("Could not rebuild collisions: Collision file not found.");
                return;
            }
            if (collisionHkxFile == null) {
                Console.WriteLine("Could not rebuild collisions: Havok file not found.");
                return;
            }

            IgzFile collisionIgz = collisionIgzFile.ToIgzFile();
            var table = collisionIgz.FindObject<CStaticCollisionHashInstanceIdHashTable>()!;

            HavokFile collisionHkx = collisionHkxFile.ToHavokFile();
            var compoundShape = (hknpStaticCompoundShape)collisionHkx.GetRootObjects().First(x => x is hknpStaticCompoundShape);

            Dictionary<hknpShapeInstance, u64> shapes = [];
            Dictionary<int, hknpShapeInstance> shapesById = [];
            HashSet<HashedReference> existing = [];
            bool rebuildHashMap = false;

            foreach ((u64 key, i16 id) in table.Dict)
            {
                hknpShapeInstance shape = compoundShape._elements[id];
                shapes.Add(shape, key);
                shapesById.Add(id, shape);
                existing.Add(new HashedReference((u32)(key >> 32), (u32)(key & 0xFFFFFFFF)));
            }

            foreach (CollisionUpdateInfos updateInfos in updatedCollisionData)
            {
                HashedReference reference = updateInfos.GetReference();

                if (updateInfos.entity.Object.TryGetComponent(out CLevelBorderComponentData? levelBorder) && !string.IsNullOrEmpty(levelBorder._borderPath))
                {
                    // Update border collision

                    var file = archive.FindFile(NamespaceUtils.GetFileName(levelBorder._borderPath));

                    Console.WriteLine("Updating border collision for " + updateInfos.entity.Object.ObjectName);

                    if (file == null)
                    {
                        Console.WriteLine($"Warning: File not found ({levelBorder._borderPath})");
                        continue;
                    }

                    var hkx = file.ToHavokFile();

                    if (hkx.GetAllObjects().Find(e => e is hknpCompressedMeshShape) is not hknpCompressedMeshShape shape)
                    {
                        Console.WriteLine($"Warning: No hknpCompressedMeshShape found ({levelBorder._borderPath})");
                        continue;
                    }

                    UpdateCollisions(shape, updateInfos.removedFaces);

                    file.SetData(hkx.Save());
                }
                else if (updateInfos.removed)
                {
                    if (updateInfos.entity.CollisionShapeIndex == -1 || !existing.Contains(reference))
                    {
                        continue;
                    }

                    // Remove existing shape

                    hknpShapeInstance shape = shapesById[updateInfos.entity.CollisionShapeIndex];

                    compoundShape._elements.Remove(shape);

                    existing.Remove(reference);
                    shapes.Remove(shape);
                    rebuildHashMap = true;

                    Console.WriteLine("Removed collision for " + updateInfos.entity.Object.ObjectName);
                }
                else if (updateInfos.shapeInstance != null)
                {
                    // Add new shape

                    hknpShapeInstance shape = AddHavokShape(updateInfos, compoundShape, updateInfos.shapeInstance);

                    if (shape._shape is hknpCompressedMeshShape meshShape && meshShape._data?._meshTree != null)
                    {
                        foreach (var dataRun in meshShape._data._meshTree._primitiveDataRuns)
                        {
                            if (dataRun?._value?._data > 32) // Remove missing CollisionMaterial IDs when importing from CTR
                            {
                                dataRun._value._data = 0;
                            }
                        }
                    }

                    UpdateCollisions(shape, updateInfos.removedFaces);

                    u64 key = ((u64)reference.fileHash << 32) | reference.objectHash;

                    shapes.Add(shape, key);
                    rebuildHashMap = true;

                    Console.WriteLine($"Added new collision shape for {updateInfos.entity.Object.ObjectName}{(updateInfos.entity.ParentPrefabInstance != null ? $", prefab hash: {updateInfos.entity.CollisionPrefabHash}" : "")}, key: {key}");
                }
                else if (!existing.Contains(reference))
                {
                    // Add new instance of existing shape

                    hknpShapeInstance original = shapesById[updateInfos.entity.CollisionShapeIndex];
                    hknpShapeInstance shape = AddHavokShape(updateInfos, compoundShape, original);

                    UpdateCollisions(shape, updateInfos.removedFaces);

                    u64 key = ((u64)reference.fileHash << 32) | reference.objectHash;

                    shapes.Add(shape, key);
                    rebuildHashMap = true;

                    Console.WriteLine("Added collision shape instance for " + updateInfos.entity.Object.ObjectName);
                }
                else
                {
                    // Update existing shape

                    hknpShapeInstance toUpdate = shapesById[updateInfos.entity.CollisionShapeIndex];
                    
                    UpdateHavokShape(updateInfos.entity, toUpdate);

                    UpdateCollisions(toUpdate, updateInfos.removedFaces);

                    Console.WriteLine("Updated collision for " + updateInfos.entity.Object.ObjectName);
                }
            }

            // Rebuild BVH
            compoundShape = HavokCollisionsBuilder.RebuildStaticCompoundShape(compoundShape);

            collisionHkxFile.SetData(collisionHkx.Save());

            // Rebuild collision dictionary
            if (rebuildHashMap)
            {
                table.Dict.Clear();
                table.RebuildDict = true;

                foreach ((hknpShapeInstance shape, u64 key) in shapes)
                {
                    int index = compoundShape._elements.IndexOf(shape);
                    table.Dict.Add(key, (i16)index);
                }
                
                collisionIgzFile.SetData(collisionIgz.Save());
            }
        }

        /// <summary>
        /// Add a clone of a hknpShapeInstance to a static compound shape
        /// </summary>
        private static hknpShapeInstance AddHavokShape(CollisionUpdateInfos infos, hknpStaticCompoundShape compoundShape, hknpShapeInstance shapeInstance)
        {
            hknpShapeInstance cloneInstance = (hknpShapeInstance)shapeInstance.Clone();
            
            compoundShape._elements.Add(cloneInstance);

            UpdateHavokShape(infos.entity, cloneInstance);

            return cloneInstance;
        }

        /// <summary>
        /// Update a hknpShapeInstance's transform
        /// </summary>
        private static void UpdateHavokShape(NSTEntity entity, hknpShapeInstance shapeInstance)
        {
            THREE.Matrix4 transform = entity.ObjectToWorld();

            THREE.Vector3 position = new THREE.Vector3();
            THREE.Vector3 scale = new THREE.Vector3();
            THREE.Quaternion rotation = new THREE.Quaternion();
            
            transform.Decompose(position, rotation, scale);

            transform.Compose(position * HAVOK_SCALE, rotation, THREE.Vector3.One());
            
            System.Numerics.Matrix4x4 originalTransform = shapeInstance._transform;

            shapeInstance._transform = transform.ToMatrix4();
            shapeInstance._scale = new System.Numerics.Vector4(scale.X, scale.Y, scale.Z, 1);

            shapeInstance._transform.M14 = originalTransform.M14;
            shapeInstance._transform.M24 = originalTransform.M24;
            shapeInstance._transform.M34 = originalTransform.M34;
            shapeInstance._transform.M44 = originalTransform.M44;
        }

        private static void UpdateCollisions(hknpShapeInstance shapeInstance, HashSet<int> removedFaceIndices)
        {
            if (removedFaceIndices.Count == 0 || shapeInstance._shape is not hknpCompressedMeshShape)
                return;

            var shape = (hknpCompressedMeshShape)shapeInstance._shape.Clone(GameVersion.NST);

            shapeInstance._shape = shape;

            UpdateCollisions(shape, removedFaceIndices);
        }

        private static void UpdateCollisions(hknpCompressedMeshShape shape, HashSet<int> removedFaceIndices)
        {
            if (removedFaceIndices.Count == 0 || shape._data?._meshTree == null)
                return;

            var newShape = HavokCollisionsBuilder.RebuildCompressedMeshShape(shape._data._meshTree, removedFaceIndices.Select(id => id/2).ToHashSet());

            if (newShape._data?._meshTree == null)
                return;

            shape._data._meshTree = newShape._data._meshTree;
            shape._numShapeKeyBits = (byte)newShape._data._meshTree._bitsPerKey;
        }
    }
}