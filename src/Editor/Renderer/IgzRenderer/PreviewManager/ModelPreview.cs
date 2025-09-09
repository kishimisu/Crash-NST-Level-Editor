using ImGuiNET;

namespace NST
{
    /// <summary>
    /// Render 3D model previews inside igz files.
    /// Manages the THREE scene, camera and rendering options
    /// </summary>
    public class ModelPreview : ThreeSceneRenderer
    {
        private NSTModel _model;
        private THREE.Object3D _object;
        private THREE.ShaderMaterial _debugMaterial;

        // Render options
        private bool _noCulling = false;
        private static string[] _renderModes = { "Shaded", "Albedo", "UV", "Normal", "Opacity", "Alpha Clip", "Wireframe" };
        private int _renderMode = 0;
        private int _renderDrawCall = -1;

        public ModelPreview(NSTModel model, int width, int height) : base(width, height)
        {
            // Create 3D mesh
            _object = new THREE.Group();
            _object.Add(model.CreateObject());

            // Compute model bounds
            THREE.Box3 boundingBox = new THREE.Box3().SetFromObject(_object);
            float radius = boundingBox.GetSize().Length() * 1.25f;
            THREE.Vector3 center = boundingBox.GetCenter(new THREE.Vector3());

            // Setup camera and controls
            _camera.Far = radius * 8.0f;
            _controls = new OrbitControls(this, _camera, radius);

            // Add ambient light
            _scene.Add(new THREE.AmbientLight(0x525255));
            _scene.Fog = null!;

            // Add directional lights
            var d1 = new THREE.DirectionalLight(new THREE.Color(0xf0f0ff), 1.1f);
            d1.Position.Set(.1f, -.4f, 1f);
            _scene.Add(d1);

            var d2 = new THREE.DirectionalLight(new THREE.Color(0xfaf8ff), 0.2f);
            d2.Position.Set(-.2f, .3f, -.9f);
            _scene.Add(d2);

            // Add mesh to scene
            _object.Position = center.Negate();
            _scene.Add(_object);

            // Create material for custom render modes
            _debugMaterial = new THREE.ShaderMaterial()
            {
                Uniforms = {
                    { "uMap", new THREE.GLUniform { { "value", null! }}},
                    { "uMode", new THREE.GLUniform { { "value", 0 }}},
                    { "uAlphaTest", new THREE.GLUniform { { "value", 0.5f }}}
                },
                VertexShader = """
                    varying vec2 vUv;
                    varying vec3 vNormal;
                    void main() {
                        vUv = uv;
                        vNormal = normal;
                        gl_Position = projectionMatrix * modelViewMatrix * vec4(position, 1.0);
                    }
                """,
                FragmentShader = """
                    uniform sampler2D uMap;
                    uniform float uAlphaTest;
                    uniform int uMode;
                    varying vec2 vUv;
                    varying vec3 vNormal;
                    void main() {
                        vec4 color = texture2D(uMap, vUv);
                        if      (uMode == 1 && color.a < uAlphaTest) discard;    // Albedo
                        else if (uMode == 2) color = vec4(vUv, 0, 1);            // UV
                        else if (uMode == 3) color = vec4(vNormal*.5+.5, 1);     // Normal
                        else if (uMode == 4) color = vec4(color.aaa, 1);         // Opacity
                        else if (uMode == 5) color = vec4(color.a > uAlphaTest); // Alpha clip
                        gl_FragColor = color;
                    }
                """
            };

            _model = model;

            SilkWindow.instance.RestoreViewport();
        }

        /// <summary>
        /// Render the scene & UI
        /// </summary>
        public void Render(IgzRenderer renderer)
        {
            if (ImGui.Checkbox("No culling", ref _noCulling))
            {
                _object.Traverse((obj) => {
                    if (obj.Material == null) return;
                    obj.Material.Side = _noCulling ? THREE.Constants.DoubleSide : THREE.Constants.FrontSide;
                });
            }
            ImGui.SameLine();

            if (ImGui.Combo("Render mode", ref _renderMode, _renderModes, _renderModes.Length))
            {
                UpdateRenderMode();
            }

            IgzTreeNode? selectedNode = renderer.TreeView.SelectedNode;
            
            if (selectedNode?.Object is Alchemy.igModelDrawCallData && (selectedNode.TypeCount - 1) != _renderDrawCall)
            {
                SetRenderDrawCall(selectedNode.TypeCount - 1); // If the currently selected tree node is a draw call, force render that draw call
            }

            base.Render();
            base.DrawImage(0.6f);

            _controls.SetFocus(ImGui.IsItemHovered());
        }

        /// <summary>
        /// Force to render a specific draw call of the model and hide the others
        /// </summary>
        public void SetRenderDrawCall(int drawCallIndex)
        {
            THREE.Object3D mesh = _object.Children[0];

            _renderDrawCall = drawCallIndex;

            for (int i = 0; i < mesh.Children.Count; i++)
            {
                if (_renderDrawCall == -1 || _renderDrawCall == i)
                {
                    mesh.Children[i].Visible = true;
                }
                else
                {
                    mesh.Children[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// Update the material used to render the model
        /// </summary>
        private void UpdateRenderMode()
        {
            // Recreate object
            _object.Children.Clear();
            _object.Add(_model.CreateObject());

            _renderMode = Math.Clamp(_renderMode, 0, _renderModes.Length - 1);

            if (_renderMode == 6) // Wireframe mode
            {
                _object.Traverse((obj) => {
                    if (obj.Material == null) return;
                    obj.Material = (THREE.Material)obj.Material.Clone();
                    obj.Material.Wireframe = true;
                });
            }
            else if (_renderMode > 0) // Other debug modes
            {
                _object.Traverse((obj) => {
                    if (obj.Material == null) return;

                    THREE.Texture map = obj.Material.Map;
                    float alphaTest = obj.Material.AlphaTest;

                    var debugMat = (THREE.ShaderMaterial)_debugMaterial.Clone();
                    debugMat.Transparent = obj.Material.Transparent && _renderMode == 1;
                    (debugMat.Uniforms["uMap"] as THREE.GLUniform)!["value"] = map;
                    (debugMat.Uniforms["uAlphaTest"] as THREE.GLUniform)!["value"] = alphaTest;
                    (debugMat.Uniforms["uMode"] as THREE.GLUniform)!["value"] = _renderMode;

                    obj.Material = debugMat;
                });
            }

            // Apply culling
            _object.Traverse((obj) => {
                if (obj.Material == null) return;
                obj.Material.Side = _noCulling ? THREE.Constants.DoubleSide : THREE.Constants.FrontSide;
            });
        }
    }
}