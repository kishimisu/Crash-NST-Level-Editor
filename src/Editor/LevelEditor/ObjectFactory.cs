using Alchemy;
using ImGuiNET;

namespace NST
{
    public static class ObjectFactory
    {
        private static IgArchive? templateArchive = null;
        private static IgArchiveFile? templateFile = null;
        private static IgzFile? templateIgz = null;

        private static readonly List<string> _crateFloatingModes = new()
        {
            "None", "Floating", "Flood", "Water",
        };

        private static readonly Dictionary<string, Dictionary<string, string>> _crateNames = new()
        {
            { 
                "Default", new() 
                {
                    { "Aku Aku", "AkuAku" },
                    { "Arrow", "Arrow" },
                    { "Basic", "Basic" },
                    { "Bounce", "Bounce" },
                    { "Checkpoint", "Checkpoint" },
                    { "Extra Life", "ExtraLife" },
                    { "Random", "Random" },
                    { "Random Extra Life", "RandomExtraLife" },
                    { "Slot Machine", "SlotMachine" },
                    { "TNT", "TNT" },
                    { "Nitro", "Nitro" },
                }
            },
            { 
                "Iron", new() 
                {
                    { "Arrow", "Arrow_Iron" },
                    { "Arrow High", "Arrow_Iron_High" },
                    { "Basic", "Basic_Iron" },
                    { "Checkpoint", "Checkpoint_Iron" },
                    { "Switch Outlined", "Switch" },
                    { "Switch Reusable", "Switch_Reusable" },
                    { "Switch Nitro", "Switch_Nitro" },
                    { "Iron Bound", "IronBound" },
                }
            },
            { 
                "Bonus", new() 
                {
                    { "Tawna", "Bonus_Tawna" },
                    { "Brio", "Bonus_Brio" },
                    { "Cortex", "Bonus_Cortex" },
                }
            },
        };

        private static readonly Dictionary<string, string> _specialCrateTemplates = new()
        {
            { "Crate_Switch", "Crate_Switch_Iron_Spawned_gen" },
            { "Crate_Switch_Reusable", "Crate_Switch_Iron_Reusable_Spawned_gen" },
            { "Crate_SlotMachine", "Crate_Empty_Spawned_gen" },
        };

        private static readonly Dictionary<string, string> _collectibleNames = new()
        {
            { "Wumpa Fruit",  "Wumpa02" },
            { "Extra Life",   "ExtraLife02" },
            { "Aku Aku",      "AkuAku02" },
            { "Crystal",      "PowerCrystal" },
            { "Time Trial",   "TimeTrial_Start" },
            { "Bonus Tawna",  "BonusTawna" },
            { "Bonus Brio",   "BonusBrio" },
            { "Bonus Cortex", "BonusCortex" },
            { "Key",          "Key_Spawned"},
        };

        private static readonly List<string> _gemNames = new()
        {
            "Clear", "Blue", "Green", "Orange", "Purple", "Red", "Yellow"
        };
        
        private static string _floatMode = "None";
        private static bool _outlinedCrate = false;
        private static bool _bonusCrate = false;

        public static void RenderContextMenu(LevelExplorer explorer)
        {
            if (ImGui.BeginPopup("ObjectFactoryContextMenu"))
            {
                if (ImGui.BeginMenu("New crate..."))
                {
                    ImGui.SeparatorText("Crate settings");

                    ImGui.Checkbox("Bonus crate", ref _bonusCrate);
                    ImGui.SameLine();
                    ImGui.Checkbox("Outline crate", ref _outlinedCrate);

                    if (ImGui.BeginCombo("Floating behavior", _floatMode))
                    {
                        foreach (string mode in _crateFloatingModes)
                        {
                            if (ImGui.Selectable(mode)) _floatMode = mode;
                        }
                        ImGui.EndCombo();
                    }

                    ImGui.Separator();

                    foreach ((string displayName, string objectName) in _crateNames["Default"])
                    {
                        if (ImGui.MenuItem(displayName)) AddCrate(objectName, explorer);
                    }

                    ImGui.Separator();

                    if (ImGui.BeginMenu("Iron crate..."))
                    {
                        foreach ((string displayName, string objectName) in _crateNames["Iron"])
                        {
                            if (ImGui.MenuItem(displayName)) AddCrate(objectName, explorer);
                        }
                        ImGui.EndMenu();
                    }
                    ImGui.Separator();

                    if (ImGui.BeginMenu("Bonus crate..."))
                    {
                        foreach ((string displayName, string objectName) in _crateNames["Bonus"])
                        {
                            if (ImGui.MenuItem(displayName)) AddCrate(objectName, explorer);
                        }
                        ImGui.EndMenu();
                    }

                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("New collectible..."))
                {
                    foreach ((string displayName, string objectName) in _collectibleNames)
                    {
                        if (ImGui.MenuItem(displayName)) AddCollectible(objectName, explorer);
                    }

                    if (ImGui.BeginMenu("Gem..."))
                    {
                        foreach (string name in _gemNames)
                        {
                            if (ImGui.MenuItem(name + " Gem")) AddCollectible("Gem_" + name, explorer);
                        }
                        ImGui.EndMenu();
                    }
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("New camera..."))
                {
                    if (ImGui.MenuItem("Relative camera")) AddRelativeCamera(explorer);
                    if (ImGui.MenuItem("Spline camera")) AddSplineCamera(explorer);
                    // if (ImGui.MenuItem("Camera box")) {}
                    // ImGui.Separator();
                    // if (ImGui.MenuItem("Free camera")) {}
                    ImGui.EndMenu();
                }

                ImGui.EndPopup();
            }
        }

