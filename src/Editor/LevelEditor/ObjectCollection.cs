using Alchemy;
using ImGuiNET;
using System.Numerics;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Collections.Concurrent;

namespace NST
{
    public static class ObjectCollection
    {
        private struct CollectionEntry(string archiveName, string fileName, string objectName, string objectType, string displayName, string modelName, string type, bool prefab, bool collisions)
        {
            public string ArchiveName { get; set; } = archiveName;
            public string FileName { get; set; } = fileName;
            public string ObjectName { get; set; } = objectName;
            public string ObjectType { get; set; } = objectType;
            public string DisplayName { get; set; } = displayName;
            public string ModelName { get; set; } = modelName;
            public string Type { get; set; } = type;
            public bool IsPrefab { get; set; } = prefab;
            public bool HasCollisions { get; set; } = collisions;
            public readonly string Key => $"{ModelName}_{DisplayName}";
        }

        private const int RENDER_SIZE = 256;

        private static List<CollectionEntry> _collection;
        private static readonly List<CollectionEntry> _searchResults = [];
        private static readonly JsonSerializerOptions jsonSerializerOptions = new() { IncludeFields = true };

        private static ModelPreview _modelPreview;
        private static readonly Dictionary<string, int> _previews = [];
        private static readonly ConcurrentQueue<(IgArchive archive, string path, Dictionary<THREE.Matrix4, string>? prefabs)> _createPreviewsMainThread = new();
        private static int _createPreviewsTotalCount = 0;
        private static bool _waitingForPreviews = false;

        private static bool _initialized = false;
        private static string _search = "";
        private static string _currentTab = "Enemies";

        private class Settings
        {
            public HashSet<string> favorites = [];
            public int previewSize = 40;
            public string sortBy = "Archive";
            public bool showFileName = true;
            public bool showObjectType = true;
            public bool filterC1 = true;
            public bool filterC2 = true;
            public bool filterC3 = true;
            public bool filterLevel = true; 
            public bool filterBoss = false;
            public bool filterHub = false;
            public bool filterCEntity = true;
            public bool filterCGameEntity = true;
            public bool filterCPhysicalEntity = true;
            public bool filterCActor = true;
            public bool filterPrefab = true;
            public bool filterNoCollisions = true;
        }
        
        private static Settings _settings = new Settings();

        private static string GetStoragePath(string path = "") => Path.Combine(LocalStorage.GetStoragePath("collection"), path);

