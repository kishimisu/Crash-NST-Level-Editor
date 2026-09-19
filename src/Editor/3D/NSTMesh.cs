namespace NST
{
    /// <summary>
    /// Wrapper around a draw call to interface with THREE.Mesh
    /// </summary>
    public class NSTMesh : DrawCallData
    {
        // Material properties
        public NSTMaterial Material { get; set; } = new NSTMaterial(); 

        public NSTMesh(DrawCallData data)
        {
            index = data.index;
            indices = data.indices;
            positions = data.positions;
            normals = data.normals;
            colors = data.colors;
            uvs = data.uvs;

            materialHandle = Material.materialHandle = data.materialHandle;
        }

        /// <summary>
        /// Create a THREE.Mesh object from this mesh
        /// </summary>
        public THREE.Mesh CreateMesh()
        {
            var geo = CreateBufferGeometry();
            var mat = Material.CreateThreeMaterial(index);

            mat.VertexColors = colors.Count > 0 && Material.UseVertexColors;

            return new THREE.Mesh(geo, mat) { RenderOrder = index };
        }

        /// <summary>
        /// Create an instanced mesh from this mesh
        /// </summary>
        /// <param name="matrices">The matrices for each instance</param>
        /// <param name="instanceColors">The colors for each instance</param>
        public THREE.InstancedMesh CreateInstancedMesh(List<THREE.Matrix4> matrices, List<THREE.Color>? instanceColors = null)
        {
            THREE.BufferGeometry geometry = CreateBufferGeometry();
            THREE.Material material = Material.CreateThreeMaterial();

            material.VertexColors = colors.Count > 0 && Material.UseVertexColors;

            THREE.InstancedMesh instancedMesh = new THREE.InstancedMesh(geometry, material, matrices.Count);

            for (int i = 0; i < matrices.Count; i++)
            {
                instancedMesh.SetMatrixAt(i, matrices[i]);
                if (instanceColors != null) instancedMesh.SetColorAt(i, instanceColors[i]);
            }

            instancedMesh.FrustumCulled = false;

            return instancedMesh;
        }

        /// <summary>
        /// Create a geometry made of instanced cubes
        /// </summary>
        public static THREE.Group CreateInstancedCubes(List<THREE.Matrix4> matrices, List<THREE.Color> instanceColors)
        {
            THREE.BufferGeometry geometry = new THREE.BoxBufferGeometry(20, 20, 20);
            THREE.Material material = new THREE.MeshPhongMaterial();
            THREE.InstancedMesh instancedMesh = new THREE.InstancedMesh(geometry, material, matrices.Count);

            for (int i = 0; i < matrices.Count; i++)
            {
                instancedMesh.SetMatrixAt(i, matrices[i]);
                instancedMesh.SetColorAt(i, instanceColors[i]);
            }

            instancedMesh.FrustumCulled = false;

            return new THREE.Group() { instancedMesh };
        }

        /// <summary>
        /// Create a THREE.BufferGeometry from the draw call vertex data
        /// </summary>
        public THREE.BufferGeometry CreateBufferGeometry()
        {
            float[] posBuffer = positions.SelectMany(e => new float[] { e.X, e.Y, e.Z }).ToArray();
            float[] normalBuffer = normals.SelectMany(e => new float[] { e.X, e.Y, e.Z }).ToArray();
            float[] colorBuffer = colors.SelectMany(e => new float[] { e.X, e.Y, e.Z }).ToArray();
            float[] uvBuffer = uvs.SelectMany(e => new float[] { e.X, e.Y }).ToArray();
            int[] indexBuffer = indices.Select(e => (int)e).ToArray();

            var geometry = new THREE.BufferGeometry();
            
            geometry.SetAttribute("position", new THREE.BufferAttribute<float>(posBuffer, 3));
            geometry.SetAttribute("normal", new THREE.BufferAttribute<float>(normalBuffer, 3));
            geometry.SetAttribute("uv", new THREE.BufferAttribute<float>(uvBuffer, 2));
            geometry.SetIndex(new THREE.BufferAttribute<int>(indexBuffer, 1));

            if (colors.Count > 0)
            {
                geometry.SetAttribute("color", new THREE.BufferAttribute<float>(colorBuffer, 3));
            }

            return geometry;
        }
    }
}