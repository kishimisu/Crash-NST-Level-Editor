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
                if (_mesh != null) 
                {
                    return new THREE.Mesh(_mesh);
                }
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
    }
}