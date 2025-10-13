using Alchemy;
using Havok;
using ImGuiNET;
using System.Diagnostics;

namespace NST
{
    public class LevelExplorer : ThreeSceneRenderer
    {
        static Dictionary<string, NSTModel> _cachedModels = [];
        static Dictionary<NamedReference, NSTMaterial> _cachedMaterials = [];

        IgArchive _archive;
        public IgArchiveRenderer _archiveRenderer;
        public ActiveFileManager _fileManager;

        public EntityTreeView _treeView;
        public InstancedMeshManager _instanceManager;
        public SelectionManager _selectionManager;
        THREE.Silk.TransformControls _gizmos;
        System.Numerics.Vector4 _renderBounds = new System.Numerics.Vector4();

        ProgressManager _progressManager = new ProgressManager();
        Task _initializationTask;

        bool _isOpen = true;
        bool _isDragging = false;

        public enum CameraLayer { Default = 0, AllEntities = 1, Splines = 2, Triggers = 3, Templates = 4, Clouds = 5, Shadows = 6, Hidden = 7 };
        public enum DebugMode { None = 0, Collisions = 1, Prefabs = 2, GameObjects = 3 };
        readonly string[] _debugModes = new string[] { "None", "Static Collisions", "Prefabs", "Game Objects" };
        readonly Dictionary<string, bool> _layers = new()
        {
            { "All Entities", true },
            { "Splines", true },
            { "Triggers", false },
            { "Templates", false },
            { "Clouds", false },
            { "Shadows", false },
            { "Hidden", false },
        };

        public DebugMode DebugRenderMode => (DebugMode)_debugMode;
        private int _debugMode = 0;

        public IgArchive GetArchive() => _archive;
        public bool IsOpen() => _isOpen;
        public void SetOpen(bool isOpen = true) => _isOpen = isOpen;
        public string GetWindowName() => _archive.GetName() + "##" + GetHashCode();

        public const bool SKIP_TEXTURES = false;

        public LevelExplorer(IgArchiveRenderer archiveRenderer) : base(useEffectComposer: true, alwaysRender: false)
        {
            InitScene();

            _archiveRenderer = archiveRenderer;
            _archive = archiveRenderer.Archive;
            _fileManager = archiveRenderer.FileManager;

            _initializationTask = Task.Run(() => LoadEntities(_archive))
                .ContinueWith(t =>
                {
                    if (t.IsFaulted && t.Exception != null)
                    {
                        foreach (var ex in t.Exception.InnerExceptions)
                        {
                            Console.WriteLine($"ERROR loading entities: {ex.Message}\n{ex.StackTrace}");
                            ModalRenderer.ShowMessageModal("Error", "An error occured while loading the scene");
                        }
                    }
                }, TaskContinuationOptions.OnlyOnFaulted);            

            MouseMove += (_, e) => _isDragging = true;
            MouseDown += (_, e) => _isDragging = false;
            MouseUp   += (_, e) =>
            {
                if (_isDragging || e.Button != Silk.NET.Input.MouseButton.Left) 
                {
                    _isDragging = false;
                }
                else if (_controls.Focused())
                {
                    var intersections = Raycast(GetClipSpaceMousePos(e), _camera.Far);
                    SelectFromRaycast(intersections);
                }
            };
        }

