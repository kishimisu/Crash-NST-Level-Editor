using Alchemy;
using Havok;
using ImGuiNET;
using System.Diagnostics;

namespace NST
{
    public class LevelExplorer : ThreeSceneRenderer
    {
        private static Dictionary<string, NSTModel> _cachedModels = [];
        private static Dictionary<NamedReference, NSTMaterial> _cachedMaterials = [];

        public static Dictionary<string, NSTModel> CachedModels { get; private set; }
        public static List<string> CachedModelNames { get; private set; }
        private bool _updateCachedModels = true;

        public Dictionary<igComponentData, List<NSTEntity>> CachedComponents { get; } = [];

        public IgArchiveRenderer ArchiveRenderer { get; private set; }
        public IgArchive Archive => ArchiveRenderer.Archive;

        public InstancedMeshManager InstanceManager { get; private set; }
        public SelectionManager SelectionManager { get; private set; }
        public ActiveFileManager FileManager => ArchiveRenderer.FileManager;
        public THREE.Camera Camera => _camera;

        public bool IsWindowFocused { get; private set; } = false;
        public bool IsSceneFocused { get; private set; } = false;

        private EntityTreeView _treeView;
        private Dictionary<HashedReference, int> _collisionData = [];
        private THREE.Silk.TransformControls _gizmos;
        private System.Numerics.Vector4 _renderBounds = new System.Numerics.Vector4();

        private IgArchiveFile? _zoneInfoFile;
        private CZoneInfo? _zoneInfo;
        private int _crashMode = 0;
        private int _defaultCharacter = 0;

        private Task _initializationTask;
        private ProgressManager _progressManager = new ProgressManager();

        public enum DebugMode { None = 0, Collisions = 1, Prefabs = 2, GameObjects = 3, Instanced = 4 };
        private readonly string[] _debugModes = ["None", "Static Collisions", "Prefabs", "Game Objects"];
        
        public enum CameraLayer 
        { 
            Default = 0, 
            AllEntities = 1, 
            Splines = 2, 
            ClipEntities = 3,
            Camera = 4, 
            CameraBox = 5,
            Triggers = 6, 
            Templates = 7, 
            Clouds = 8, 
            Shadows = 9, 
            Hidden = 10
        };

        private readonly Dictionary<string, bool> _layers = new()
        {
            { "All Entities", true },
            { "Splines", true },
            { "DynamicClipEntity", true },
            { "Camera", false },
            { "CameraBox", false },
            { "ScriptTriggerEntity", false },
            { "Templates", false },
            { "Clouds", false },
            { "Shadows", false },
            { "Hidden", false },
        };

        public DebugMode DebugRenderMode => (DebugMode)_debugMode;
        private int _debugMode = 0;

        public bool IsOpen = true;
        public bool ReOpen = false;
        private bool _isDragging = false;
        private bool _clickInsideScene = false;
        private bool _openContextMenu = false;
        private static bool _clearMemoryOnExit = false;
        
        public string GetWindowName() => (ArchiveRenderer?.Archive.GetName(false) ?? "Creating new level...") + "##" + GetHashCode();
        public void RebuildTree() => _treeView.RebuildTree(InstanceManager.AllObjects);

        /// <summary>
        /// Constructor used when creating a new level
        /// </summary>
        public LevelExplorer(string baseLevel, string level, string musicLevel, int crashMode) : base(useEffectComposer: true, alwaysRender: false)
        {
            Init();

            _initializationTask = Task.Run(() => 
            {
                IgArchive archive = LevelBuilder.CreateLevel(baseLevel, level, musicLevel, crashMode, _progressManager);

                ArchiveRenderer = new IgArchiveRenderer(archive);
                ArchiveRenderer.IsUpdated = true;
                ArchiveRenderer.ForceSaveAs = true;
                ArchiveRenderer.IsOpen = false;

                LoadEntities();
            })
            .ContinueWith(t =>
            {
                if (t.IsFaulted && t.Exception != null)
                {
                    foreach (var ex in t.Exception.InnerExceptions)
                    {
                        CrashHandler.Log($"Error loading entities: {ex.Message}\n{ex.StackTrace}");
                    }
                    string logPath = CrashHandler.WriteLogsToFile();
                    ModalRenderer.ShowMessageModal("Error", $"An error occured while loading the scene\n\nLog file: {logPath}");
                    IsOpen = false;
                }
            }, TaskContinuationOptions.OnlyOnFaulted);        
        }

