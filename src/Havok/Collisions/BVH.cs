using System.Numerics;

namespace Havok
{
    /// <summary>
    /// Represents a node in a bounding volume hierarchy
    /// </summary>
    public class BVHNode
    {
        public Vector3 boundsMin;
        public Vector3 boundsMax;
        public int instanceIndex = -1;
        public bool isLeaf = false;
        public BVHNode? left = null;
        public BVHNode? right = null;

        public List<T> BuildAxisTree<T>() where T : hkcdStaticTreeCodec3Axis, new()
        {
            var tree = new List<T>();

            void CompressNode(BVHNode node, Vector3 parentBoundsMin, Vector3 parentBoundsMax, bool root = false)
            {
                var currindex = tree.Count;
                var compressed = new T();
                tree.Add(compressed);

                // Compress the bounding box
                compressed._xyz_0 = CompressDim(node.boundsMin.X, node.boundsMax.X, parentBoundsMin.X, parentBoundsMax.X);
                compressed._xyz_1 = CompressDim(node.boundsMin.Y, node.boundsMax.Y, parentBoundsMin.Y, parentBoundsMax.Y);
                compressed._xyz_2 = CompressDim(node.boundsMin.Z, node.boundsMax.Z, parentBoundsMin.Z, parentBoundsMax.Z);

                // Read back the decompressed bounding box to use as reference for next compression
                var min = DecompressMin(compressed, parentBoundsMin, parentBoundsMax);
                var max = DecompressMax(compressed, parentBoundsMin, parentBoundsMax);

                if (node.isLeaf)
                {
                    SetupLeafNode(compressed, node.instanceIndex);
                }
                else
                {
                    // Encode the left node as the very next node
                    CompressNode(node.left!, min, max);

                    // Setup the current node
                    SetupInternalNode(compressed, tree.Count - currindex);

                    // Encode the right node
                    CompressNode(node.right!, min, max);
                }

                if (root)
                {
                    compressed._xyz_0 = 0;
                    compressed._xyz_1 = 0;
                    compressed._xyz_2 = 0;
                }
            }

            CompressNode(this, boundsMin, boundsMax, true);

            return tree;
        }

        private static void SetupLeafNode(hkcdStaticTreeCodec3Axis node, int instanceIndex)
        {
            if (node is hkcdStaticTreeCodec3Axis6 axis6)
            {
                uint data = (uint)instanceIndex;
                axis6._loData = (ushort)(data & 0xFFFF);
                axis6._hiData = (byte)((data >> 16) & 0x7F);
            }
            else if (node is hkcdStaticTreeCodec3Axis5 axis5)
            {
                uint data = (uint)instanceIndex;
                axis5._loData = (byte)(data & 0xFF);
                axis5._hiData = (byte)((data >> 8) & 0x7F);
            }
            else if (node is hkcdStaticTreeCodec3Axis4 axis4)
            {
                axis4._data = (byte)(instanceIndex * 2);
            }
        }

        private static void SetupInternalNode(hkcdStaticTreeCodec3Axis node, int relativeIndex)
        {
            if (node is hkcdStaticTreeCodec3Axis6 axis6)
            {
                uint data = (uint)(relativeIndex / 2);
                axis6._loData = (ushort)(data & 0xFFFF);
                axis6._hiData = (byte)(((data >> 16) & 0x7F) | 0x80);
            }
            else if (node is hkcdStaticTreeCodec3Axis5 axis5)
            {
                uint data = (uint)(relativeIndex / 2);
                axis5._loData = (byte)(data & 0xFF);
                axis5._hiData = (byte)(((data >> 8) & 0x7F) | 0x80);
            }
            else if (node is hkcdStaticTreeCodec3Axis4 axis4)
            {
                axis4._data = (byte)(relativeIndex | 0x1);
            }
        }

        private static byte CompressDim(float min, float max, float pmin, float pmax)
        {
            float snorm = 226.0f / (pmax - pmin);
            float rmin = MathF.Sqrt(MathF.Max((min - pmin) * snorm, 0));
            float rmax = MathF.Sqrt(MathF.Max((max - pmax) * -snorm, 0));
            byte a = (byte)Math.Min(0xF, (int)MathF.Floor(rmin));
            byte b = (byte)Math.Min(0xF, (int)MathF.Floor(rmax));
            return (byte)((a << 4) | b);
        }

        private static Vector3 DecompressMin(hkcdStaticTreeCodec3Axis c, Vector3 pmin, Vector3 pmax)
        {
            float x = ((float)(c._xyz_0 >> 4) * (float)(c._xyz_0 >> 4)) * (1.0f / 226.0f) * (pmax.X - pmin.X) + pmin.X;
            float y = ((float)(c._xyz_1 >> 4) * (float)(c._xyz_1 >> 4)) * (1.0f / 226.0f) * (pmax.Y - pmin.Y) + pmin.Y;
            float z = ((float)(c._xyz_2 >> 4) * (float)(c._xyz_2 >> 4)) * (1.0f / 226.0f) * (pmax.Z - pmin.Z) + pmin.Z;
            return new Vector3(x, y, z);
        }

        private static Vector3 DecompressMax(hkcdStaticTreeCodec3Axis c, Vector3 pmin, Vector3 pmax)
        {
            float x = -((float)(c._xyz_0 & 0x0F) * (float)(c._xyz_0 & 0x0F)) * (1.0f / 226.0f) * (pmax.X - pmin.X) + pmax.X;
            float y = -((float)(c._xyz_1 & 0x0F) * (float)(c._xyz_1 & 0x0F)) * (1.0f / 226.0f) * (pmax.Y - pmin.Y) + pmax.Y;
            float z = -((float)(c._xyz_2 & 0x0F) * (float)(c._xyz_2 & 0x0F)) * (1.0f / 226.0f) * (pmax.Z - pmin.Z) + pmax.Z;
            return new Vector3(x, y, z);
        }
    }