        private void InitScene()
        {
            _camera.Near = 10.0f;
            _camera.Far = 120000.0f;
            _scene.Fog.Far = _camera.Far;
            _camera.UpdateProjectionMatrix();
            UpdateCameraLayers();

            // Add ambient light
            var ambientLight = new THREE.AmbientLight(0x525255);
            _scene.Add(ambientLight);

            // Add directional light
            var d1 = new THREE.DirectionalLight(new THREE.Color(0xf0f0ff), 1.1f);
            d1.Position.Set(.1f, -.4f, 1f);
            _scene.Add(d1);

            var d2 = new THREE.DirectionalLight(new THREE.Color(0xfaf8ff), 0.2f);
            d2.Position.Set(-.2f, .3f, -.9f);
            _scene.Add(d2);

            _controls = new FirstPersonControls(this, _camera);

            _gizmos = new THREE.Silk.TransformControls(this, _camera, GetClipSpaceMousePos);

            _gizmos._mouseUpEvent += (string obj) =>
            {
                _selectionManager.ApplyChanges(_fileManager, _archiveRenderer);
            };

            _scene.Add(_gizmos);

            _outlinePass.gizmos = _gizmos;

            _instanceManager = new InstancedMeshManager(this, _scene);

            _selectionManager = new SelectionManager(_instanceManager._rootObject, _gizmos, _outlinePass, this);

            SilkWindow.instance.RestoreViewport();
        }