        private static void SetupTemplateArchive()
        {
            if (templateArchive == null || templateFile == null || templateIgz ==  null)
            {
                templateArchive = IgArchive.Open(Path.Join(LocalStorage.ArchivePath, "Crash_Crates.pak"));
                templateFile = templateArchive.FindFile("Crash_Crates.igz")!;
                templateIgz = templateFile.ToIgzFile();
                templateIgz.FindObject<CEntityHandleList>("Crate_Switch_entityData_componentData_CommonCrateSwitchIron_OulinedCrates")!._data.Clear();
            }
        }

        private static void AddCrate(string type, LevelExplorer explorer)
        {
            SetupTemplateArchive();

            Console.WriteLine($"Creating crate: {type}, Bonus: {_bonusCrate}, Outline: {_outlinedCrate}, Floating: {_floatMode}");

            // Find crate template

            string templateName = $"Crate_{type}";
            string templateNameSpawned = _specialCrateTemplates.ContainsKey(templateName) ? _specialCrateTemplates[templateName] : $"{templateName}_Spawned_gen";

            CEntity? crate = templateIgz!.FindObject<CEntity>(templateName);

            if (crate == null)
            {
                Console.WriteLine("Warning: Could not find crate " + type);
                return;
            }

            crate = (CEntity)crate.Clone();

            // Apply settings

            if (_bonusCrate && crate.TryGetComponent(out common_Crate_LevelCountData? levelCountComponent) && levelCountComponent != null)
            {
                levelCountComponent._Bool = true;
            }

            if (_outlinedCrate)
            {
                CEntity outlinedCrate = (CEntity)templateIgz.FindObject<CEntity>("Crate_Basic_Outlined001")!.Clone();

                var outlineData = outlinedCrate.GetComponent<common_Crate_OutlineData>()!;
                var triggerBox = outlinedCrate.GetComponent<CTriggerVolumeBoxComponentData>()!;

                crate.AddComponent("archetype_CTriggerVolumeBoxComponentData", triggerBox);
                crate.AddComponent("archetype_Scripts.Graph.common_Crate_OutlineData", outlineData);

                var spawnerTemplate = crate.GetComponent<common_Spawner_TemplateData>()!;
                var outlineTemplate = outlinedCrate.GetComponent<common_Spawner_TemplateData>()!;

                outlineData._ReplacementEntity = spawnerTemplate._EntityToSpawn;
                spawnerTemplate._EntityToSpawn = outlineTemplate._EntityToSpawn;
            }
            
            if (_floatMode == "Water")
            {
                CEntity waterCrate = templateIgz.FindObject<CEntity>("Crate_Water_Basic")!;

                crate.AddComponent("archetype_Scripts.Graph.common_Crate_WaterData", waterCrate.GetComponent<common_Crate_WaterData>()!);
                crate.GetComponent<common_Crate_StackCheckerData>()!._Bool_0x68 = true;

            }
            else if (_floatMode == "Floating")
            {
                CPhysicalEntity crateSpawned = templateIgz.FindObject<CPhysicalEntity>(templateNameSpawned)!;
                CPhysicalEntity floatingCrateSpawned = templateIgz.FindObject<CPhysicalEntity>("Crate_Floating_Basic_Spawned_gen")!;

                var floatingComponent = floatingCrateSpawned.GetComponent<common_Crate_FloatingData>()!;
                var movementController = floatingCrateSpawned.GetComponent<CMovementControllerComponentData>()!;

                crateSpawned.AddComponent("archetype_Scripts.Graph.common_Crate_FloatingData", floatingComponent);
                crateSpawned.GetComponent<CMovementControllerComponentData>()!._controllerList = movementController._controllerList;
            }
            else if (_floatMode == "Flood")
            {
                CPhysicalEntity crateSpawned = templateIgz.FindObject<CPhysicalEntity>(templateNameSpawned)!;
                CPhysicalEntity floodCrateSpawned = templateIgz.FindObject<CPhysicalEntity>("Crate_Flood_Basic_Spawned_gen")!;

                var floodComponent = floodCrateSpawned.GetComponent<common_Crate_Flood_BehaviorData>()!;
                
                crateSpawned.AddComponent("archetype_Scripts.Graph.common_Crate_Flood_BehaviorData", floodComponent);
            }

            // Clone crate

            IgArchiveFile? destination = null;
            var mapFiles = explorer.Archive.GetFiles().Where(f => f.GetPath().StartsWith("maps/") && f.GetName().EndsWith(".igz"));

            if (_bonusCrate) destination = mapFiles.FirstOrDefault(f => f.GetName().Contains("Bonus"));
            
            destination ??= mapFiles.FirstOrDefault(f => f.GetName(false).EndsWith("_Crates"));

            string fileIdentifier = destination?.GetName(false) ?? "Crates";

            explorer.GetOrCreateIgzFile(fileIdentifier, out destination, out IgzFile crateIgz);
            explorer.Clone(crate, templateArchive, templateIgz, destination, crateIgz);

            if (_floatMode == "Floating" || _floatMode == "Flood")
            {
                templateIgz = templateFile?.ToIgzFile();
            }
        }
    
