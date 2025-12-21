using Alchemy;

namespace NST
{
    /// <summary>
    /// Wrapper around a list of meshes to interface with THREE.Object3D
    /// </summary>
    public class NSTModel
    {
        public string Name { get; } // Model name
        public string FilePath { get;  set; } // Model file path in archive
        public string OriginalPath { get; set; } // Value as found in the igz file
        public List<NSTMesh> Meshes { get; } = []; // List of meshes

        public NSTModel(List<NSTMesh> meshes, string name = "")
        {
            Name = name;
            Meshes = meshes;
        }

        /// <summary>
        /// Construct a new NSTModel from an igz file containing an igModelData object
        /// </summary>
        public static NSTModel? FromIgz(IgzFile igz)
        {
            igModelData? model = igz.FindObject<igModelData>();

            if (model == null) return null;

            List<NSTMesh> meshes = model.ExtractDrawCalls().Select(drawCall => new NSTMesh(drawCall)).ToList();

            return new NSTModel(meshes, igz.GetName(false));
        }
        
        /// <summary>
        /// Combine all meshes into a single THREE.Group
        /// </summary>
        public THREE.Group CreateObject()
        {
            THREE.Group group = new THREE.Group();

            for (int i = 0; i < Meshes.Count; i++)
            {
                group.Add(Meshes[i].Mesh);
            }

            return group;
        }

        /// <summary>
        /// Create an optimized instanced mesh of this model
        /// </summary>
        /// <param name="matrices">The matrices for each instance</param>
        public THREE.Group CreateInstancedMeshes(List<THREE.Matrix4> matrices, List<THREE.Color>? colors = null)
        {
            THREE.Group group = new THREE.Group();

            for (int i = 0; i < Meshes.Count; i++)
            {
                group.Add(CreateInstancedMesh(Meshes[i], matrices, colors));
            }

            return group;
        }

        public static THREE.Group CreateInstancedCubes(List<THREE.Matrix4> matrices, List<THREE.Color> colors)
        {
            THREE.BufferGeometry geometry = new THREE.BoxBufferGeometry(20, 20, 20);
            THREE.Material material = new THREE.MeshPhongMaterial();
            THREE.InstancedMesh instancedMesh = new THREE.InstancedMesh(geometry, material, matrices.Count);

            for (int i = 0; i < matrices.Count; i++)
            {
                instancedMesh.SetMatrixAt(i, matrices[i]);
                instancedMesh.SetColorAt(i, colors[i]);
            }

            instancedMesh.FrustumCulled = false;

            return new THREE.Group() { instancedMesh };
        }

        /// <summary>
        /// Create an instanced mesh from a single mesh
        /// </summary>
        /// <param name="matrices">The matrices for each instance</param>
        private THREE.InstancedMesh CreateInstancedMesh(NSTMesh mesh, List<THREE.Matrix4> matrices, List<THREE.Color>? colors = null)
        {
            THREE.BufferGeometry geometry = mesh.CreateBufferGeometry();
            THREE.Material material = mesh.Material.CreateThreeMaterial();

            THREE.InstancedMesh instancedMesh = new THREE.InstancedMesh(geometry, material, matrices.Count);

            for (int i = 0; i < matrices.Count; i++)
            {
                instancedMesh.SetMatrixAt(i, matrices[i]);
                if (colors != null) instancedMesh.SetColorAt(i, colors[i]);
            }

            instancedMesh.FrustumCulled = false;

            return instancedMesh;
        }
    }
}