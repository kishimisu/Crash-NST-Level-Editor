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
        private struct CollectionEntry(string archiveName, string fileName, string objectName, string objectType, string displayName, string modelName, string type)
        {
            public string ArchiveName { get; set; } = archiveName;
            public string FileName { get; set; } = fileName;
            public string ObjectName { get; set; } = objectName;
            public string ObjectType { get; set; } = objectType;
            public string DisplayName { get; set; } = displayName;
            public string ModelName { get; set; } = modelName;
            public string Type { get; set; } = type;
            public readonly string Key => $"{ModelName}_{DisplayName}";
        }

        private const int RENDER_SIZE = 256;

        private static List<CollectionEntry> _collection;
        private static readonly List<CollectionEntry> _searchResults = [];
        private static readonly JsonSerializerOptions jsonSerializerOptions = new() { IncludeFields = true };

        private static ModelPreview _modelPreview;
        private static readonly Dictionary<string, int> _previews = [];
        private static readonly ConcurrentQueue<(IgArchive archive, string path)> _createPreviewsMainThread = new();
        private static int _createPreviewsTotalCount = 0;
        private static bool _waitingForPreviews = false;

        public static bool _initialized = false;
        private static string _search = "";

        private class Settings
        {
            public HashSet<string> favorites = [];
            public int previewSize = 40;
            public string sortBy = "Archive";
            public string currentTab = "Enemies";
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
                })
                .ToDictionary();

            Directory.CreateDirectory(GetStoragePath());

            int archiveIndex = 0;

            foreach ((string name, string path) in archives)
            {
                var archive = IgArchive.Open(path);
                var mapFiles = archive.GetFiles(FileSearchParams.MapIgz);
                
                archiveIndex++;

                foreach (IgArchiveFile file in mapFiles)
                {
                    IgzFile igz = file.ToIgzFile();

                    foreach (igEntity entity in igz.FindObjects<igEntity>())
                    {
                        if (entity._bitfield._isArchetype || !entity._bitfield._canSpawn) continue;
                        if (entity.ObjectName!.StartsWith("Crate_") || entity.ObjectName.StartsWith("Collectible_")) continue;
                        if (entity.TryGetComponent(out common_Crate_StackCheckerData? _)) continue;

                        string? modelPath = entity.GetModelName(igz, archive: archive);
                        if (modelPath == null) continue;

                        string modelName = NamespaceUtils.GetFileName(modelPath, false);
                        string displayName = GetDisplayName(igz, entity);

                        if (entity.GetType() == typeof(igEntity))
                        {
                            displayName = modelName;
                        }

                        string key = $"{modelName}_{displayName}";
                        
                        if (entities.ContainsKey(key)) continue;

                        string archiveName = archive.GetName(false);
                        string fileName = igz.GetName(false);
                        string type = "Scenery";
                        
                        if (entity.GetType() != typeof(igEntity))
                        {
                            type = GetType(displayName) ?? GetType(entity.ObjectName) ?? GetType(fileName) ?? GetType(modelPath) ?? "Other";
                        }

                        entities.Add(key, new (archiveName, fileName, entity.ObjectName, entity.GetType().Name, displayName, modelName, type));

                        if (entities.Count == 1 || entities.Count % 50 == 0)
                        {
                            float progress = (float)archiveIndex / (archives.Count - 1);
                            ModalRenderer.ShowLoadingModal($"{name}.pak | {entities.Count} objects found ({archiveIndex}/{archives.Count})", progress);
                        }

                        if (models.Add(modelName))
                        {
                            _createPreviewsTotalCount++;
                            _createPreviewsMainThread.Enqueue((archive, modelName));
                        }
                    }
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(entities.Values, options);
            File.WriteAllText(GetStoragePath("collection.json"), json);

            _waitingForPreviews = true;
        }

        private static void CreatePreviewImages(IgArchive archive, string modelName)
        {
            IgzFile modelIgz = archive.Files
                .Find(f => 
                    (f.Path.StartsWith("actors/") || f.Path.StartsWith("models/")) && 
                    string.Equals(f.GetName(), $"{modelName}.igz", StringComparison.InvariantCultureIgnoreCase)
                )!.ToIgzFile();

            NSTModel? model = NSTModel.FromIgz(modelIgz);
            if (model == null) return;

            foreach (NSTMesh mesh in model.Meshes)
            {
                mesh.Material.InititializeMaterialAndTextures(archive);
            }

            _modelPreview.RenderModel(model);

            foreach (NSTMesh mesh in model.Meshes)
            {
                mesh.Material.texture?.Dispose();
            }

            string outputPath = GetStoragePath($"{modelName}.png");
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

                if (_settings.currentTab == "Favorites")
                {
                    if (!_settings.favorites.Contains(e.Key)) continue;
                }
                else if (_settings.currentTab != "All" && e.Type != _settings.currentTab) continue;

                if (!e.DisplayName.Contains(_search, StringComparison.CurrentCultureIgnoreCase) && 
                    !e.FileName.StartsWith(_search, StringComparison.CurrentCultureIgnoreCase) &&
                    !e.ObjectType.StartsWith(_search, StringComparison.CurrentCultureIgnoreCase))
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
                if (sort == "Archive")
                    return string.Compare(a.ArchiveName, b.ArchiveName);
                if (sort == "Name")
                    return string.Compare(a.DisplayName, b.DisplayName);
                if (sort == "Model")
                    return string.Compare(a.ModelName, b.ModelName);

                return 0;
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
            
            CreatePreviewImages(item.archive, item.path);
            
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
            
            RenderItemList(explorer);
        }

        private static bool RenderInitialize()
        {
            string collectionPath = GetStoragePath("collection.json");

            if (!File.Exists(collectionPath))
            {
                ImGui.Text("The object collection hasn't been initialized.");
                ImGui.Spacing();
                ImGui.BeginDisabled();
                ImGui.Text("This operation can take 10-20 minutes to\ncomplete, but you only have to do it once.");
                ImGui.Spacing();
                ImGui.Text("Make sure you haven't overwritten any original\nlevel archive before you begin:");
                ImGui.Text("Steam -> Library -> Crash NST (right-click) ->\nProperties -> Installed Files -> Verify integrity");
                ImGui.EndDisabled();
                ImGuiUtils.VerticalSpacing(6);
                if (ImGuiUtils.CenteredButton("   Initialize collection   "))
                {
                    ModalRenderer.ShowLoadingModal("Initializing collection...");

                    _modelPreview = new ModelPreview(RENDER_SIZE, RENDER_SIZE);

                    Task.Run(CreateCollection)
                    .ContinueWith(t =>
                    {
                        if (t.IsFaulted && t.Exception != null)
                        {
                            foreach (var ex in t.Exception.InnerExceptions)
                            {
                                CrashHandler.Log($"Error initializing collection: {ex.Message}\n{ex.StackTrace}");
                            }
                            string logPath = CrashHandler.WriteLogsToFile();
                            ModalRenderer.ShowMessageModal("Error", $"An error occured while initializing the collection\n\nLog file: {logPath}");
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
            if (ImGui.Checkbox("CEntity     ", ref _settings.filterCEntity)) UpdateSearch();
            ImGui.SameLine();
            if (ImGui.Checkbox("CPhysicalEntity", ref _settings.filterCPhysicalEntity)) UpdateSearch();

            if (ImGui.Checkbox("Crash 2  ", ref _settings.filterC2)) UpdateSearch();
            ImGui.SameLine();
            if (ImGui.Checkbox("Bosses  ", ref _settings.filterBoss)) UpdateSearch();
            ImGui.SameLine();
            if (ImGui.Checkbox("CGameEntity ", ref _settings.filterCGameEntity)) UpdateSearch();
            ImGui.SameLine();
            if (ImGui.Checkbox("CActor  ", ref _settings.filterCActor)) UpdateSearch();

            if (ImGui.Checkbox("Crash 3  ", ref _settings.filterC3)) UpdateSearch();
            ImGui.SameLine();
            if (ImGui.Checkbox("Hubs    ", ref _settings.filterHub)) UpdateSearch();

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
            bool selected = _settings.currentTab == name;

            if (selected)
                ImGui.PushStyleColor(ImGuiCol.Tab, ImGui.GetStyle().Colors[(int)ImGuiCol.TabHovered]);

            if (ImGui.TabItemButton(name))
            {
                _settings.currentTab = name;
                UpdateSearch();
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
                        ObjectFactory.AddGeneric(e.FileName, e.ObjectName, e.Type, explorer, null, e.DisplayName, addToSelection: true);
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

                            if (_settings.currentTab == "Favorites") 
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
                                textureId = TextureHelper.CreateOpenGLTexture(SilkWindow.instance._gl, width, height, pixels, flipY: true, reuseLastTexture: false);
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

                    if (_settings.showFileName) ImGui.TextDisabled(e.FileName);

                    if (_settings.currentTab == "All" || _settings.currentTab == "Favorites")
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