        private static void CreateCollection()
        {
            List<string> originals = ModManager._levels.Select(e => e.Split("/").Last()).ToList();
            Dictionary<string, CollectionEntry> entities = [];
            HashSet<string> models = [];

            var archives = Directory
                .GetFiles(LocalStorage.ArchivePath, "*.pak")
                .ToDictionary(path => NamespaceUtils.GetFileName(path, false), path => path)
                .Where(e => originals.Contains(e.Key.ToLowerInvariant()))
                .OrderBy(e =>
                {
                    bool isHub = e.Key.Substring(2, 2) == "00";
                    bool isLevel = e.Key[0] == 'L' && !isHub;
                    bool isBoss = e.Key[0] == 'B';
                    if (isLevel) return 0;
                    if (isBoss)  return 1;
                    if (isHub)   return 2;
                    return 3;
                });

            Directory.CreateDirectory(GetStoragePath());

            int archiveIndex = 0;

            foreach ((string archiveName, string path) in archives)
            {
                var archive = IgArchive.Open(path);
                var mapFiles = archive.GetFiles(FileSearchParams.MapIgz);
                var collisions = archive.FindCollisionFile(".igz")?.ToIgzFile().FindObject<CStaticCollisionHashInstanceIdHashTable>()?.Dict;
                var compoundShape = archive.FindCollisionFile(".hkx")?.ToHavokFile().GetAllObjects().Find(e => e is Havok.hknpStaticCompoundShape) as Havok.hknpStaticCompoundShape;
                
                archiveIndex++;

                foreach (IgArchiveFile file in mapFiles)
                {
                    IgzFile igz = file.ToIgzFile();
                    string fileName = igz.GetName(false);

                    foreach (igEntity entity in igz.FindObjects<igEntity>())
                    {
                        bool staticObject = entity.GetType() == typeof(igEntity);
                        if ((entity._bitfield._isArchetype || !entity._bitfield._canSpawn) && !staticObject) continue;
                        if (entity.ObjectName!.StartsWith("Crate_") || entity.ObjectName.StartsWith("Collectible_")) continue;
                        if (entity.TryGetComponent(out common_Crate_StackCheckerData? _)) continue;

                        string key;
                        string modelName;
                        string type = "Scenery";
                        string displayName = GetDisplayName(igz, entity);

                        bool isPrefab = entity.TryGetComponent(out igPrefabComponentData? prefabComponent);
                        bool hasCollisions = false;

                        if (isPrefab)
                        {
                            var prefabChildren = prefabComponent!._prefabEntities?._data;
                            if (prefabChildren == null) continue;

                            Dictionary<THREE.Matrix4, string> prefabModels = [];

                            var parentTransform = entity.GetTransformMatrix();

                            foreach (var child in prefabChildren)
                            {
                                if (!child._bitfield._canSpawn) continue;
                                
                                string? childModelPath = child.GetModelName(igz, archive: archive);
                                if (childModelPath == null) continue;

                                string childModelName = NamespaceUtils.GetFileName(childModelPath, false);
                                var childTransform = child.GetTransformMatrix();
                                
                                prefabModels.Add(childTransform, childModelName);

                                if (compoundShape == null || hasCollisions) continue;

                                var worldTransform = parentTransform * childTransform;

                                THREE.Vector3 childPosition = new THREE.Vector3();
                                worldTransform.Decompose(childPosition, new THREE.Quaternion(), new THREE.Vector3());

                                foreach (var shape in compoundShape._elements.GetElements())
                                {
                                    THREE.Vector3 havokPosition = new THREE.Vector3(shape._transform.M41, shape._transform.M42, shape._transform.M43);
                                    float distance = havokPosition.DistanceTo(childPosition * 0.0254f);
                                    if (distance < 0.01f)
                                    {
                                        hasCollisions = true;
                                        break;
                                    }
                                }
                            }

                            if (prefabModels.Count == 0) continue;

                            modelName = $"Prefab_{displayName}";
                            key = displayName.ToLowerInvariant();
                            
                            if (entities.ContainsKey(key)) continue;

                            if (prefabChildren.Any(e => e.GetType() != typeof(igEntity)))
                            {
                                type = GetType(displayName) ?? GetType(entity.ObjectName) ?? GetType(fileName) ?? "Other";
                            }

                            _createPreviewsTotalCount++;
                            _createPreviewsMainThread.Enqueue((archive, modelName, prefabModels));
                        }
                        else
                        {
                            string? modelPath = entity.GetModelName(igz, archive: archive);
                            if (modelPath == null) continue;

                            modelName = NamespaceUtils.GetFileName(modelPath, false);

                            if (staticObject)
                            {
                                displayName = modelName;
                            }

                            key = $"{modelName}_{displayName}";
                            
                            if (entities.ContainsKey(key)) continue;
                            
                            if (!staticObject)
                            {
                                type = GetType(displayName) ?? GetType(entity.ObjectName) ?? GetType(fileName) ?? GetType(modelPath) ?? "Other";
                            }

                            HashedReference reference = entity.ToNamedReference(fileName).ToEXID();
                            u64 collisionKey = ((u64)reference.fileHash << 32) | reference.objectHash;
                            hasCollisions |= collisions?.ContainsKey(collisionKey) == true;

                            if (models.Add(modelName))
                            {
                                _createPreviewsTotalCount++;
                                _createPreviewsMainThread.Enqueue((archive, modelName, null));
                            }
                        }

                        entities.Add(key, new (archiveName, fileName, entity.ObjectName, entity.GetType().Name, displayName, modelName, type, isPrefab, hasCollisions));

                        if (entities.Count == 1 || entities.Count % 50 == 0)
                        {
                            float progress = (float)archiveIndex / (archives.Count() - 1);
                            ModalRenderer.ShowLoadingModal($"{archiveName}.pak | {entities.Count} objects found ({archiveIndex}/{archives.Count()})", progress);
                        }
                    }
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(entities.Values, options);
            File.WriteAllText(GetStoragePath("collection.json"), json);

            _waitingForPreviews = true;
        }

        private static void CreatePreviewImage(IgArchive archive, string name, Dictionary<THREE.Matrix4, string> objects)
        {
            var modelFiles = archive.Files.Where(f => f.IsIGZ() && (f.Path.StartsWith("actors/") || f.Path.StartsWith("models/")));

            THREE.Group obj = new THREE.Group();
            HashSet<NSTMesh> meshes = [];

            foreach ((var transform, var modelName) in objects)
            {
                IgzFile modelIgz = modelFiles.First(f => string.Equals(f.GetName(), $"{modelName}.igz", StringComparison.InvariantCultureIgnoreCase)).ToIgzFile();

                NSTModel? model = NSTModel.FromIgz(modelIgz);
                if (model == null) continue;

                foreach (NSTMesh mesh in model.Meshes)
                {
                    meshes.Add(mesh);
                    mesh.Material.InititializeMaterialAndTextures(archive);
                }

                var child = model.CreateObject();
                child.ApplyMatrix4(transform);
                obj.Add(child);
            }

            _modelPreview.RenderObject(obj);

            foreach (NSTMesh mesh in meshes)
            {
                mesh.Material.texture?.Dispose();
            }

            string outputPath = GetStoragePath($"{name}.png");
            byte[] pixels = TextureHelper.ReadTexture(SilkWindow.instance._gl, _modelPreview.TextureId, RENDER_SIZE, RENDER_SIZE);
            TextureHelper.SaveImageToFile(pixels, RENDER_SIZE, RENDER_SIZE, outputPath, false);
        }

        private static void UpdateSearch(bool saveSettings = true)
        {
            _searchResults.Clear();

            foreach (CollectionEntry e in _collection)
            {
                string prefix = e.ArchiveName.Substring(0, 4);
                bool isHub = prefix == "L100" || prefix == "L200" || prefix == "L300";
                bool isLevel = prefix[0] == 'L' && !isHub;
                bool isBoss = prefix[0] == 'B';

                if (!isHub && !isLevel && !isBoss) isHub = true;

                if (isHub && !_settings.filterHub) continue;
                if (isBoss && !_settings.filterBoss) continue;
                if (isLevel && !_settings.filterLevel) continue;
                if (prefix[1] == '1' && !_settings.filterC1) continue;
                if (prefix[1] == '2' && !_settings.filterC2) continue;
                if (prefix[1] == '3' && !_settings.filterC3) continue;
                if (e.ObjectType == "CEntity" && !_settings.filterCEntity) continue;
                if (e.ObjectType == "CGameEntity" && !_settings.filterCGameEntity) continue;
                if (e.ObjectType == "CPhysicalEntity" && !_settings.filterCPhysicalEntity) continue;
                if (e.ObjectType == "CActor" && !_settings.filterCActor) continue;
                if (e.Type == "Scenery" && !e.HasCollisions && !_settings.filterNoCollisions) continue;
                if (e.IsPrefab && !_settings.filterPrefab) continue;

                if (_currentTab == "Favorites")
                {
                    if (!_settings.favorites.Contains(e.Key)) continue;
                }
                else
                {
                    if (_currentTab != "All" && e.Type != _currentTab) continue;
                }

                if (!string.IsNullOrEmpty(_search) &&
                    !e.DisplayName.Contains(_search, StringComparison.CurrentCultureIgnoreCase) &&
                    !e.FileName.StartsWith(_search, StringComparison.CurrentCultureIgnoreCase)  &&
                    !e.ObjectType.StartsWith(_search, StringComparison.CurrentCultureIgnoreCase) )
                {
                    continue;
                }

                _searchResults.Add(e);
            }

            UpdateSort(_settings.sortBy, saveSettings);
        }

        private static void UpdateSort(string sort, bool saveSettings = true)
        {
            _settings.sortBy = sort;

            _searchResults.Sort((a, b) =>
            {
                int cmp = 0;

                if (sort == "Archive")
                    cmp = string.Compare(a.ArchiveName, b.ArchiveName);
                if (sort == "Name")
                    cmp = string.Compare(a.DisplayName, b.DisplayName);
                if (sort == "Model")
                    cmp = string.Compare(a.ModelName, b.ModelName);

                if (cmp == 0)
                {
                    if (sort == "Name")
                        cmp = string.Compare(a.ArchiveName, b.ArchiveName);
                    else
                        cmp = string.Compare(a.DisplayName, b.DisplayName);
                }

                return cmp;
            });

            if (saveSettings)
            {
                SaveSettings();
            }
        }

        public static void Update()
        {
            if (_initialized || _createPreviewsMainThread.IsEmpty || !_createPreviewsMainThread.TryDequeue(out var item)) 
                return;

            if (item.prefabs == null)
            {
                CreatePreviewImage(item.archive, item.path, new() {{ THREE.Matrix4.Identity(), item.path }});
            }
            else
            {
                CreatePreviewImage(item.archive, item.path, item.prefabs);
            }
            
            if (_waitingForPreviews)
            {
                int current = _createPreviewsTotalCount - _createPreviewsMainThread.Count;
                float progress = (float)current / _createPreviewsTotalCount;

                if (_createPreviewsMainThread.IsEmpty && current >= _createPreviewsTotalCount - 1)
                {
                    ModalRenderer.CloseLoadingModal();
                    _waitingForPreviews = false;
                }
                else if (current % 10 == 0)
                {
                    ModalRenderer.ShowLoadingModal($"Generating preview images... ({current}/{_createPreviewsTotalCount})", progress);
                }
            }
        }

        public static void Render(LevelExplorer explorer)
        {
            var size = _initialized ? new Vector2(500, 600) : new Vector2(0, 0);

            if (ImGui.BeginChild("Collection", size, ImGuiChildFlags.AutoResizeX | ImGuiChildFlags.AutoResizeY))
            {
                RenderCollection(explorer);
            }

            ImGui.EndChild();
        }

        private static void RenderCollection(LevelExplorer explorer)
        {
            if (!_initialized && !RenderInitialize()) return;

            ImGui.SetNextItemWidth(-1);
            if (ImGui.InputTextWithHint("##Collection", "Search...", ref _search, 256))
            {
                UpdateSearch(false);
            }

            if (ImGui.TreeNodeEx("Settings"))
            {
                RenderSettings();
                ImGui.TreePop();
            }

            if (ImGui.BeginTabBar("CollectionTabs"))
            {
                ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 5);
                RenderTab("All");
                RenderTab("Enemies");
                RenderTab("Hazards");
                RenderTab("Platforms");
                RenderTab("Scenery");
                RenderTab("Other");
                RenderTab("Favorites");
                ImGui.PopStyleVar();
                ImGui.EndTabBar();
            }

            ImGui.TextDisabled($"{_searchResults.Count} objects found");

            if (_currentTab == "Scenery" && ImGui.Checkbox("Show objects with no collision", ref _settings.filterNoCollisions))
            {
                UpdateSearch();
            }

            RenderItemList(explorer);
        }

        private static bool RenderInitialize()
        {
            string collectionPath = GetStoragePath("collection.json");

            if (!File.Exists(collectionPath))
            {
                ImGui.Text("The object library hasn't been initialized.");
                ImGui.Spacing();
                ImGui.BeginDisabled();
                ImGui.Text("This operation can take 10-20 minutes to\ncomplete, but you only have to do it once.");
                ImGui.Spacing();
                ImGui.Text("Make sure you haven't overwritten any original\nlevel archive before you begin:");
                ImGui.Text("Steam -> Library -> Crash NST (right-click) ->\nProperties -> Installed Files -> Verify integrity");
                ImGui.EndDisabled();
                ImGuiUtils.VerticalSpacing(6);
                if (ImGuiUtils.CenteredButton("   Initialize library   "))
                {
                    ModalRenderer.ShowLoadingModal("Initializing library...");

                    _modelPreview = new ModelPreview(RENDER_SIZE, RENDER_SIZE);

                    Task.Run(CreateCollection)
                    .ContinueWith(t =>
                    {
                        if (t.IsFaulted && t.Exception != null)
                        {
                            foreach (var ex in t.Exception.InnerExceptions)
                            {
                                CrashHandler.Log($"Error initializing library: {ex.Message}\n{ex.StackTrace}");
                            }
                            string logPath = CrashHandler.WriteLogsToFile();
                            ModalRenderer.ShowMessageModal("Error", $"An error occured while initializing the library\n\nLog file: {logPath}");
                        }
                    }, TaskContinuationOptions.OnlyOnFaulted);   
                }
                ImGuiUtils.VerticalSpacing(4);
                return false;
            }
            else if (_waitingForPreviews || _createPreviewsMainThread.Count > 0)
            {
                ImGui.Text("Initialization in progress...");
                return false;
            }

            string json = File.ReadAllText(collectionPath);
            _collection = JsonSerializer.Deserialize<List<CollectionEntry>>(json) ?? [];
            for (int i = 0; i < _collection.Count; i++) // handle legacy name
            {
                if (_collection[i].Type == "Decoration")
                {
                    var item = _collection[i]; item.Type = "Scenery"; _collection[i] = item;
                }
            }
            _initialized = true;
            LoadSettings();
            UpdateSearch(false);

            return true;
        }

        private static void RenderSettings()
        {
            ImGui.SeparatorText("Display");

            ImGuiUtils.Prefix("Sort by:");
            if (ImGui.BeginCombo("##sortBy", _settings.sortBy))
            {
                if (ImGui.Selectable("Archive")) UpdateSort("Archive");
                if (ImGui.Selectable("Name")) UpdateSort("Name");
                if (ImGui.Selectable("Model")) UpdateSort("Model");
                ImGui.EndCombo();
            }
            ImGuiUtils.Prefix("Show file name:");
            if (ImGui.Checkbox("##show_file_name", ref _settings.showFileName)) SaveSettings();
            ImGuiUtils.Prefix("Show object type:");
            if (ImGui.Checkbox("##show_object_type", ref _settings.showObjectType)) SaveSettings();
            ImGuiUtils.Prefix("Preview size:");
            if (ImGui.SliderInt("##preview_size", ref _settings.previewSize, 0, 128)) SaveSettings();

            ImGui.SeparatorText("Filters");

            if (ImGui.Checkbox("Crash 1  ", ref _settings.filterC1)) UpdateSearch();
            ImGui.SameLine();
            if (ImGui.Checkbox("Levels  ", ref _settings.filterLevel)) UpdateSearch();
            ImGui.SameLine();
            if (ImGui.Checkbox("CEntity       ", ref _settings.filterCEntity)) UpdateSearch();
            ImGui.SameLine();
            if (ImGui.Checkbox("Prefabs       ", ref _settings.filterPrefab)) UpdateSearch();

            if (ImGui.Checkbox("Crash 2  ", ref _settings.filterC2)) UpdateSearch();
            ImGui.SameLine();
            if (ImGui.Checkbox("Bosses  ", ref _settings.filterBoss)) UpdateSearch();
            ImGui.SameLine();
            if (ImGui.Checkbox("CGameEntity   ", ref _settings.filterCGameEntity)) UpdateSearch();
            ImGui.SameLine();
            if (ImGui.Checkbox("CActor  ", ref _settings.filterCActor)) UpdateSearch();

            if (ImGui.Checkbox("Crash 3  ", ref _settings.filterC3)) UpdateSearch();
            ImGui.SameLine();
            if (ImGui.Checkbox("Hubs    ", ref _settings.filterHub)) UpdateSearch();
            ImGui.SameLine();
            if (ImGui.Checkbox("CPhysicalEntity", ref _settings.filterCPhysicalEntity)) UpdateSearch();

            if (ImGui.SmallButton("Reset settings"))
            {
                var favorites = _settings.favorites;
                _settings = new Settings() { favorites = favorites };
                UpdateSearch();
            }

            ImGui.Spacing();
        }

        private static void RenderTab(string name)
        {
            bool selected = _currentTab == name;

            if (selected)
                ImGui.PushStyleColor(ImGuiCol.Tab, ImGui.GetStyle().Colors[(int)ImGuiCol.TabHovered]);

            if (ImGui.TabItemButton(name))
            {
                _currentTab = name;
                UpdateSearch(false);
            }

            if (selected)
                ImGui.PopStyleColor();
        }

        private unsafe static void RenderItemList(LevelExplorer explorer)
        {
            var clipper = new ImGuiListClipperPtr(ImGuiNative.ImGuiListClipper_ImGuiListClipper());

            clipper.Begin(_searchResults.Count);

            while (clipper.Step())
            {
                for (var i = clipper.DisplayStart; i < clipper.DisplayEnd; i++)
                {
                    CollectionEntry e = _searchResults[i];

                    ImGui.Separator();

                    if (ImGui.Selectable($"##row_{i}", false, ImGuiSelectableFlags.SpanAllColumns | ImGuiSelectableFlags.AllowOverlap, new Vector2(0, _settings.previewSize)))
                    {
                        Task.Run(() =>
                        {
                            ModalRenderer.ShowLoadingModal($"Importing {e.DisplayName}...");
                            ObjectFactory.TryAddObject(() =>
                            {
                                ObjectFactory.AddGeneric(e.FileName, e.ObjectName, e.Type, explorer, null, e.DisplayName, 800, true);
                            });
                            ModalRenderer.CloseLoadingModal();
                        });
                    }
                    if (ImGui.BeginPopupContextItem())
                    {
                        if (ImGui.Selectable("Focus in original level"))
                        {
                            try
                            {
                                string archivePath = Path.Combine(LocalStorage.ArchivePath, $"{e.ArchiveName}.pak");
                                IgArchiveRenderer renderer = new IgArchiveRenderer(archivePath);
                                igObject? toFocus = renderer.Archive.FindObject(new NamedReference(e.FileName, e.ObjectName));
                                if (toFocus == null) throw new Exception($"Could not find {e.ObjectName} in {e.FileName}.igz");
                                App.OpenLevelExplorer(renderer, toFocus);
                            }
                            catch (Exception ex)
                            {
                                ModalRenderer.ShowMessageModal("Error", ex.Message);
                            }
                        }

                        ImGui.Separator();

                        string key = e.Key;
                        bool isFavorite = _settings.favorites.Contains(key);

                        if (!isFavorite && ImGui.Selectable("Add to favorites"))
                        {
                            _settings.favorites.Add(key);
                            SaveSettings();
                        }
                        else if (isFavorite && ImGui.Selectable("Remove from favorites"))
                        {
                            _settings.favorites.Remove(key);
                            SaveSettings();

                            if (_currentTab == "Favorites") 
                                UpdateSearch(false);
                        }

                        ImGui.EndPopup();
                    }

                    ImGui.SameLine();

                    if (_settings.previewSize > 0)
                    {
                        if (!_previews.TryGetValue(e.ModelName, out int textureId))
                        {
                            textureId = -1;

                            string imagePath = GetStoragePath($"{e.ModelName}.png");

                            if (File.Exists(imagePath))
                            {
                                byte[] pixels = TextureHelper.LoadImageFromFile(imagePath, out int width, out int height);
                                textureId = TextureHelper.CreateOpenGLTexture(SilkWindow.instance._gl, width, height, pixels, flipY: true, overwrite: false);
                            }

                            _previews.Add(e.ModelName, textureId);
                        }

                        if (textureId != -1)
                        {
                            ImGui.Image(textureId, new Vector2(_settings.previewSize, _settings.previewSize), Vector2.Zero, Vector2.One, Vector4.One);

                            if (ImGui.IsItemHovered())
                            {
                                ImGui.BeginTooltip();
                                ImGui.Text(e.DisplayName);
                                ImGui.Image(textureId, new Vector2(RENDER_SIZE, RENDER_SIZE), Vector2.Zero, Vector2.One, Vector4.One);
                                ImGui.EndTooltip();
                            }
                        }
                        else
                        {
                            ImGui.Dummy(new Vector2(_settings.previewSize, _settings.previewSize));
                        }

                        ImGui.SameLine();
                    }
                    
                    ImGui.BeginGroup();
                    
                    if (_settings.showObjectType)
                    {
                        var color = MathUtils.UIntToVector4Numerics(TypeExtensions.GetUniqueColor(e.ObjectType));
                        ImGui.TextColored(color, e.ObjectType + ":");
                        ImGui.SameLine();
                    }

                    ImGui.Text(e.DisplayName);

                    if (e.IsPrefab)
                    {
                        ImGui.SameLine();
                        ImGui.TextDisabled("[Prefab]");
                    }

                    if (_settings.showFileName) ImGui.TextDisabled(e.FileName);

                    if (_currentTab == "All" || _currentTab == "Favorites")
                    {
                        ImGui.TextDisabled(e.Type);
                    }

                    ImGui.EndGroup();
                }
            }

            clipper.Destroy();
        }

        private static void LoadSettings()
        {
            string? savedSettings = LocalStorage.Get("collection_settings", "");

            if (string.IsNullOrEmpty(savedSettings)) return;

            var settings = JsonSerializer.Deserialize<Settings>(savedSettings, jsonSerializerOptions);

            if (settings != null)
            {
                _settings = settings;
            }
        }

        private static void SaveSettings()
        {
            string json = JsonSerializer.Serialize(_settings, jsonSerializerOptions);
            LocalStorage.Set("collection_settings", json);
        }

        private static string? GetType(string name)
        {
            name = name.ToLowerInvariant();

            if      (name.Contains("enem")) return "Enemies";
            else if (name.Contains("hazard")) return "Hazards";
            else if (name.Contains("platform")) return "Platforms";
            else if (name.Contains("teleporter")) return "Platforms";
            
            return null;
        }

        private static string GetDisplayName(IgzFile igz, igEntity entity)
        {
            string displayName = entity.ObjectName!;

            if (entity.TryGetComponent(out common_Spawner_TemplateData? spawner) && spawner._EntityToSpawn.Reference != null)
            {
                var template = igz.FindObject(spawner._EntityToSpawn.Reference);
                if (template != null) displayName = template.ObjectName!;
            }

            displayName = displayName
                .Replace("_gen", "", StringComparison.InvariantCultureIgnoreCase)
                .Replace("_character", "", StringComparison.InvariantCultureIgnoreCase)
                .Replace("_spawned", "", StringComparison.InvariantCultureIgnoreCase)
                .Replace("_spawnd", "", StringComparison.InvariantCultureIgnoreCase)
                .Replace("spawned", "", StringComparison.InvariantCultureIgnoreCase);

            return Regex.Replace(displayName,  @"[_\d]+$", "");
        }
    }
}