        private static void AddCollectible(string name, LevelExplorer explorer)
        {
            SetupTemplateArchive();

            name = $"Collectible_{name}";

            CEntity? collectible = templateIgz!.FindObject<CEntity>(name);

            if (collectible == null)
            {
                Console.WriteLine("Collectible not found: " + name);
                return;
            }

            explorer.GetOrCreateIgzFile("Collectibles", out IgArchiveFile collectibleFile, out IgzFile collectibleIgz);
            explorer.Clone(collectible, templateArchive, templateIgz, collectibleFile, collectibleIgz);
        }

        private static void AddRelativeCamera(LevelExplorer explorer)
        {
            CRelativeCamera relativeCamera = CreateRelativeCamera();

            explorer.GetOrCreateIgzFile("Camera", out IgArchiveFile cameraFile, out IgzFile cameraIgz);

            explorer.Clone(relativeCamera, null, null, cameraFile, cameraIgz);
        }

        private static void AddSplineCamera(LevelExplorer explorer)
        {
            IgArchive sourceArchive = IgArchive.Open(Path.Join(LocalStorage.ArchivePath, "WR_C3_LevelEndTest.pak"));
            IgArchiveFile sourceFile = sourceArchive.FindFile("WR_C3_LevelEndTest_Camera.igz")!;
            IgzFile sourceIgz = sourceFile.ToIgzFile();

            CSplineCamera? splineCamera = sourceIgz.FindObject<CSplineCamera>("Default_Camera");
            CEntity? splineEntity = sourceIgz.FindObject<CEntity>("Default_CameraSpline");

            if (splineCamera == null || splineEntity == null)
            {
                Console.WriteLine("Spline camera not found");
                return;
            }

            var points = splineEntity.GetComponent<CSplineComponentData>()?._spline?._data?._data;
            if (points != null)
            {
                points.Set(points.Take(2).ToList());
                points[1]._position._x = 500;
            }

            splineCamera.ObjectName = "Spline_Camera";
            splineEntity.ObjectName = "Spline_Camera_Entity";
            splineCamera._splineEntity.Reference!.objectName = splineEntity.ObjectName;

            explorer.GetOrCreateIgzFile("Camera", out IgArchiveFile cameraFile, out IgzFile cameraIgz);

            explorer.Clone(splineCamera, sourceArchive, sourceIgz, cameraFile, cameraIgz);
        }