        /// <summary>
        /// Constructor used when opening an existing level
        /// </summary>
        public LevelExplorer(IgArchiveRenderer archiveRenderer, igObject? objToFocus = null) : base(useEffectComposer: true, alwaysRender: false)
        {
            ArchiveRenderer = archiveRenderer;

            Init();

            _initializationTask = Task.Run(() => 
            {
                LoadEntities();

                if (objToFocus != null)
                {
                    Focus(objToFocus);
                }
            })
            .ContinueWith(t =>
            {
                if (t.IsFaulted && t.Exception != null)
                {
                    foreach (var ex in t.Exception.InnerExceptions)
                    {
                        CrashHandler.Log($"Error loading entities: {ex.Message}\n{ex.StackTrace}");
                    }
                    string logPath = CrashHandler.WriteLogsToFile();
                    ModalRenderer.ShowMessageModal("Error", $"An error occured while loading the scene. Log saved to:\n\n{logPath}");
                    IsOpen = false;
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
        }

        private void Init()
        {
            InitScene();

            _clearMemoryOnExit = LocalStorage.Get("clear_memory_on_exit", false);

            KeyDown   += (_, e) => _isDragging = _clickInsideScene;
            MouseMove += (_, e) => _isDragging = true;
            MouseDown += (_, e) => { _isDragging = false; _clickInsideScene = IsSceneFocused; };
            MouseUp   += (_, e) =>
            {
                if (IsSceneFocused && !_isDragging)
                {
                    if (e.Button == Silk.NET.Input.MouseButton.Left)
                    {
                        var mouse = GetClipSpaceMousePos(e);
                        if (mouse == null) return;
                        var intersections = Raycast(mouse, _camera.Far);
                        SelectFromRaycast(intersections);
                    }
                    else
                    {
                        _openContextMenu = true;
                        (_controls as FirstPersonControls)?.ResetMousePos();
                    }
                }

                _clickInsideScene = false;
                _isDragging = false;
            };
        }

        private void InitScene()
        {
            _camera.Near = 10.0f;
            _camera.Far = 120000.0f;
            _scene.Fog.Far = _camera.Far;
            _camera.UpdateProjectionMatrix();

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
                SelectionManager.ApplyChanges(FileManager, ArchiveRenderer);
            };

            foreach ((string layerName, bool active) in _layers)
            {
                _layers[layerName] = LocalStorage.Get("layer_" + layerName, active);
            }
            UpdateActiveLayers(_camera.Layers);
            
            _scene.Add(_gizmos);

            _outlinePass.gizmos = _gizmos;

            InstanceManager = new InstancedMeshManager(this, _scene);

            SelectionManager = new SelectionManager(InstanceManager.RootObject, _gizmos, _outlinePass, this);

            SilkWindow.instance.RestoreViewport();
        }

        private void LoadZoneInfo()
        {
            _zoneInfoFile = Archive.FindCustomZoneInfoFile();

            if (_zoneInfoFile != null)
            {
                IgzFile zoneInfoIgz = _zoneInfoFile.ToIgzFile();
                FileManager.Add(_zoneInfoFile, zoneInfoIgz, true);

                _zoneInfo = zoneInfoIgz.FindObject<CZoneInfo>();
                _crashMode = _zoneInfo?._year == EGameYear.eGY_2017_Crash1 ? 0 : _zoneInfo?._year == EGameYear.eGY_2017_Crash3 ? 2 : 1;
                _defaultCharacter = int.Max(0, LevelBuilder.CrashCharacters.ToList().IndexOf(_zoneInfo?._overrideCharacter ?? ""));
            }
        }

        private void LoadEntities()
        {
            LoadZoneInfo();

            Stopwatch sw = Stopwatch.StartNew();
            
            Dictionary<NSTEntity, string?> entities = [];
            List<NSTObject> objects = [];

            HashSet<(string, string)> modelNames = [];

            // Step 1: Find entities (+ model names)

            List<IgArchiveFile> mapFiles = Archive.GetFiles()
                .Where( f => f.GetPath().StartsWith("maps/") && f.GetPath().EndsWith(".igz") 
                             && !f.GetName().Contains("LegacyCamera") && ArchiveRenderer.IncludeInPackageFile(f) )
                .ToList();

            for (int i = 0; i < mapFiles.Count; i++)
            {
                IgArchiveFile mapFile = mapFiles[i];
                IgzFile igz = FileManager.GetIgz(mapFile) ?? mapFile.ToIgzFile();

                _progressManager.SetProgress("entities", (float)(i+1) / mapFiles.Count, $"Loading entity files {i + 1}/{mapFiles.Count}...");

                bool entityAdded = false;

                foreach (igObject obj in igz.Objects)
                {
                    if (obj is CCameraBox cameraBox)
                    {
                        objects.Add(new NSTCameraBox(cameraBox, mapFile));
                        entityAdded = true;
                        continue;
                    }
                    if (obj is CCamera camera)
                    {
                        objects.Add(new NSTCamera(camera, mapFile));
                        entityAdded = true;
                        continue;
                    }

                    if (obj is not igEntity entity) continue;

                    string? modelPath = entity.GetModelName(igz, this);
                    string? modelName = Path.GetFileNameWithoutExtension(modelPath);

                    NSTEntity entity3D = new NSTEntity(entity, mapFile);

                    // Camera starting position
                    if (entity is CPlayerStartEntity) 
                    {
                        THREE.Vector3 camPos = entity3D.Position + new THREE.Vector3(0, -1000, 200);
                        _camera.Position.Set(camPos.X, camPos.Y, camPos.Z);
                        _controls.LookAt(_camera.Position + new THREE.Vector3(0, 1, 0));
                    }

                    entities.Add(entity3D, modelName);
                    entityAdded = true;
                    
                    if (modelPath != null && modelName != null) {
                        modelNames.Add((modelName, modelPath));
                    }
                }

                if (entityAdded)
                {
                    FileManager.Add(mapFile, igz, true);
                }
            }

            // Steps 2-7: load models, materials & textures
            LoadModels(entities, modelNames, true);

            // Step 8: Add objects to scene
            InstanceManager.Register(entities.Keys.Cast<NSTObject>().Union(objects).ToList());

            // Step 9: Find collisions
            LoadCollisions(InstanceManager.AllEntities);

            // Step 10: Add objects to tree
            _treeView = new EntityTreeView(this, InstanceManager.AllObjects);

            Console.WriteLine($"[THREAD] Loaded {entities.Count} entities in {sw.ElapsedMilliseconds}ms");
        }

        private void LoadModels(Dictionary<NSTEntity, string?> entities, HashSet<(string, string)> modelNames, bool progressBar = false)
        {
            Dictionary<string, NSTModel> models = [];

            Dictionary<NamedReference, NSTMaterial> materials = [];
            HashSet<NamedReference> materialRefs = [];

            Dictionary<NSTMesh, NamedReference> _meshToMaterial = [];
            Dictionary<NamedReference, List<NSTMaterial>> _textureToMaterials = [];

            // Step 2 : Load models (+ find meshes and materials)

            for (int i = 0; i < modelNames.Count; i++)
            {
                (string modelName, string modelPath) = modelNames.ElementAt(i);
                string modelNameLower = modelName.ToLowerInvariant();
                if (progressBar) _progressManager.SetProgress("models", (float)(i+1) / modelNames.Count, $"Loading models {i + 1}/{modelNames.Count}...");

                if (_cachedModels.TryGetValue(modelNameLower, out NSTModel? cachedModel))
                {
                    models[modelName] = cachedModel;
                    continue;
                }

                IgArchiveFile? modelFile = Archive.GetFiles().Find(f =>
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

                model.OriginalPath = modelPath;
                model.FilePath = modelFile.GetPath();

                models[modelName] = model;
                _cachedModels[modelNameLower] = model;
            }

            // Step 3 : Load materials (+ find textures)

            for (int i = 0; i < materialRefs.Count; i++)
            {
                NamedReference materialRef = materialRefs.ElementAt(i);
                if (progressBar) _progressManager.SetProgress("materials", (float)(i+1) / materialRefs.Count, $"Loading materials {i + 1}/{materialRefs.Count}...");

                if (_cachedMaterials.TryGetValue(materialRef, out NSTMaterial? cachedMaterial))
                {
                    materials[materialRef] = cachedMaterial;
                    continue;
                }

                igFxMaterial? matObject = (igFxMaterial?)AlchemyUtils.FindObjectInArchives(materialRef, Archive);
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
                if (progressBar) _progressManager.SetProgress("textures", (float)(i+1) / _textureToMaterials.Count, $"Loading textures {i + 1}/{_textureToMaterials.Count}...");

                try 
                {
                    igImage2 texture = (igImage2)AlchemyUtils.FindObjectInArchives(textureRef, Archive);

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
                catch (Exception e)
                {
                    Console.WriteLine($"Warning: failed to find texture {textureRef}:\n{e.Message}\n{e.StackTrace}");
                }
            }

            // Step 5 : Assign materials to meshes
            foreach ((NSTMesh mesh, NamedReference materialRef) in _meshToMaterial)
            {
                mesh.Material = materials[materialRef];
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
            // Remove ghost mesh from the checkpoint crate
            if (models.TryGetValue("Crash_Crate_Checkpoint", out NSTModel? checkpointModel) && checkpointModel.Meshes.Count > 10)
            {
                checkpointModel.Meshes.RemoveAt(0);
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
        }

        private void LoadCollisions(List<NSTEntity> entities)
        {
            _collisionData = StaticCollisionsUtils.GetCollisionData(Archive);

            IgArchiveFile? collisionFile = Archive.FindCollisionFile(".hkx");
            if (collisionFile == null) return;

            Dictionary<HashedReference, NSTEntity> entityReferences = entities
                .Where(e => !e.IsPrefabTemplate)
                .DistinctBy(x => x.ToReference())
                .ToDictionary(x => x.ToReference().ToEXID(), x => x);

            Dictionary<uint, List<(HashedReference, int)>> prefabReferences = [];

            // Setup regular collisions
            foreach ((HashedReference reference, int index) in _collisionData)
            {
                if (entityReferences.TryGetValue(reference, out NSTEntity? entity))
                {
                    entity.CollisionShapeIndex = index;
                }
                else
                {
                    if (!prefabReferences.ContainsKey(reference.fileHash))
                    {
                        prefabReferences.Add(reference.fileHash, []);
                    }
                    prefabReferences[reference.fileHash].Add((reference, index));
                }
            }

            // Find prefab collisions
            HavokFile hkx = collisionFile.ToHavokFile();
            hknpStaticCompoundShape? compoundShape = (hknpStaticCompoundShape?)hkx.GetRootObjects().Find(x => x is hknpStaticCompoundShape);
            if (compoundShape == null)
            {
                Console.WriteLine("Warning: Failed to find collision compound shape.");
                return;
            }

            foreach ((uint fileHash, List<(HashedReference, int)> references) in prefabReferences)
            {
                IgArchiveFile? file = Archive.FindFile(fileHash.ToString(), FileSearchType.NamespaceHash);
                if (file == null)
                {
                    Console.WriteLine($"Warning: Failed to find collision file for {fileHash}.");
                    continue;
                }

                var prefabTemplateInstances = InstanceManager.PrefabTemplates.Values
                    .Where(e => e.FileNamespace == file.GetName(false))
                    .SelectMany(e => e.PrefabTemplateInstances);

                foreach ((HashedReference reference, int index) in references)
                {
                    hknpShapeInstance instance = compoundShape._elements[index];
                    THREE.Vector3 havokPosition = new THREE.Vector3(instance._transform.M41, instance._transform.M42, instance._transform.M43);
                    bool found = false;

                    foreach (NSTEntity entity in prefabTemplateInstances)
                    {
                        THREE.Vector3 entityPosition = new THREE.Vector3();
                        entity.ObjectToWorld().Decompose(entityPosition, new THREE.Quaternion(), new THREE.Vector3());

                        float distance = havokPosition.DistanceTo(entityPosition * 0.0254f);
                        
                        if (distance < 0.01f)
                        {
                            entity.CollisionPrefabHash = reference.objectHash;
                            entity.CollisionShapeIndex = index;

                            found = true;
                            // Console.WriteLine($"Found prefab collision shape: {entity.ParentPrefabInstance?.Object.ObjectName} -> {entity.Object.ObjectName} (index: {index}, dist: {distance}, hash: {reference})");
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"Warning: Failed to find collision shape for {reference} in {file.GetName()}");
                    }
                }
            }
        }

        public hknpShapeInstance? FindHavokShape(NSTEntity entity)
        {
            if (entity.CollisionShapeIndex == -1) return null;

            IgArchiveFile file = Archive.FindCollisionFile(".hkx")!;

            HavokFile hkx = file.ToHavokFile();

            hknpStaticCompoundShape compoundShape = (hknpStaticCompoundShape)hkx.GetRootObjects().First(x => x is hknpStaticCompoundShape);

            return compoundShape._elements[entity.CollisionShapeIndex];
        }

        private void PasteObjects(bool keepOriginalPosition = false, bool moveSelection = false)
        {
            const float maxDistance = 5000.0f;
            THREE.Vector3? spawnPoint = null;

            moveSelection &= SelectionManager.CopyFromSameFile();

            // Raycast to find spawn point
            if (!keepOriginalPosition || moveSelection)
            {
                var intersections = Raycast(THREE.Vector2.Zero(), maxDistance);
                float distance = intersections.Count == 0 ? maxDistance * 0.5f : intersections[0].distance;
                spawnPoint = _camera.Position.Clone().Add(_camera.Front.Clone().MultiplyScalar(distance));

                if (moveSelection)
                {
                    SelectionManager._selectionContainer.Position.Copy(spawnPoint);
                    SelectionManager.ApplyChanges(FileManager, ArchiveRenderer);
                    return;
                }
            }

            // Paste selection
            SelectionManager.Paste(ArchiveRenderer, FileManager, spawnPoint, (NSTObject? newObject) =>
            {
                _treeView.RebuildTree(InstanceManager.AllObjects);

                if (newObject != null)
                {
                    _treeView.SelectObject(newObject);
                }
            });
        }

        private void DeleteSelection()
        {
            if (SelectionManager._selection.Count == 0) return;
            
            HashSet<NSTObject> deleted = [];
            Dictionary<NSTSpline, List<NSTObject>> splines = [];

            foreach (NSTObject selected in SelectionManager._selection)
            {
                // Special cases for spline children
                if (selected is NSTSplineControlPoint cp)
                {
                    if (!splines.ContainsKey(cp.Parent)) splines[cp.Parent] = [];
                    splines[cp.Parent].Add(selected);
                    continue;
                }
                if (selected is NSTSplineRotationKeyFrame kf)
                {
                    if (!splines.ContainsKey(kf.Parent)) splines[kf.Parent] = [];
                    splines[kf.Parent].Add(selected);
                    continue;
                }
                if (selected is NSTSplineMarker marker)
                {
                    if (!splines.ContainsKey(marker.Parent)) splines[marker.Parent] = [];
                    splines[marker.Parent].Add(selected);
                    continue;
                }

                // Special cases for prefab children
                if (selected is NSTEntity entity && entity.IsPrefabChild)
                {
                    if (entity.ParentPrefabInstance!.IsSelected) continue;
                    if (SelectionManager._selection.Where(o => o is NSTEntity e && e.PrefabTemplate == entity.PrefabTemplate).ToList().IndexOf(entity) > 0) continue;
                }

                FileUpdateInfos infos = FileManager.GetInfos(selected.ArchiveFile)!;

                List<igObject> removed = infos.igz!.Remove(selected.GetObject()).ToList();

                foreach (igObject obj in removed)
                {
                    ArchiveRenderer.SetObjectUpdated(selected.ArchiveFile, obj, true);

                    if (InstanceManager.AllReferences.TryGetValue(obj.ToNamedReference(infos.file.GetName(false)), out NSTObject? removedObject))
                    {
                        InstanceManager.Unregister(removedObject);

                        deleted.Add(removedObject);

                        if (removedObject is NSTEntity removedEntity)
                        {
                            // Special cases for prefab children
                            if (removedEntity.IsPrefabInstance)
                            {
                                foreach (NSTEntity prefabChild in removedEntity.Children.OfType<NSTEntity>())
                                {
                                    if (prefabChild.ParentPrefabInstance == removedEntity)
                                    {
                                        prefabChild.PrefabTemplate!.PrefabTemplateInstances.Remove(prefabChild);
                                        prefabChild.PrefabTemplate.PrefabTemplateInstances.ForEach(e => e.Parents.Remove(removedEntity));
                                        InstanceManager.Unregister(prefabChild);
                                    }
                                }
                            }
                            else if (removedEntity.IsPrefabChild)
                            {
                                removedEntity.PrefabTemplate!.PrefabTemplateInstances.Remove(removedEntity);
                                removedEntity.PrefabTemplate.PrefabTemplateInstances.ForEach(e => InstanceManager.Unregister(e));
                            }

                            if (removedEntity.CollisionShapeIndex != -1)
                            {
                                ArchiveRenderer.SetEntityUpdated(removedEntity, removed: true);
                            }

                            removedEntity.Components?.RefreshComponents(this);
                        }
                    }
                }
            }

            InstanceManager.RefreshInstances(deleted.ToList());

            // Delete splines children
            foreach ((NSTSpline spline, List<NSTObject> objects) in splines)
            {
                spline.DeleteObjects(this, objects);
            }

            // Update selection
            if (splines.Count > 0 && SelectionManager._selection[0] is NSTSplineControlPoint scp)
            {
                SelectionManager.UpdateSelection([scp.Parent.Parent], true);
            }
            else if (splines.Count > 0 && SelectionManager._selection[0] is NSTSplineRotationKeyFrame kf)
            {
                SelectionManager.UpdateSelection([kf.Parent.Parent], true);
            }
            else if (splines.Count > 0 && SelectionManager._selection[0] is NSTSplineMarker marker)
            {
                SelectionManager.UpdateSelection([marker.Parent.Parent], true);
            }
            else
            {
                SelectionManager.ClearSelection();
                _gizmos.Visible = false;
            }

            _treeView.RebuildTree(InstanceManager.AllObjects);
        }

        public override void Render(double? deltaTime)
        {
            if (!IsOpen)
            {
                if (ArchiveRenderer.IsUpdated && !ArchiveRenderer.IsOpen)
                {
                    ModalRenderer.ShowWarningModal($"Are you sure you want to close {Archive.GetName()} without saving?", () => { ArchiveRenderer.IsUpdated = false; IsOpen = false; });
                    IsOpen = true;
                }
                else
                {
                    App.CloseExplorer(this);
                    return;
                }
            }

            ImGui.SetNextWindowPos(new System.Numerics.Vector2(0, 0), ImGuiCond.Once, new System.Numerics.Vector2(0, 0));
            ImGui.SetNextWindowSize(ImGui.GetIO().DisplaySize, ImGuiCond.Once);

            ImGuiWindowFlags flags = ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoSavedSettings;

            if (ArchiveRenderer?.IsUpdated == true) flags |= ImGuiWindowFlags.UnsavedDocument;

            if (ImGui.Begin(GetWindowName(), ref IsOpen, flags))
            {
                if (!_initializationTask.IsCompleted)
                {
                    _progressManager.Render();
                    ImGui.End();
                    return;
                }
                else if (_updateCachedModels)
                {
                    CachedModels = _cachedModels.ToDictionary();
                    CachedModelNames = _cachedModels.Values.Select(e => e.Name).ToList();
                    CachedModelNames.Sort();
                    _updateCachedModels = false;
                }

                ArchiveRenderer?.RenderMenuBar(true);

                IsWindowFocused = _isDragging | ImGui.IsWindowHovered(ImGuiHoveredFlags.ChildWindows);

                if (ImGui.BeginTable("LevelEditorTable" + GetHashCode(), 3, ImGuiTableFlags.Resizable))
                {
                    ImGui.TableSetupColumn("", ImGuiTableColumnFlags.WidthFixed, 250);
                    ImGui.TableSetupColumn("", ImGuiTableColumnFlags.WidthStretch);
                    ImGui.TableSetupColumn("", ImGuiTableColumnFlags.WidthFixed, 350);
                    ImGui.TableNextColumn();

                    // ImGui.Text($"IsWindowFocused: {IsWindowFocused} IsSceneFocused: {IsSceneFocused} IsDragging: {_isDragging} ClickInsideScene: {_clickInsideScene}");

                    RenderSettingsPanel();

                    if (ImGui.BeginChild("ObjectTree" + GetHashCode()))
                    {
                        _treeView.Render();
                    }
                    ImGui.EndChild();

                    ImGui.TableNextColumn();

                    var canvasSize = ImGui.GetContentRegionAvail();

                    if (_width != (int)canvasSize.X || _height != (int)canvasSize.Y)
                    {
                        Resize((int)canvasSize.X, (int)canvasSize.Y);
                    }

                    base.Render(deltaTime);

                    if (RebuildState == RebuildStatus.None)
                    {
                        _renderBounds = DrawImage();
                        IsSceneFocused = ImGui.IsItemHovered();
                    }
                    else if (RebuildState == RebuildStatus.NeedsRebuild)
                    {
                        _renderBounds = new System.Numerics.Vector4(0, 0, _width, _height);
                        
                        if (ImGui.TableGetHoveredColumn() == 1 && ImGui.IsMouseClicked(ImGuiMouseButton.Left))
                        {
                            RebuildState = RebuildStatus.Rebuild;
                            RenderNextFrame = true;
                        }
                        else
                        {
                            ImGuiUtils.CenteredText("Memory cleared, click to reload the scene");
                        }
                    }
                    
                    if (RebuildState == RebuildStatus.Rebuild)
                    {
                        ImGuiUtils.CenteredText("Reloading scene, please wait...");
                    }

                    _controls.SetFocus(IsSceneFocused || _clickInsideScene);

                    if (_openContextMenu)
                    {
                        ImGui.OpenPopup("ObjectFactoryContextMenu");
                        _openContextMenu = false;
                    }
                    ObjectFactory.RenderContextMenu(this);

                    ImGui.TableNextColumn();

                    if (ImGui.BeginChild("ObjectProperties" + GetHashCode()))
                    {
                        if (SelectionManager._selection.Count > 0)
                        {
                            if (SelectionManager._selection[0] is NSTSplineControlPoint cp)
                            {
                                cp.Parent.Parent.Render(this);
                            }
                            else if (SelectionManager._selection[0] is NSTSplineRotationKeyFrame kf)
                            {
                                kf.Parent.Parent.Render(this);
                            }
                            else if (SelectionManager._selection[0] is NSTSplineMarker marker)
                            {
                                marker.Parent.Parent.Render(this);
                            }
                            else if (SelectionManager._selection[0] is NSTWaypoint waypoint)
                            {
                                waypoint.Parent.Render(this);
                            }
                            else
                            {
                                SelectionManager._selection[0].Render(this);
                            }
                        }
                    }
                    ImGui.EndChild();

                    ImGui.EndTable();
                }

                HandleInputs();
            }

            ImGui.End();
        }

        void HandleInputs()
        {
            if (!IsWindowFocused) return;

            if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.S))
            {
                ArchiveRenderer.TrySaveArchive(false, true);
                LoadCollisions(InstanceManager.AllEntities);
            }
            else if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.L))
            {
                ArchiveRenderer.TrySaveArchive(true, true);
                LoadCollisions(InstanceManager.AllEntities);
            }
            else if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.ModShift | ImGuiKey.S))
            {
                ArchiveRenderer.SaveArchive(true);
                LoadCollisions(InstanceManager.AllEntities);
            }
            else if (!IsSceneFocused) return;

            if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.C))
            {
                if (SelectionManager.Copy(this))
                {
                    THREE.Color prev = new THREE.Color().Copy(_outlinePass.visibleEdgeColor);
                    _outlinePass.visibleEdgeColor.SetRGB(1.0f, 0.25f, 0.0f);
                    Task.Delay(250).ContinueWith(_ => _outlinePass.visibleEdgeColor.Copy(prev));
                }
            }   
            else if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.V))
            {
                PasteObjects();
            }
            else if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.ModShift | ImGuiKey.V))
            {
                PasteObjects(keepOriginalPosition: true);
            }
            else if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.ModShift | ImGuiKey.X))
            {
                PasteObjects(moveSelection: true);
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
            else if (ImGui.IsKeyPressed(ImGuiKey.Escape))
            {
                SelectionManager.ClearSelection(true);
                _gizmos.Visible = false;
            }
        }
        
        private void RenderSettingsPanel()
        {
            const uint levelColor = 0xffcc66;
            const uint editorColor = 0x88ff22;
            const uint controlsColor = 0x00bbff;

            if (_zoneInfo != null && _zoneInfoFile != null && ImGui.CollapsingHeader("Level infos"))
            {
                ImGui.PushItemWidth(-1);
                ImGuiUtils.ColoredSeparator("Level name", levelColor);

                ImGuiUtils.Prefix("Name:");
                if (ImGui.InputText("##levelName", ref _zoneInfo._displayName, 256)) ArchiveRenderer.SetObjectUpdated(_zoneInfoFile, _zoneInfo);

                ImGuiUtils.Prefix("Hint:");
                if (ImGui.InputText("##levelHint", ref _zoneInfo._hint, 256)) ArchiveRenderer.SetObjectUpdated(_zoneInfoFile, _zoneInfo);

                ImGuiUtils.ColoredSeparator("Level settings", levelColor);
                ImGuiUtils.Prefix("Character: ");
                if (ImGui.Combo("##defaultCharacter", ref _defaultCharacter, LevelBuilder.CrashCharacters, LevelBuilder.CrashCharacters.Length))
                {
                    _zoneInfo._overrideCharacter = LevelBuilder.CrashCharacters[_defaultCharacter];
                    ArchiveRenderer.SetObjectUpdated(_zoneInfoFile, _zoneInfo);
                }

                ImGuiUtils.Prefix("Crash Mode:");
                if (ImGui.Combo("##crashMode", ref _crashMode, LevelBuilder.CrashModes, LevelBuilder.CrashModes.Length))
                {
                    _zoneInfo._year = LevelBuilder.GetGameYear(_crashMode);
                    ArchiveRenderer.SetObjectUpdated(_zoneInfoFile, _zoneInfo);
                }

                ImGuiUtils.ColoredSeparator("Time trial", levelColor);
                
                ImGuiUtils.Prefix("Platinum time:", 110);
                if (ImGui.InputFloat("##platinumTime", ref _zoneInfo._platinumTime)) ArchiveRenderer.SetObjectUpdated(_zoneInfoFile, _zoneInfo);
                
                ImGuiUtils.Prefix("Gold time:", 110);
                if (ImGui.InputFloat("##goldTime", ref _zoneInfo._goldTime)) ArchiveRenderer.SetObjectUpdated(_zoneInfoFile, _zoneInfo);
                
                ImGuiUtils.Prefix("Sapphire time:", 110);
                if (ImGui.InputFloat("##sapphireTime", ref _zoneInfo._sapphireTime)) ArchiveRenderer.SetObjectUpdated(_zoneInfoFile, _zoneInfo);

                ImGui.PopItemWidth();
                ImGui.Spacing();
            }

            if (ImGui.CollapsingHeader("Editor settings"))
            {
                ImGui.Spacing();
                ImGui.Text($"FPS: {(_controls.Focused() ? (int)ImGui.GetIO().Framerate : "0")}" + (_renderer == null ? "" : $" ({_renderer.Width}x{_renderer.Height})"));
                ImGui.Spacing();

                ImGui.PushItemWidth(-1);

                ImGuiUtils.Prefix("Free memory on close:");
                if (ImGui.Checkbox("##clearMemory", ref _clearMemoryOnExit))
                {
                    LocalStorage.Set("clear_memory_on_exit", _clearMemoryOnExit);
                }

                ImGuiUtils.ColoredSeparator("Render settings", editorColor);

                ImGuiUtils.Prefix("Render distance:");
                if (ImGui.SliderFloat("##renderDistance", ref _camera.Far, 4000, 200000, $"%.0f"))
                {
                    _scene.Fog.Far = _camera.Far;
                    _camera.UpdateProjectionMatrix();
                    RenderNextFrame = true;
                }
                // if (ImGui.SliderFloat("FOV", ref _camera.Fov, 30, 100))
                // {
                //     _camera.UpdateProjectionMatrix();
                // }

                ImGuiUtils.Prefix("Debug mode:");
                if (ImGui.Combo("##debugMode", ref _debugMode, _debugModes, _debugModes.Length))
                {
                    _debugMode = _debugMode % _debugModes.Length;
                    InstanceManager.RefreshInstances(InstanceManager.AllEntities.Cast<NSTObject>().ToList());
                    RenderNextFrame = true;
                }

                ImGui.PopItemWidth();

                ImGuiUtils.ColoredSeparator("Visible camera layers", editorColor);

                foreach (KeyValuePair<string, bool> layer in _layers)
                {
                    bool enabled = layer.Value;
                    if (ImGui.Checkbox(layer.Key, ref enabled)) {
                        _layers[layer.Key] = enabled;
                        RenderNextFrame = true;
                        UpdateActiveLayers(_camera.Layers);
                        LocalStorage.Set("layer_" + layer.Key, enabled);
                    }
                }
                ImGui.Spacing();
            }

            if (ImGui.CollapsingHeader("Controls"))
            {
                ImGuiUtils.ColoredSeparator("Camera", controlsColor);
                ImGui.BulletText("W,A,S,D: move camera");
                ImGui.BulletText("Right click: rotate camera");
                ImGui.BulletText("Shift: move faster");
                ImGuiUtils.ColoredSeparator("Selection", controlsColor);
                ImGui.BulletText("Left click: select object");
                ImGui.BulletText("(Click multiple times focus child objects)");
                ImGui.BulletText("Shift + Left click: add/remove from selection");
                ImGui.BulletText("Left Alt: align/snap selected crates");
                ImGuiUtils.ColoredSeparator("Objects", controlsColor);
                ImGui.BulletText("Right click: add objects");
                ImGui.BulletText("Ctrl + C: copy selected objects");
                ImGui.BulletText("Ctrl + V: paste selected objects (current position)");
                ImGui.BulletText("Ctrl+Shift + V: paste selected objects (original position)");
                ImGui.BulletText("Ctrl+Shift + X: move selected objects");
                ImGui.BulletText("Del/Suppr: delete selected objects");
                ImGuiUtils.ColoredSeparator("Gizmos", controlsColor);
                ImGui.BulletText("Ctrl + E: translate mode");
                ImGui.BulletText("Ctrl + R: rotate mode");
                ImGui.BulletText("Ctrl + T: scale mode");
                ImGuiUtils.ColoredSeparator("Save & launch", controlsColor);
                ImGui.BulletText("Ctrl + S: save level");
                ImGui.BulletText("Ctrl + L: backup + save + launch");
                ImGui.BulletText("Ctrl+Shift + S: save level as...");
                ImGui.Spacing();
            }
        }

        private void UpdateActiveLayers(THREE.Layers layers)
        {
            for (int i = 0; i < _layers.Count; i++)
            {
                if (_layers.Values.ElementAt(i)) 
                {
                    layers.Enable(i+1);
                }
                else 
                {
                    layers.Disable(i+1);
                }
            }
        }

        public THREE.Vector2? GetClipSpaceMousePos(THREE.Silk.MouseEventArgs e)
        {
            if (!IsWindowFocused) return null;
            
            float x = (e.X - _renderBounds.X) / _renderBounds.Z;
            float y = (e.Y - _renderBounds.Y) / _renderBounds.W;

            return new THREE.Vector2(x * 2.0f - 1.0f, y * 2.0f - 1.0f);
        }

        public void Focus(igObject obj)
        {
            NSTObject? nstObj = InstanceManager.AllObjects.Find(e => e.GetObject() == obj);
            if (nstObj == null)
            {
                Console.WriteLine("Warning: Object not found: " + obj);
                return;
            }

            Focus(nstObj, true, true);
        }

        public void Focus(NSTObject obj, bool forceLookAt = false, bool selectInTree = false)
        {
            SelectObject(obj, selectInTree);

            _treeView.SelectObject(obj);

            if (!forceLookAt && obj is NSTEntity entity && !entity.IsSpawned) return;

            LookAtObject(obj);
        }

        public void LookAtObject(NSTObject obj)
        {
            if (obj.Object3D == null)
            {
                Console.WriteLine("Warning: Object3D is null");
                return;
            }

            THREE.Vector3 worldPos = obj.Object3D.GetWorldPosition(new THREE.Vector3());

            _camera.Position.Copy(worldPos + new THREE.Vector3(0, -1000, 400));
            _camera.LookAt(worldPos);
            _camera.UpdateProjectionMatrix();
            _controls.LookAt(worldPos);

            RenderNextFrame = true;
        }

        public void SelectObject(NSTObject obj, bool selectInTree = false, bool fromTree = false)
        {
            List<NSTObject> selected = InstanceManager.Select(obj, fromTree);
            SelectionManager.UpdateSelection(selected, !fromTree || !ImGui.IsKeyDown(ImGuiKey.LeftShift));
            if (selectInTree) _treeView.SelectObject(obj);
            RenderNextFrame = true;
        }

        public void FocusObjectInArchive(NamedReference reference)
        {
            IgzRenderer? igzRenderer = FileManager.GetOrCreateRenderer(reference, ArchiveRenderer);
            
            if (igzRenderer == null) return;

            if (igzRenderer.IsOpenAsWindow)
            {
                ImGui.SetWindowFocus(igzRenderer.GetWindowName());
            }
            else
            {
                App.FocusRenderer(igzRenderer);
            }
        }

        public NSTObject? FindObject(NamedReference reference)
        {
            return InstanceManager.AllObjects.Find(e => e.FileNamespace == reference.namespaceName && e.GetObject().ObjectName == reference.objectName);
        }

        private List<THREE.Intersection> Raycast(THREE.Vector2 mouseClipSpace, float distance)
        {
            if (mouseClipSpace.X < -1 || mouseClipSpace.X > 1 || mouseClipSpace.Y < -1 || mouseClipSpace.Y > 1) return [];

            _camera.UpdateMatrixWorld();
            
            THREE.Raycaster raycaster = new THREE.Raycaster(_camera.Position, _camera.Front, _camera.Near, distance);
            THREE.Vector2 mouse = new THREE.Vector2(-mouseClipSpace.X, mouseClipSpace.Y);

            raycaster.SetFromCamera(mouse, _camera);

            UpdateActiveLayers(raycaster.layers);

            return raycaster.IntersectObject(InstanceManager.RootObject, true);
        }

        private void SelectFromRaycast(List<THREE.Intersection> intersects) 
        {
            List<NSTObject> hitEntities = [];

            intersects.Sort((x, y) => y.object3D.UserData.ContainsKey("spline").CompareTo(x.object3D.UserData.ContainsKey("spline")));

            foreach (THREE.Intersection intersect in intersects)
            {
                hitEntities = InstanceManager.SelectFromRaycast(intersect);
                if (hitEntities.Count > 0) break;
            }

            if (hitEntities.Count == 0) 
            {
                Console.WriteLine("No hit");
                SelectionManager.ClearSelection(true);
                _gizmos.Visible = false;
                return;
            }

            bool newSelection = !ImGui.IsKeyDown(ImGuiKey.LeftShift);

            SelectionManager.UpdateSelection(hitEntities, newSelection);

            _treeView.SelectObject(hitEntities[0]);
        }

        public string GetFileNameFromIdentifier(string fileIdentifier)
        {
            IgArchiveFile? existing = string.IsNullOrEmpty(fileIdentifier)
                ? Archive.FindMainMapFile()
                : Archive.FindFile(fileIdentifier, FileSearchType.NameContains, FileSearchParams.MapIgz);

            if (existing != null) return existing.GetName(false);

            IgArchiveFile? mainMapFile = Archive.FindMainMapFile();

            string path = (mainMapFile == null)
                ? $"maps/Custom/Custom_{fileIdentifier}.igz"
                : mainMapFile.GetPath().Replace(".igz", $"_{fileIdentifier}.igz");

            return Path.GetFileNameWithoutExtension(path);
        }

        public void GetOrCreateIgzFile(string fileIdentifier, out IgArchiveFile file, out IgzFile igz)
        {
            IgArchiveFile? existing = string.IsNullOrEmpty(fileIdentifier)
                ? Archive.FindMainMapFile()
                : Archive.FindFile(fileIdentifier, FileSearchType.NameContains, FileSearchParams.MapIgz);

            if (existing != null)
            {
                FileUpdateInfos infos = FileManager.Add(existing);
                infos.igz ??= existing.ToIgzFile();
                file = existing;
                igz = infos.igz;
            }
            else
            {
                IgArchiveFile? mainMapFile = Archive.FindMainMapFile();
                string path = (mainMapFile == null)
                    ? $"maps/Custom/Custom_{fileIdentifier}.igz"
                    : mainMapFile.GetPath().Replace(".igz", $"_{fileIdentifier}.igz");

                file = new IgArchiveFile(path);
                igz = new IgzFile(path);

                ArchiveRenderer.AddFile(file);
                FileManager.Add(file, igz, true);
            }
        }

        public List<NSTObject> Clone(
            List<igObject> objects, 
            IgArchive? sourceArchive, IgzFile? sourceIgz, 
            IgArchiveFile destFile, IgzFile destIgz, 
            float camDistance = 400, 
            bool? addToSelection = false, 
            bool initializeObjects = false, 
            Dictionary<igObject, igObject>? clones = null)
        {
            Dictionary<NSTEntity, string?> newEntities = [];
            HashSet<(string, string)> modelNames = [];
            List<NSTObject> newObjects = [];

            clones ??= [];
            
            // Clone objects
            foreach (igObject obj in objects)
            {
                if (sourceArchive != null && sourceIgz != null)
                {
                    ArchiveRenderer.Clone(obj, sourceArchive, sourceIgz, destIgz, clones, true);
                }
                else
                {
                    destIgz.AddClone(obj, destIgz, clones);
                }
            }

            foreach ((igObject original, igObject clone) in clones)
            {
                ArchiveRenderer.SetObjectUpdated(destFile, clone, true);

                // Add new objects
                if (clone is CCameraBox cameraBox)
                {
                    newObjects.Add(new NSTCameraBox(cameraBox, destFile));
                    continue;
                }
                if (clone is CCamera camera)
                {
                    newObjects.Add(new NSTCamera(camera, destFile));
                    continue;
                }

                if (clone is not igEntity cloneEntity) continue;

                // Add new entities
                NSTEntity entity = new NSTEntity(cloneEntity, destFile);

                string? modelPath = cloneEntity.GetModelName(destIgz, this);
                string? modelName = Path.GetFileNameWithoutExtension(modelPath);

                if (modelPath != null && modelName != null) {
                    modelNames.Add((modelName, modelPath));
                }

                newEntities.Add(entity, modelName);
            }

            LoadModels(newEntities, modelNames);

            var allObjects = newEntities.Keys.Union(newObjects).ToList();
            if (allObjects.Count == 0) return [];

            if (initializeObjects)
            {
                InstanceManager.RegisterNew(allObjects);
            }
            else
            {
                foreach (NSTObject newObj in allObjects)
                {
                    InstanceManager.Register(newObj);
                }
            }

            if (addToSelection == null) return allObjects;

            _treeView.RebuildTree(InstanceManager.AllObjects);

            NSTObject? selected = newEntities.Keys.Union(newObjects).FirstOrDefault();
            if (selected == null) return [];
            
            SelectObject(selected);

            if (addToSelection == true)
            {
                SelectionManager.UpdateSelection(newEntities.Keys.Where(e => e != selected && e.IsSpawned && !e.IsPrefabInstance && !e.IsPrefabChild).Cast<NSTObject>().ToList(), false);
            }

            SelectionManager._selectionContainer.Position = _camera.Position.Clone().Add(_camera.Front * camDistance);
            SelectionManager.ApplyChanges(FileManager, ArchiveRenderer);

            return allObjects;
        }

        public void MoveSelectionToCamera(float camDistance)
        {
            _treeView.RebuildTree(InstanceManager.AllObjects);
            InstanceManager.RefreshInstances(InstanceManager.AllObjects);
            SelectionManager._selectionContainer.Position = _camera.Position.Clone().Add(_camera.Front * camDistance);
            SelectionManager.ApplyChanges(FileManager, ArchiveRenderer);
        }

        public override void Dispose()
        {
            _gizmos.Dispose();
            base.Dispose();
        }
    }
}