        private void LoadEntities(IgArchive archive)
        {
            Stopwatch sw = Stopwatch.StartNew();
            
            Dictionary<NSTEntity, string?> entities = [];

            Dictionary<string, NSTModel> models = [];
            HashSet<string> modelNames = [];

            Dictionary<NamedReference, NSTMaterial> materials = [];
            HashSet<NamedReference> materialRefs = [];

            Dictionary<NSTMesh, NamedReference> _meshToMaterial = [];
            Dictionary<NamedReference, List<NSTMaterial>> _textureToMaterials = [];

            // Step 1: Find entities (+ model names)

            List<IgArchiveFile> mapFiles = archive.GetFiles()
                .Where( f => f.GetPath().StartsWith("maps/") && f.GetPath().EndsWith(".igz") )
                .ToList();

            for (int i = 0; i < mapFiles.Count; i++)
            {
                IgArchiveFile mapFile = mapFiles[i];
                IgzFile igz = _fileManager.GetIgz(mapFile) ?? mapFile.ToIgzFile();

                _progressManager.SetProgress("entities", (float)(i+1) / mapFiles.Count, $"Loading entity files {i + 1}/{mapFiles.Count}...");

                bool entityAdded = false;

                foreach (igObject obj in igz.Objects)
                {
                    if (obj is not igEntity entity) continue;

                    string? modelName = entity.GetModelName(_archive);

                    NSTEntity entity3D = new NSTEntity(entity, mapFile);

                    // Camera starting position
                    if (entity is CPlayerStartEntity) 
                    {
                        THREE.Vector3 camPos = entity3D.Position + new THREE.Vector3(0, -600, 600);
                        _camera.Position.Set(camPos.X, camPos.Y, camPos.Z);
                        _controls.LookAt(_camera.Position + new THREE.Vector3(0, 1, 0));
                    }

                    entities.Add(entity3D, modelName);
                    entityAdded = true;
                    
                    if (modelName != null) {
                        modelNames.Add(modelName);
                    }
                }

                if (entityAdded)
                {
                    _fileManager.Add(mapFile, igz, true);
                }
            }

            // Step 2 : Load models (+ find meshes and materials)

            for (int i = 0; i < modelNames.Count; i++)
            {
                string modelName = modelNames.ElementAt(i);
                string modelNameLower = modelName.ToLowerInvariant();
                _progressManager.SetProgress("models", (float)(i+1) / modelNames.Count, $"Loading models {i + 1}/{modelNames.Count}...");

                if (_cachedModels.TryGetValue(modelNameLower, out NSTModel? cachedModel))
                {
                    models[modelName] = cachedModel;
                    continue;
                }

                IgArchiveFile? modelFile = archive.GetFiles().FirstOrDefault(f =>
                {
                    return (f.GetPath().StartsWith("actors/") || f.GetPath().StartsWith("models/")) && 
                            f.IsIGZ() && f.GetName(false).ToLowerInvariant() == modelNameLower;
                });

                if (modelFile == null)
                {
                    Console.WriteLine($"WARNING: Failed to find model file for {modelName}.");
                    continue;
                }

                NSTModel? model = NSTModel.FromIgz(modelFile.ToIgzFile());
                if (model == null)
                {
                    Console.WriteLine($"WARNING: Failed to extract model for {modelName}.");
                    continue;
                }

                foreach (NSTMesh mesh in model.Meshes)
                {
                    if (mesh.materialHandle == null) continue;

                    _meshToMaterial.Add(mesh, mesh.materialHandle);
                    materialRefs.Add(mesh.materialHandle);
                }

                models[modelName] = model;
                _cachedModels[modelNameLower] = model;
            }

            // Step 3 : Load materials (+ find textures)

            if (!SKIP_TEXTURES) {

            for (int i = 0; i < materialRefs.Count; i++)
            {
                NamedReference materialRef = materialRefs.ElementAt(i);
                _progressManager.SetProgress("materials", (float)(i+1) / materialRefs.Count, $"Loading materials {i + 1}/{materialRefs.Count}...");

                if (_cachedMaterials.TryGetValue(materialRef, out NSTMaterial? cachedMaterial))
                {
                    materials[materialRef] = cachedMaterial;
                    continue;
                }

                igFxMaterial? matObject = (igFxMaterial?)AlchemyUtils.FindObjectInArchives(materialRef, archive);
                if (matObject == null)
                {
                    Console.WriteLine($"WARNING: Failed to find material file for {materialRef}.");
                    continue;
                }

                NSTMaterial mat = new NSTMaterial(matObject);

                materials.Add(materialRef, mat);
                _cachedMaterials.Add(materialRef, mat);

                NamedReference? textureRef = mat.diffuseTexture;
                if (textureRef != null)
                {
                    if (!_textureToMaterials.ContainsKey(textureRef)) {
                        _textureToMaterials.Add(textureRef, new List<NSTMaterial>());
                    }
                    _textureToMaterials[textureRef].Add(mat);
                }
            }

            // Step 4 : Load textures

            for (int i = 0; i < _textureToMaterials.Count; i++)
            {
                NamedReference textureRef = _textureToMaterials.Keys.ElementAt(i);
                _progressManager.SetProgress("textures", (float)(i+1) / _textureToMaterials.Count, $"Loading textures {i + 1}/{_textureToMaterials.Count}...");

                igImage2? texture = (igImage2?)AlchemyUtils.FindObjectInArchives(textureRef, _archive);
                if (texture == null)
                {
                    Console.WriteLine($"WARNING: Failed to find texture file for {textureRef}.");
                    continue;
                }

                TextureData data = new TextureData()
                {
                    pixels = texture.GetPixels(),
                    width = texture._width,
                    height = texture._height,
                };

                foreach (NSTMaterial mat in _textureToMaterials[textureRef])
                {
                    mat.CreateThreeTexture(data);
                }
            }

            // Step 5 : Assign materials to meshes
            foreach ((NSTMesh mesh, NamedReference materialRef) in _meshToMaterial)
            {
                mesh.Material = materials[materialRef];
            }

            }

            // Step 6 : Assign models to entities
            foreach ((NSTEntity entity, string? modelName) in entities)
            {
                if (string.IsNullOrEmpty(modelName)) continue;

                if (!models.ContainsKey(modelName))
                {
                    Console.WriteLine($"Warning: Model not found ({modelName})");
                    continue;
                }

                entity.Model = models[modelName];
            }

            // (Step 7a) Remove duplicate cloud meshes
            foreach (NSTModel model in models.Values)
            {
                if (model.Meshes.Count > 1 && model.Meshes.All(m => m.Material.type == typeof(CCloudParticleSortedMaterial)))
                {
                    model.Meshes.RemoveRange(1, model.Meshes.Count - 1);
                }
            }

            // (Step 7b) Fix TNT & Nitro colors
            NamedReference tntMatRef = new NamedReference("Crash_Crates_materials,TNTCrate,0000100", "GrayWood");
            NamedReference nitroMatRef = new NamedReference("Crash_Crates_materials,Crash_Crate_Nitro,0000210", "GrayWood01E");

            if (materials.TryGetValue(tntMatRef, out NSTMaterial? tntMat))
            {
                tntMat.color = new THREE.Vector4(.8f, .2f, .1f, 1);
            }
            if (materials.TryGetValue(nitroMatRef, out NSTMaterial? nitroMat))
            {
                nitroMat.color = new THREE.Vector4(.1f, .8f, .2f, 1);
            }

            // Step 8: Find collisions
            foreach (NSTEntity entity in entities.Keys)
            {
                entity.CollisionShapeIndex = _archiveRenderer.FindCollisionShapeIndex(entity.ToReference());
            }

            // Step 9: Add entities to scene
            _instanceManager.Register(_archive, entities.Keys.ToList());

            // Step 10: Add entities to tree
            _treeView = new EntityTreeView(this, _instanceManager.allEntities.Cast<NSTObject>().ToList());// entitiesList.Cast<NSTObject>().ToList());

            Console.WriteLine($"[THREAD] Loaded {entities.Count} entities in {sw.ElapsedMilliseconds}ms");
        }

