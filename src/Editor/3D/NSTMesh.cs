using Alchemy;

namespace NST
{
    /// <summary>
    /// Wrapper around a draw call to interface with THREE.Mesh
    /// </summary>
    public class NSTMesh : DrawCallData
    {
        // Material properties
        public NSTMaterial Material { get; set; } = new NSTMaterial(); 

        // 3D mesh
        private THREE.Mesh? _mesh;
        public THREE.Mesh Mesh 
        {
            get
            {
                // if (_mesh != null) return new THREE.Mesh(_mesh);
                return CreateMesh();
            }
        }

        public NSTMesh(DrawCallData data)
        {
            index = data.index;
            indices = data.indices;
            positions = data.positions;
            normals = data.normals;
            uvs = data.uvs;

            materialHandle = Material.materialHandle = data.materialHandle;
        }

        /// <summary>
        /// Create a new THREE.Mesh instance using the draw call geometry and material
        /// </summary>
        private THREE.Mesh CreateMesh()
        {
            var geo = CreateBufferGeometry();
            var mat = Material.CreateThreeMaterial(index);

            _mesh = new THREE.Mesh(geo, mat) { RenderOrder = index };

            return _mesh;
        }

        /// <summary>
        /// Create a THREE.BufferGeometry from the draw call vertex data
        /// </summary>
        /// <returns></returns>
        public THREE.BufferGeometry CreateBufferGeometry()
        {
            float[] posBuffer = positions.SelectMany(e => new float[] { e.X, e.Y, e.Z }).ToArray();
            float[] normalBuffer = normals.SelectMany(e => new float[] { e.X, e.Y, e.Z }).ToArray();
            float[] uvBuffer = uvs.SelectMany(e => new float[] { e.X, e.Y }).ToArray();
            List<int> indexBuffer = indices.Select(e => (int)e).ToList();

            var geometry = new THREE.BufferGeometry();
            
            geometry.SetAttribute("position", new THREE.BufferAttribute<float>(posBuffer, 3));
            geometry.SetAttribute("normal", new THREE.BufferAttribute<float>(normalBuffer, 3));
            geometry.SetAttribute("uv", new THREE.BufferAttribute<float>(uvBuffer, 2));
            geometry.SetIndex(indexBuffer);

            return geometry;
        }

        public THREE.BufferGeometry CreateInterleavedBufferGeometry()
        {
            List<int> indexBuffer = indices.Select(i => (int)i).ToList();
            float[] interleavedAttributes = new float[positions.Count * 3 + normals.Count * 3 + uvs.Count * 2];

            for (int i = 0; i < positions.Count; i++)
            {
                System.Numerics.Vector3 position = positions[i];
                System.Numerics.Vector3 normal = normals[i];
                System.Numerics.Vector2 uv = uvs[i];

                interleavedAttributes[i * 8 + 0] = position.X;
                interleavedAttributes[i * 8 + 1] = position.Y;
                interleavedAttributes[i * 8 + 2] = position.Z;
                interleavedAttributes[i * 8 + 3] = normal.X;
                interleavedAttributes[i * 8 + 4] = normal.Y;
                interleavedAttributes[i * 8 + 5] = normal.Z;
                interleavedAttributes[i * 8 + 6] = uv.X;
                interleavedAttributes[i * 8 + 7] = uv.Y;
            }

            var buffer = new THREE.InterleavedBuffer<float>(interleavedAttributes, 8);

            var geometry = new THREE.BufferGeometry();
            geometry.SetAttribute("position", new THREE.InterleavedBufferAttribute<float>(buffer, 3, 0));
            geometry.SetAttribute("normal", new THREE.InterleavedBufferAttribute<float>(buffer, 3, 3));
            geometry.SetAttribute("uv", new THREE.InterleavedBufferAttribute<float>(buffer, 2, 6));
            geometry.SetIndex(indexBuffer);

            return geometry;
        }
    }
}