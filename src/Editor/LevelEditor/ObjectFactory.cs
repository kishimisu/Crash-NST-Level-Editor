using Alchemy;
using Havok;
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
        
        private static readonly Dictionary<string, (string, string)> _bonusFiles = new()
        {
            { "Tawna_Small", ("L102_JungleRollers",  "L102_JungleRollers_Bonus") },
            { "Tawna_Large", ("L106_RollingStones", "L106_RollingStones_BonusTawna") },
            { "Brio",        ("L106_RollingStones", "L106_RollingStones_BonusNBrio") },
            { "Cortex",      ("L115_SunsetVista",   "L115_SunsetVista_BonusRound_Cortex") },
        };

        private static readonly Dictionary<string, List<(string, int, uint)>> _bonusCollisions = new()
        {
            { "Tawna_Small", new() {
                ("TawnaBonusStage_Terrain001_gen", 306, 726133659),
                ("TawnaBonusStage_Terrain002_gen", 307, 2243604655)
            }},
            { "Tawna_Large", new() {
                ("TawnaBonusStage_Terrain_gen", 363, 3653174630),
                ("TawnaBonusStage_Terrain002_gen", 364, 2938897377),
                ("TawnaBonusStage_Terrain004_gen", 365, 1470977180),
            }},
            { "Brio", new() {
                ("NBrioBonusStage_Terrain_gen", 362, 1481713885),
            }},
            { "Cortex", new() {
                ("platforms_gen", 212, 3264971473),
            }}
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

                if (ImGui.BeginMenu("New bonus round..."))
                {
                    if (ImGui.MenuItem("Bonus Teleporter")) AddBonusRoundTeleporter(explorer);
                    ImGui.Separator();
                    if (ImGui.MenuItem("Tawna Small")) AddBonusRound("Tawna_Small", explorer);
                    if (ImGui.MenuItem("Tawna Large")) AddBonusRound("Tawna_Large", explorer);
                    if (ImGui.MenuItem("Brio")) AddBonusRound("Brio", explorer);
                    if (ImGui.MenuItem("Cortex")) AddBonusRound("Cortex", explorer);
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("New camera..."))
                {
                    if (ImGui.MenuItem("Relative camera")) AddRelativeCamera(explorer);
                    if (ImGui.MenuItem("Spline camera")) AddSplineCamera(explorer);
                    if (ImGui.MenuItem("Stack camera")) AddStackCamera(explorer);
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Other..."))
                {
                    if (ImGui.MenuItem("New CDynamicClipEntity")) AddCDynamicClipEntity(explorer);
                    if (ImGui.MenuItem("New Death Trigger")) AddDeathTrigger(explorer);
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
            explorer.Clone([crate], templateArchive, templateIgz, destination, crateIgz);

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
            explorer.Clone([collectible], templateArchive, templateIgz, collectibleFile, collectibleIgz);
        }

        private static void AddRelativeCamera(LevelExplorer explorer)
        {
            CRelativeCamera relativeCamera = CreateRelativeCamera();

            explorer.GetOrCreateIgzFile("Camera", out IgArchiveFile cameraFile, out IgzFile cameraIgz);

            explorer.Clone([relativeCamera], null, null, cameraFile, cameraIgz);
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

            explorer.Clone([splineCamera], sourceArchive, sourceIgz, cameraFile, cameraIgz);
        }

        private static void AddStackCamera(LevelExplorer explorer)
        {
            IgArchive sourceArchive = IgArchive.Open(Path.Join(LocalStorage.ArchivePath, "L305_MakinWaves.pak"));
            IgzFile sourceIgz = sourceArchive.FindFile("L305_MakinWaves.igz")!.ToIgzFile();

            CStackCamera stackCamera = sourceIgz.FindObject<CStackCamera>()!;

            explorer.GetOrCreateIgzFile("Camera", out IgArchiveFile cameraFile, out IgzFile cameraIgz);

            explorer.Clone([stackCamera], sourceArchive, sourceIgz, cameraFile, cameraIgz);
        }

        private static void AddCDynamicClipEntity(LevelExplorer explorer)
        {
            explorer.GetOrCreateIgzFile("Clip", out IgArchiveFile file, out IgzFile igz);

            string name = igz.FindSuitableName("CDynamicClipEntity");

            var entity = new CDynamicClipEntity() { ObjectName = name };
            var entityData = new CDynamicClipEntityData() { ObjectName = entity.ObjectName + "_entityData" };
            var componentData = new igComponentDataTable() { ObjectName = entityData.ObjectName + "_componentData" };

            entity._entityData = entityData;
            entityData._componentData = componentData;

            entity._parentSpacePosition = explorer.Camera.Position.Clone().Add( explorer.Camera.Front * 400).ToVec3MetaField();

            entity._min = new igVec3fMetaField(-800, -15, 0);
            entity._max = new igVec3fMetaField(800, 15, 300);
            entity._components = new igComponentList();
            
            entity._bitfield._enabledByVisualScript = true;
            entity._bitfield._isPositionDirty = true; // todo: set not dirty as default
            entity._bitfield._isRotationDirty = true;
            entity._bitfield._isScaleDirty = true;
            entity._bitfield._isMoving = true;
            entity._bitfield._isVolumeCulled = true;
            entity._bitfield._netHasAuthority = true;
            entity._properties._actToggleOn = true;
            entity._clipTypeStorage._clipNPCEnemies = true;
            entity._clipTypeStorage._clipNPCAltEnemies = true;
            entity._clipTypeStorage._clipPlayers = true;
            entity._clipTypeStorage._clipWorld = true;

            igz.Objects.Add(entity);

            explorer.ArchiveRenderer.SetObjectUpdated(file, entity._entityData._componentData);
            explorer.ArchiveRenderer.SetObjectUpdated(file, entity._entityData);
            explorer.ArchiveRenderer.SetObjectUpdated(file, entity._components);
            explorer.ArchiveRenderer.SetObjectUpdated(file, entity, true);

            NSTEntity clip = new NSTEntity(entity, file);
            explorer.InstanceManager.Register(clip);
            explorer.RebuildTree();
            explorer.SelectObject(clip, true);
        }

        private static void AddDeathTrigger(LevelExplorer explorer)
        {
            SetupTemplateArchive();

            CScriptTriggerEntity deathTrigger = templateIgz!.FindObject<CScriptTriggerEntity>("Hazard_Pit")!;

            deathTrigger._min = new igVec3fMetaField(-600, -300, 0);
            deathTrigger._max = new igVec3fMetaField(600, 300, 300);

            explorer.GetOrCreateIgzFile("Hazards", out IgArchiveFile hazardFile, out IgzFile hazardIgz);

            explorer.Clone([deathTrigger], templateArchive, templateIgz, hazardFile, hazardIgz, 800);
        }

        private static void AddBonusRoundTeleporter(LevelExplorer explorer)
        {
            SetupTemplateArchive();

            if (explorer.Archive.FindFile("CR1_BonusRound_Counter_Brio.igz") == null)
            {
                IgArchiveFile brioVfx = templateArchive!.FindFile("CR1_BonusRound_Counter_Brio.igz")!;
                explorer.ArchiveRenderer.AddFile(brioVfx);
            }
            if (explorer.Archive.FindFile("CR1_BonusRound_Counter_Cortex.igz") == null)
            {
                IgArchiveFile cortexVfx = templateArchive!.FindFile("CR1_BonusRound_Counter_Cortex.igz")!;
                explorer.ArchiveRenderer.AddFile(cortexVfx);
            }

            CGameEntity bonusTeleporter = templateIgz!.FindObject<CGameEntity>("BonusRoundTeleporter_Tawna")!;

            explorer.GetOrCreateIgzFile("Bonus", out IgArchiveFile bonusFile, out IgzFile bonusIgz);

            explorer.Clone([bonusTeleporter], templateArchive, templateIgz, bonusFile, bonusIgz);
        }

        private static void AddBonusRound(string type, LevelExplorer explorer)
        {
            ModalRenderer.ShowLoadingModal("Importing bonus round...");

            Task.Run(() =>
            {
                (string archiveName, string fileName) = _bonusFiles[type];

                IgArchive sourceArchive = IgArchive.Open(Path.Join(LocalStorage.ArchivePath, archiveName + ".pak"));
                IgzFile sourceIgz = sourceArchive.FindFile(fileName + ".igz")!.ToIgzFile();

                igEntity bonusPrefab = sourceIgz.FindObject<igEntity>($"BonusRound_{type}_prefab")!;

                List<igObject> crates = sourceIgz.Objects.Where(e => e.GetType() == typeof(CEntity) && e.ObjectName?.StartsWith("Crate_") == true).ToList();
                crates.Insert(0, bonusPrefab);

                explorer.GetOrCreateIgzFile($"Bonus_{type}", out IgArchiveFile bonusFile, out IgzFile bonusIgz);

                List<NSTObject> newObjects = explorer.Clone(crates, sourceArchive, sourceIgz, bonusFile, bonusIgz, 2000, true);

                IgArchiveFile collisionFile = sourceArchive.FindCollisionFile(".hkx")!;
                HavokFile havok = collisionFile.ToHavokFile();
                var compoundShape = (hknpStaticCompoundShape)havok.GetRootObjects().Find(e => e is hknpStaticCompoundShape)!;

                NSTEntity parent = (NSTEntity)newObjects.Find(e => e.GetObject().ObjectName == bonusPrefab.ObjectName)!;

                foreach ((string objectName, int collisionIndex, uint collisionHash) in _bonusCollisions[type])
                {
                    hknpShapeInstance shape = compoundShape._elements[collisionIndex];
                    NSTEntity obj = (NSTEntity)newObjects.Find(e => e.GetObject().ObjectName == objectName)!;

                    obj.ParentPrefabInstance = parent;
                    obj.CollisionShapeIndex = collisionIndex;
                    obj.CollisionPrefabHash = collisionHash;

                    explorer.ArchiveRenderer.SetEntityUpdated(obj, shape);
                }

                ModalRenderer.CloseLoadingModal();
            })
            .ContinueWith(t =>
            {
                if (t.IsFaulted && t.Exception != null)
                {
                    foreach (var ex in t.Exception.InnerExceptions)
                    {
                        CrashHandler.Log($"Error importing bonus round: {ex.Message}\n{ex.StackTrace}");
                    }
                    string logPath = CrashHandler.WriteLogsToFile();
                    ModalRenderer.ShowMessageModal("Error", $"An error occured while importing the bonus round\n\nLog file: {logPath}");
                }
            }, 
            TaskContinuationOptions.OnlyOnFaulted);
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