        public override void Render(double? deltaTime)
        {
            if (!_isOpen) return;

            ImGui.SetNextWindowPos(new System.Numerics.Vector2(0, 0), ImGuiCond.Once, new System.Numerics.Vector2(0, 0));
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(1500, 850), ImGuiCond.Once);

            if (ImGui.Begin(GetWindowName(), ref _isOpen))
            {
                if (!_initializationTask.IsCompleted)
                {
                    _progressManager.Render();
                    ImGui.End();
                    return;
                }

                _controls.SetFocus(ImGui.IsWindowHovered());

                if (ImGui.BeginTable("LevelEditorTable" + GetHashCode(), 2, ImGuiTableFlags.Resizable))
                {
                    ImGui.TableSetupColumn("", ImGuiTableColumnFlags.WidthFixed, 250);
                    ImGui.TableSetupColumn("", ImGuiTableColumnFlags.WidthStretch);
                    ImGui.TableNextColumn();

                    RenderSettingsPanel();

                    ImGui.SeparatorText("Objects");

                    if (ImGui.BeginChild("ObjectTree" + GetHashCode()))
                    {
                        _treeView.Render();
                    }
                    ImGui.EndChild();

                    ImGui.TableNextColumn();

                    var windowSize = ImGui.GetContentRegionAvail();

                    if (_renderer.Width != (int)windowSize.X || _renderer.Height != (int)windowSize.Y)
                    {
                        Resize((int)windowSize.X, (int)windowSize.Y);
                    }

                    base.Render(deltaTime);

                    _renderBounds = DrawImage();

                    ImGui.EndTable();
                }

                HandleInputs();
            }

            ImGui.End();
        }

        public hknpShapeInstance? FindHavokShape(NSTEntity entity)
        {
            if (entity.CollisionShapeIndex == -1) return null;

            // Dictionary<HashedReference, int> collisionData = StaticCollisionsUtils.GetCollisionData(_archive);

            IgArchiveFile file = _archive.FindCollisionFile(".hkx")!;

            HavokFile hkx = file.ToHavokFile();

            hknpStaticCompoundShape compoundShape = (hknpStaticCompoundShape)hkx.GetRootObjects().First(x => x is hknpStaticCompoundShape);

            HashedReference reference = entity.ToReference().ToEXID();

            // int shapeIndex = collisionData[reference];

            return compoundShape._elements[entity.CollisionShapeIndex];
        }

