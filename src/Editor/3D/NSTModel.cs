using Alchemy;

namespace NST
{
    /// <summary>
    /// Wrapper around a list of meshes to interface with THREE.Object3D
    /// </summary>
    public class NSTModel
    {
        public string Name { get; } // Model name
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
    }
}