    /// <summary>
    /// Build a BVH from a list of primitives (3D bouding boxes)
    /// </summary>
    public static class BVHBuilder
    {
        public static BVHNode Build(IList<hknpShapeInstance> shapes)
        {
            List<BVHNode> nodes = [];

            for (int i = 0; i < shapes.Count; i++)
            {
                hknpShapeInstance instance = shapes[i];

                Vector3 scale = instance._scale.AsVector3();
                
                Box3 shapeBounds = Box3.Infinity;

                if (instance._shape is hknpCompressedMeshShape cshape)
                {
                    if (cshape._data?._meshTree == null)
                        continue;

                    var transform = Matrix4x4.Transpose(instance._transform) * Matrix4x4.CreateScale(scale);

                    shapeBounds = new Box3(
                        cshape._data._meshTree._min.AsVector3(),
                        cshape._data._meshTree._max.AsVector3()
                    )
                    .ApplyAffineMatrix(transform);
                }
                else if (instance._shape is hknpConvexPolytopeShape pshape)
                {
                    for (int j = 0; j < pshape._vertices.Count; j++) 
                    {
                        Vector3 vertex = pshape._vertices[j].AsVector3();

                        vertex = Vector3.Transform(vertex * scale, instance._transform);

                        shapeBounds.Encapsulate(vertex);
                    }

                    float r = pshape._convexRadius;
                    shapeBounds.Min -= new Vector3(r, r, r);
                    shapeBounds.Max += new Vector3(r, r, r);
                }
                else if (instance._shape is hknpSphereShape sshape)
                {
                    if (sshape._vertices == null || sshape._vertices.Count == 0)
                    {
                        Console.WriteLine("Warning: Sphere shape has no vertices");
                        continue;
                    }

                    // Assume first vertex stores center, W = radius
                    Vector4 centerData = sshape._vertices[0];
                    Vector3 center = new Vector3(centerData.X, centerData.Y, centerData.Z);
                    float radius = centerData.W * (scale.X + scale.Y + scale.Z) / 3f;

                    // Transform sphere center
                    Vector3 transformedCenter = Vector3.Transform(center, instance._transform);

                    // Build bounding box
                    shapeBounds = new Box3(
                        transformedCenter - new Vector3(radius, radius, radius),
                        transformedCenter + new Vector3(radius, radius, radius)
                    );
                }
                else throw new Exception("Unsupported shape type: " + instance._shape?.GetType());

                nodes.Add(new BVHNode {
                    instanceIndex = i,
                    boundsMin = shapeBounds.Min,
                    boundsMax = shapeBounds.Max
                });
            }

            return Build(nodes);
        }

        public static BVHNode Build(List<hkcdStaticMeshTreeBaseSection> sections)
        {
            List<BVHNode> nodes = [];

            for (int i = 0; i < sections.Count; i++)
            {
                var section = sections[i];

                nodes.Add(new BVHNode {
                    instanceIndex = i,
                    boundsMin = section._min.AsVector3(),
                    boundsMax = section._max.AsVector3()
                });
            }

            return Build(nodes);
        }

        public static BVHNode Build(List<HkxPrimitive> primitives)
        {
            List<BVHNode> nodes = [];

            for (int i = 0; i < primitives.Count; i++)
            {
                var primitive = primitives[i];

                nodes.Add(new BVHNode {
                    instanceIndex = i,
                    boundsMin = primitive.Bounds.Min,
                    boundsMax = primitive.Bounds.Max
                });
            }

            return Build(nodes);
        }

        private static BVHNode Build(List<BVHNode> nodes)
        {
            if (nodes.Count == 1) {
                nodes[0].isLeaf = true;
                return nodes[0];
            }

            // Compute global bounding box
            Vector3 min = new Vector3(float.MaxValue);
            Vector3 max = new Vector3(float.MinValue);
            foreach (var node in nodes) {
                min = Vector3.Min(min, node.boundsMin);
                max = Vector3.Max(max, node.boundsMax);
            }

            Vector3 extent = max - min;

            // Find the axis with the greatest extent
            int axis = 0;
            if (extent.Y > extent.X && extent.Y > extent.Z) axis = 1;
            else if (extent.Z > extent.X && extent.Z > extent.Y) axis = 2;

            // Sort by centroid along the chosen axis
            nodes.Sort((a, b) => {
                float ca = GetCentroid(a, axis);
                float cb = GetCentroid(b, axis);
                return ca.CompareTo(cb);
            });

            // Split the nodes into two halves
            int mid = nodes.Count / 2;
            var leftNodes = nodes.GetRange(0, mid);
            var rightNodes = nodes.GetRange(mid, nodes.Count - mid);

            // Recursively build children
            var left = Build(leftNodes);
            var right = Build(rightNodes);

            // Create parent node
            var parent = new BVHNode {
                left = left,
                right = right,
                boundsMin = Vector3.Min(left.boundsMin, right.boundsMin),
                boundsMax = Vector3.Max(left.boundsMax, right.boundsMax),
                isLeaf = false,
                instanceIndex = -1
            };

            return parent;
        }
        
        private static float GetCentroid(BVHNode node, int axis) {
            var center = (node.boundsMin + node.boundsMax) * 0.5f;
            return axis == 0 ? center.X : (axis == 1 ? center.Y : center.Z);
        }
    }
}