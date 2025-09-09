using NST;
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

        private static byte CompressDim(float min, float max, float pmin, float pmax)
        {
            float snorm = 226.0f / (pmax - pmin);
            float rmin = MathF.Sqrt(MathF.Max((min - pmin) * snorm, 0));
            float rmax = MathF.Sqrt(MathF.Max((max - pmax) * -snorm, 0));
            byte a = (byte)Math.Min(0xF, (int)MathF.Floor(rmin));
            byte b = (byte)Math.Min(0xF, (int)MathF.Floor(rmax));
            return (byte)((a << 4) | b);
        }

        public Vector3 DecompressMin(hkcdStaticTreeCodec3Axis6 c, Vector3 parentMin, Vector3 parentMax)
        {
            float x = ((float)(c._xyz_0 >> 4) * (float)(c._xyz_0 >> 4)) * (1.0f / 226.0f) * (parentMax.X - parentMin.X) + parentMin.X;
            float y = ((float)(c._xyz_1 >> 4) * (float)(c._xyz_1 >> 4)) * (1.0f / 226.0f) * (parentMax.Y - parentMin.Y) + parentMin.Y;
            float z = ((float)(c._xyz_2 >> 4) * (float)(c._xyz_2 >> 4)) * (1.0f / 226.0f) * (parentMax.Z - parentMin.Z) + parentMin.Z;
            return new Vector3(x, y, z);
        }

        public Vector3 DecompressMax(hkcdStaticTreeCodec3Axis6 c, Vector3 parentMin, Vector3 parentMax)
        {
            float x = -((float)(c._xyz_0 & 0x0F) * (float)(c._xyz_0 & 0x0F)) * (1.0f / 226.0f) * (parentMax.X - parentMin.X) + parentMax.X;
            float y = -((float)(c._xyz_1 & 0x0F) * (float)(c._xyz_1 & 0x0F)) * (1.0f / 226.0f) * (parentMax.Y - parentMin.Y) + parentMax.Y;
            float z = -((float)(c._xyz_2 & 0x0F) * (float)(c._xyz_2 & 0x0F)) * (1.0f / 226.0f) * (parentMax.Z - parentMin.Z) + parentMax.Z;
            return new Vector3(x, y, z);
        }

        public List<hkcdStaticTreeCodec3Axis6> BuildAxis6Tree()
        {
            var tree = new List<hkcdStaticTreeCodec3Axis6>();

            void CompressNode(BVHNode node, Vector3 pbbmin, Vector3 pbbmax, bool root = false)
            {
                var currindex = tree.Count();
                var compressed = new hkcdStaticTreeCodec3Axis6();
                tree.Add(compressed);

                // Compress the bounding box
                compressed._xyz_0 = CompressDim(node.boundsMin.X, node.boundsMax.X, pbbmin.X, pbbmax.X);
                compressed._xyz_1 = CompressDim(node.boundsMin.Y, node.boundsMax.Y, pbbmin.Y, pbbmax.Y);
                compressed._xyz_2 = CompressDim(node.boundsMin.Z, node.boundsMax.Z, pbbmin.Z, pbbmax.Z);

                // Read back the decompressed bounding box to use as reference for next compression
                var min = DecompressMin(compressed, pbbmin, pbbmax);
                var max = DecompressMax(compressed, pbbmin, pbbmax);

                if (node.isLeaf)
                {
                    uint data = (uint)(node.instanceIndex);
                    compressed._loData = (ushort)(data & 0xFFFF);
                    compressed._hiData = (byte)((data >> 16) & 0x7F);
                }
                else
                {
                    // Add the left as the very next node
                    CompressNode(node.left!, min, max);

                    // Encode the index of the right then add it. The index should always be even
                    ushort data = (ushort)((tree.Count() - currindex) / 2);
                    compressed._loData = (ushort)(data & 0xFFFF);
                    compressed._hiData = (byte)(((data >> 16) & 0x7F) | 0x80);

                    // Now encode the right
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
    }

    /// <summary>
    /// Class used to build a BVH from a list of hknpShapeInstance
    /// </summary>
    public static class BVHBuilder
    {
        public static BVHNode Build(List<hknpShapeInstance> shapes)
        {
            Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
            List<BVHNode> nodes = [];

            foreach (hknpShapeInstance instance in shapes) 
            {
                Vector3 shapeMin = Vector3.Zero;
                Vector3 shapeMax = Vector3.Zero;

                if (instance._shape is hknpCompressedMeshShape cshape)
                {
                    shapeMin = cshape._data._meshTree._min.AsVector3();
                    shapeMax = cshape._data._meshTree._max.AsVector3();

                    THREE.Box3 shapeBounds = new THREE.Box3(
                        new THREE.Vector3(shapeMin.X, shapeMin.Y, shapeMin.Z),
                        new THREE.Vector3(shapeMax.X, shapeMax.Y, shapeMax.Z)
                    )
                    .ApplyMatrix4Affine(instance._transform.ToMatrix4());

                    shapeMin = new Vector3(shapeBounds.Min.X, shapeBounds.Min.Y, shapeBounds.Min.Z);
                    shapeMax = new Vector3(shapeBounds.Max.X, shapeBounds.Max.Y, shapeBounds.Max.Z);
                }
                else if (instance._shape is hknpConvexPolytopeShape pshape)
                {
                    shapeMin = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
                    shapeMax = new Vector3(float.MinValue, float.MinValue, float.MinValue);

                    for (int i = 0; i < pshape._vertices.Count; i++) {
                        Vector3 vertex = Vector3.Transform(pshape._vertices[i].AsVector3(), instance._transform);
                        shapeMin = Vector3.Min(shapeMin, vertex);
                        shapeMax = Vector3.Max(shapeMax, vertex);
                    }

                    float r = pshape._convexRadius;
                    shapeMin -= new Vector3(r, r, r);
                    shapeMax += new Vector3(r, r, r);
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
                    float radius = centerData.W;

                    // Transform sphere center
                    Vector3 transformedCenter = Vector3.Transform(center, instance._transform);

                    // Build bounding box
                    shapeMin = transformedCenter - new Vector3(radius, radius, radius);
                    shapeMax = transformedCenter + new Vector3(radius, radius, radius);
                }
                else throw new Exception("Unsupported shape type: " + instance._shape.GetType());

                min = Vector3.Min(min, shapeMin);
                max = Vector3.Max(max, shapeMax);

                nodes.Add(new BVHNode {
                    boundsMin = shapeMin,
                    boundsMax = shapeMax,
                    instanceIndex = shapes.IndexOf(instance)
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

        private static THREE.Box3 ApplyMatrix4Affine(this THREE.Box3 box3, THREE.Matrix4 matrix)
        {
            var _points = new THREE.Vector3[8];

            for (int i = 0; i < 8; i++) {
                _points[i] = new THREE.Vector3();
            }

            _points[0].Set(box3.Min.X, box3.Min.Y, box3.Min.Z).ApplyMatrix4Affine(matrix); // 000
            _points[1].Set(box3.Min.X, box3.Min.Y, box3.Max.Z).ApplyMatrix4Affine(matrix); // 001
            _points[2].Set(box3.Min.X, box3.Max.Y, box3.Min.Z).ApplyMatrix4Affine(matrix); // 010
            _points[3].Set(box3.Min.X, box3.Max.Y, box3.Max.Z).ApplyMatrix4Affine(matrix); // 011
            _points[4].Set(box3.Max.X, box3.Min.Y, box3.Min.Z).ApplyMatrix4Affine(matrix); // 100
            _points[5].Set(box3.Max.X, box3.Min.Y, box3.Max.Z).ApplyMatrix4Affine(matrix); // 101
            _points[6].Set(box3.Max.X, box3.Max.Y, box3.Min.Z).ApplyMatrix4Affine(matrix); // 110
            _points[7].Set(box3.Max.X, box3.Max.Y, box3.Max.Z).ApplyMatrix4Affine(matrix); // 111

            box3.SetFromPoints(_points.ToList());

            return box3;
        }

        private static THREE.Vector3 ApplyMatrix4Affine(this THREE.Vector3 vec3, THREE.Matrix4 m)
        {
            var x = vec3.X;
            var y = vec3.Y;
            var z = vec3.Z;
            var e = m.Elements;

            vec3.X = e[0] * x + e[4] * y + e[8] * z + e[12];
            vec3.Y = e[1] * x + e[5] * y + e[9] * z + e[13];
            vec3.Z = e[2] * x + e[6] * y + e[10] * z + e[14];

            return vec3;
        }
    }
}