using Alchemy;
using ImGuiNET;

namespace NST
{
    /// <summary>
    /// Render a custom preview for some IGZ objects (igModelData, igFxMaterial, igImage2, CSound, CSubSound)
    /// </summary>
    public class IgzPreviewManager
    {
        private IgzFile _igz; // Parent IGZ file
        private IgzRenderer _renderer; // Parent IGZ renderer
        
        private ModelPreview? _modelPreview = null;                      // 3D model preview
        private Dictionary<IgzTreeNode, NSTMaterial>? _materials = null; // Material previews
        private TexturePreview? _texturePreview = null;                  // Texture preview
        private List<CSoundPreview>? _soundGroups = null;                // Sound bank previews

        public bool IsActive() => _texturePreview != null || _modelPreview != null || _materials != null || _soundGroups != null;
        public bool IsActiveInObjectView() => _materials != null || _soundGroups != null;
        public ModelPreview? GetModelPreview() => _modelPreview;

        public IgzPreviewManager(IgzRenderer renderer)
        {
            _renderer = renderer;
            _igz = renderer.Igz;

            InitModelFile();
            InitMaterialFile();
            InitTextureFile();
            InitSoundBank();
        }

        /// <summary>
        /// Try to create a preview for an `igModelData` object
        /// </summary>
        private void InitModelFile()
        {
            NSTModel? model = NSTModel.FromIgz(_igz);
            if (model == null) return;

            List<igModelDrawCallData> drawCallObjects = _igz.FindObjects<igModelDrawCallData>();
            List<NSTMesh> meshes = model.Meshes;

            if (drawCallObjects.Count != meshes.Count)
            {
                Console.Error.WriteLine($"Warning: Draw call count doesn't match ({drawCallObjects.Count}/{meshes.Count}) for model {_igz.GetName()}");
                return;
            }

            if (drawCallObjects.Count == 0) return;

            _materials = [];

            foreach ((NSTMesh mesh, igModelDrawCallData drawCallObject) in meshes.Zip(drawCallObjects))
            {
                mesh.Material.InititializeMaterialAndTextures(_renderer.ArchiveRenderer.Archive);

                IgzTreeNode node = _renderer.TreeView.FindNode(drawCallObject)!;

                node.MaterialPreview = mesh.Material;

                _materials.Add(node, mesh.Material);
            }

            _modelPreview = new ModelPreview(model, 800, 600);
        }

        /// <summary>
        /// Try to create a preview for an `igFxMaterial` object
        /// </summary>
        private void InitMaterialFile()
        {
            List<igFxMaterial> materials = _igz.FindObjects<igFxMaterial>();

            if (materials.Count == 0) return;

            _materials = [];

            foreach (igFxMaterial material in materials)
            {
                IgzTreeNode node = _renderer.TreeView.FindNode(material)!;
                NSTMaterial mat = new NSTMaterial(material);

                _materials.Add(node, mat);

                node.MaterialPreview = mat;
            }
        }

        /// <summary>
        /// Try to create a preview for an `igImage2` object
        /// </summary>
        private void InitTextureFile()
        {
            igImage2? texture = _igz.FindObject<igImage2>();

            if (texture == null || !texture.HasPixels()) return;

            _texturePreview = new TexturePreview(_renderer, texture);
        }

        /// <summary>
        /// Try to create a preview for a `CSound` object
        /// </summary>
        private void InitSoundBank()
        {
            _soundGroups = _igz.FindObjects<CSound>()
                               .Select(obj => new CSoundPreview(_renderer, obj))
                               .ToList();

            if (_soundGroups.Count == 0) _soundGroups = null;
        }

        /// <summary>
        /// Render the preview above the tree view
        /// </summary>
        public void RenderInTreeView()
        {
            RenderTexture();
            RenderModel();
        }

        /// <summary>
        /// Render the preview above the object fields
        /// </summary>
        public void RenderInObjectView()
        {
            RenderMaterials();
            RenderSoundBank();
        }

        /// <summary>
        /// Render the 3D model preview
        /// </summary>
        private void RenderModel()
        {
            if (_modelPreview == null) return;

            _modelPreview.Render(_renderer);

            if (ImGui.IsItemHovered()) ImGui.SetNextFrameWantCaptureMouse(false);
        }

        /// <summary>
        /// Render material previews
        /// </summary>
        private void RenderMaterials()
        {
            if (_materials == null) return;
            if (_renderer.TreeView.SelectedNode != null) return;

            string title = _modelPreview != null ? "Drawcall" : "Material";

            if (ImGui.TreeNodeEx($"{title} Infos ({_materials.Count})", ImGuiTreeNodeFlags.DefaultOpen | ImGuiTreeNodeFlags.SpanAvailWidth | ImGuiTreeNodeFlags.NoTreePushOnOpen))
            {
                int i = 0;
                foreach (var (node, mat) in _materials)
                {
                    if (mat == null)
                    {
                        ImGui.SameLine();
                        node.RenderObjectName();
                        ImGui.Spacing();
                        ImGui.Text("(No material)");
                        ImGui.Separator();
                        ImGui.Spacing();
                    }
                    else
                    {
                        ImGui.BeginGroup();
                        mat.Render(_renderer, node, true);
                        ImGui.EndGroup();

                        if (_modelPreview != null && ImGui.IsItemHovered())
                        {
                            _modelPreview.SetRenderDrawCall(i); // When a material is hovered in a model file, only render the drawcall it belongs to
                        }
                    }
                    i++;
                }

                ImGui.TreePop();
            }
        }

        /// <summary>
        /// Render texture preview
        /// </summary>
        private void RenderTexture()
        {
            if (_texturePreview == null) return;
            _texturePreview.Render();
        }

        /// <summary>
        /// Render sound previews
        /// </summary>
        private void RenderSoundBank()
        {
            if (_soundGroups == null) return;
            if (_renderer.TreeView.SelectedNode != null) return;

            if (ImGui.TreeNodeEx($"Sound groups ({_soundGroups.Count}):", ImGuiTreeNodeFlags.DefaultOpen | ImGuiTreeNodeFlags.SpanAvailWidth | ImGuiTreeNodeFlags.NoTreePushOnOpen))
            {
                ImGui.Spacing();
                ImGui.Separator();

                foreach (CSoundPreview soundGroup in _soundGroups)
                {
                    soundGroup.Render(_renderer);
                }

                ImGui.TreePop();
            }
        }
    }
}