        public static (CZoneInfo, igLocalizedInfo) CreateZoneInfo(string levelIdentifier, EGameYear crashMode)
        {
            string levelName = Path.GetFileNameWithoutExtension(levelIdentifier);

            igLocalizedInfo localizedInfo = new igLocalizedInfo() { ObjectName = "localizationMarker" };

            CZoneInfo zoneInfo = new CZoneInfo()
            {
                ObjectName = "CZoneInfo",
                _name = levelIdentifier,
                _saveName = levelName.ToLowerInvariant(),
                _year = crashMode,
                _overrideCharacter = "Crash",

                _displayName = "Custom Level",
                _hint = "Hello, World!",
                _platinumTime = 50,
                _goldTime = 70,
                _sapphireTime = 90,

                _levelPoolSize = new igSizeTypeMetaField() { _size = 953882908 },
                _globalChunkPoolSize = new igSizeTypeMetaField() { _size = 934805268 },
                _flags = new CZoneInfo.Flags() { _magicMomentIntro = true, _smokeTestAllMaps = true, _smokeTestAllMapsCafe = true },
                _juiceDomain = new igHandleMetaField() { Reference = new NamedReference("JuiceDomain_Story", "Domain") },
                _build = "normal,final",
                _cameraClipPlane = 35750,
                _aoBakeMaxRayDistance = 10000,

                _fastestTimeTrialLeaderboard = new CStatisticData() 
                { 
                    ObjectName = "O0",
                    _leaderboardId = ELeaderBoardID.eLBID_DEVMAPUSAGE, 
                    _writeType = CStatisticData.EStatisticWriteType.eSWT_Max
                },
                _levelObjectives = new CLevelGoalList(),
                _checkpoints = new CCheckpointList(),
                _saveData = new CZoneInfoSave(),
                
                // _saveSlotImage = new igHandleMetaField() { Reference = new NamedReference("C1SaveSlotImages_materials", "SaveSlotNSanityBeach", true) },
                // _planarReflectionsEnabled = true,
            };

            zoneInfo._levelObjectives!._data.SetActive(false);
            zoneInfo._checkpoints!._data.SetActive(false);

            zoneInfo.MemoryPool.alignment = 8;
            zoneInfo._levelObjectives.MemoryPool.alignment = 8;
            zoneInfo._checkpoints.MemoryPool.alignment = 8;
            localizedInfo.MemoryPool.alignment = 8;

            return (zoneInfo, localizedInfo);
        }

        public static CPlayerStartEntity CreatePlayerStart()
        {
            CPlayerStartEntityData playerStartData = new CPlayerStartEntityData()
            {
                ObjectName = "PlayerStart_entityData",
                _tags = new CEntityTagSet() { ObjectName = "PlayerStart_entityData_tags" },
                _componentData = new igComponentDataTable() { ObjectName = "PlayerStart_entityData_componentData" },
                _entityFlags = 782420,
            };
            playerStartData._tags.Add(NamedReference.CreateObjectReference("EntityTags", "PlayerStart"), true);
            playerStartData._tags._values._bitfield = 0x01000000;

            CPlayerStartEntity playerStart = new CPlayerStartEntity
            {
                ObjectName = "PlayerStart",
                _entityData = playerStartData,
                _transform = new igEntityTransform() { _parentSpaceRotation = new igVec3fMetaField(0, 0, MathF.PI / 2) },
                _parentSpacePosition = new igVec3fMetaField(0, 0, 200),
                _min = new igVec3fMetaField(-4.85f, -12.5f, 0),
                _max = new igVec3fMetaField(4.85f, 12.5f, 64.1f),
                _zoneStart = true,
                _bitfield = new igEntity.Bitfield
                {
                    _enabledByVisualScript = true,
                    _isMoving = true,
                    _isVolumeCulled = true,
                    _netHasAuthority = true
                },
                _properties = new CEntity.Properties
                {
                    _actToggleOn = true
                },
                _components = new igComponentList(),
                _processedSpawnPoints = new CWaypointList(),
                // _camera = new CCameraBase() { Reference = new NamedReference("Custom_Level_Camera", "DefaultCamera") },
            };

            return playerStart;
        }

        public static CRelativeCamera CreateRelativeCamera(string name = "Relative_Camera")
        {
            var safeArea = new CCameraScreenSafeArea()
            {
                ObjectName = name + "_screenSafeArea",
                _min = new igVec2fMetaField(-0.11f, -1),
                _max = new igVec2fMetaField(-0.01f, 0),
            };

            var camera = new CRelativeCamera()
            {
                ObjectName = name,
                _screenSafeArea = safeArea,
                _position = new igVec3fMetaField(0, -600, 200),
                _rotation = new igVec3fMetaField(0, 0, 90),
                _shadowBias = new igVec4fMetaField(3, 7, 15, 20),
            };

            camera.MemoryPool.alignment = 16;
            safeArea.MemoryPool.alignment = 16;

            return camera;
        }
    }
}