        void HandleInputs()
        {
            if (!_controls.Focused()) return;

            if (ImGui.IsKeyDown(ImGuiKey.LeftCtrl) || ImGui.IsKeyDown(ImGuiKey.RightCtrl))
            {
                _controls.SetFocus(false);
            }

            if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.C))
            {
                _selectionManager.Copy(this);
            }   
            else if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.V))
            {
                const float maxDistance = 5000.0f;
                var intersections = Raycast(THREE.Vector2.Zero(), maxDistance);
                float distance = intersections.Count == 0 ? maxDistance * 0.5f : intersections[0].distance;
                THREE.Vector3 spawnPoint = _camera.Position.Clone().Add(_camera.Front.Clone().MultiplyScalar(distance));
                _selectionManager.Paste(_archiveRenderer, _fileManager, spawnPoint);
            }
            else if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.S))
            {
                _archiveRenderer.TrySaveArchive();
            }
            else if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.E))
            {
                _gizmos.mode = "translate";
            }
            else if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.R))
            {
                _gizmos.mode = "rotate";
            }
            else if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.T))
            {
                _gizmos.mode = "scale";
            }
            else if (ImGui.IsKeyPressed(ImGuiKey.Backspace) || ImGui.IsKeyPressed(ImGuiKey.Delete))
            {
                DeleteSelection();
            }
        }

        private void DeleteSelection()
        {
            if (_selectionManager._selection.Count == 0) return;
            
            List<NSTEntity> selected = _selectionManager._selection.OfType<NSTEntity>().ToList();

            foreach (NSTEntity entity in _selectionManager._selection)
            {
                FileUpdateInfos infos = _fileManager.GetInfos(entity.ArchiveFile)!;
                IgzRenderer? renderer = infos.renderer as IgzRenderer;

                List<igObject> removed = infos.igz!.Remove(entity.Object).ToList();

                foreach (igObject obj in removed)
                {
                    _archiveRenderer.SetObjectUpdated(entity.ArchiveFile, obj);

                    renderer?.TreeView.Remove(obj);

                    if (obj is not igEntity) continue;

                    NSTEntity? removedEntity = _instanceManager.allEntities.Find(x => x.Object == obj);
                    if (removedEntity == null)
                    {
                        Console.WriteLine("Warning: Object not found: " + obj);
                        continue;
                    }

                    if (removedEntity.InstanceManager != null)
                    {
                        removedEntity.InstanceManager.entities.Remove(removedEntity);
                    }

                    _instanceManager.allEntities.Remove(removedEntity);
                }
            }

            _selectionManager.ClearSelection(true);
            _gizmos.Visible = false;

            _treeView.RebuildTree(_instanceManager.allEntities.Cast<NSTObject>().ToList());
        }

        public void RenderSettingsPanel()
        {
            if (ImGui.CollapsingHeader("Settings"))
            {
                ImGui.Text($"FPS: {(_controls.Focused() ? (int)ImGui.GetIO().Framerate : "0")} ({_renderer.Width}x{_renderer.Height})");

                if (ImGui.SliderFloat("Render Distance", ref _camera.Far, 1000.0f, 200000.0f))
                {
                    _scene.Fog.Far = _camera.Far;
                    _camera.UpdateProjectionMatrix();
                }
                // if (ImGui.SliderFloat("FOV", ref _camera.Fov, 30, 100))
                // {
                //     _camera.UpdateProjectionMatrix();
                // }

                if (ImGui.Combo("Debug mode", ref _debugMode, _debugModes, _debugModes.Length))
                {
                    _debugMode = _debugMode % _debugModes.Length;
                    _instanceManager.RefreshInstances(_instanceManager.allEntities.Cast<NSTObject>().ToList());
                }

                ImGui.SeparatorText("Visible camera layers:");

                foreach (KeyValuePair<string, bool> layer in _layers)
                {
                    bool enabled = layer.Value;
                    if (ImGui.Checkbox(layer.Key, ref enabled)) {
                        _layers[layer.Key] = enabled;
                        UpdateCameraLayers();
                    }
                }
            }

            if (ImGui.CollapsingHeader("Controls"))
            {
                ImGui.BulletText("W,A,S,D: move camera");
                ImGui.BulletText("Right click: rotate camera");
                ImGui.Separator();
                ImGui.BulletText("Left click: select object");
                ImGui.BulletText("(Click twice to focus child objects)");
                ImGui.BulletText("Shift + Left click: add to selection");
                ImGui.Separator();
                ImGui.BulletText("Ctrl + C: copy selected objects");
                ImGui.BulletText("Ctrl + V: paste selected objects");
                ImGui.BulletText("Del/Suppr: delete selected objects");
            }
        }

        private void UpdateCameraLayers()
        {
            for (int i = 0; i < _layers.Count; i++)
            {
                if (_layers.Values.ElementAt(i) == true) 
                {
                    _camera.Layers.Enable(i+1);
                }
                else 
                {
                    _camera.Layers.Disable(i+1);
                }
            }
        }

        public THREE.Vector2 GetClipSpaceMousePos(THREE.Silk.MouseEventArgs e)
        {
            float x = (e.X - _renderBounds.X) / _renderBounds.Z;
            float y = (e.Y - _renderBounds.Y) / _renderBounds.W;

            return new THREE.Vector2(x * 2.0f - 1.0f, y * 2.0f - 1.0f);
        }

        public void FocusObject(igObject igObj)
        {
            NSTObject? obj = _instanceManager.Find(igObj);
            if (obj == null)
            {
                Console.WriteLine("Warning: Object not found: " + igObj);
                return;
            }

            SelectObject(obj);

            _treeView.SelectObject(obj);

            if (obj.Object3D == null)
            {
                Console.WriteLine("Warning: Object3D is null");
                return;
            }

            THREE.Vector3 worldPos = obj.Object3D.GetWorldPosition(new THREE.Vector3());

            _camera.Position.Copy(worldPos + new THREE.Vector3(0, -200, 200));
            _camera.LookAt(worldPos);
            _camera.UpdateProjectionMatrix();
            _controls.LookAt(worldPos);
        }

        public void SelectObject(NSTObject obj)
        {
            List<NSTObject> selected = _instanceManager.Select(obj, true);
            _selectionManager.UpdateSelection(selected);
        }

        private List<THREE.Intersection> Raycast(THREE.Vector2 mouseClipSpace, float distance)
        {
            if (mouseClipSpace.X < -1 || mouseClipSpace.X > 1 || mouseClipSpace.Y < -1 || mouseClipSpace.Y > 1) return [];

            _camera.UpdateMatrixWorld();
            
            THREE.Raycaster raycaster = new THREE.Raycaster(_camera.Position, _camera.Front, _camera.Near, distance);
            THREE.Vector2 mouse = new THREE.Vector2(-mouseClipSpace.X, mouseClipSpace.Y);

            raycaster.SetFromCamera(mouse, _camera);
            
            for (int i = 0; i < _layers.Count; i++)
            {
                if (_layers.Values.ElementAt(i) == true) 
                {
                    raycaster.layers.Enable(i+1);
                }
                else 
                {
                    raycaster.layers.Disable(i+1);
                }
            }

            return raycaster.IntersectObject(_instanceManager._rootObject, true);
        }

        private void SelectFromRaycast(List<THREE.Intersection> intersects) 
        {
            List<NSTObject> hitEntities = [];

            foreach (THREE.Intersection intersect in intersects)
            {
                hitEntities = _instanceManager.SelectFromRaycast(intersect);
                if (hitEntities.Count > 0) break;
            }

            if (hitEntities.Count == 0) 
            {
                Console.WriteLine("No hit");
                _selectionManager.ClearSelection(true);
                _gizmos.Visible = false;
                return;
            }

            bool newSelection = !ImGui.IsKeyDown(ImGuiKey.LeftShift);

            _selectionManager.UpdateSelection(hitEntities, newSelection);

            _treeView.SelectObject(hitEntities[0]);
        }
    }
}