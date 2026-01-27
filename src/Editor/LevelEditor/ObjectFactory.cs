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
        private static string _gemColor = "Clear";
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
                        if (ImGui.MenuItem(displayName)) TryAddObject(() => AddCrate(objectName, explorer));
                    }

                    if (ImGui.MenuItem("Big TNT")) TryAddObject(() => AddBigTNTCrate(explorer));

                    ImGui.Separator();

                    if (ImGui.BeginMenu("Iron crate..."))
                    {
                        foreach ((string displayName, string objectName) in _crateNames["Iron"])
                        {
                            if (ImGui.MenuItem(displayName)) TryAddObject(() => AddCrate(objectName, explorer));
                        }
                        ImGui.EndMenu();
                    }
                    ImGui.Separator();

                    if (ImGui.BeginMenu("Bonus crate..."))
                    {
                        foreach ((string displayName, string objectName) in _crateNames["Bonus"])
                        {
                            if (ImGui.MenuItem(displayName)) TryAddObject(() => AddCrate(objectName, explorer));
                        }
                        ImGui.EndMenu();
                    }

                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("New collectible..."))
                {
                    foreach ((string displayName, string objectName) in _collectibleNames)
                    {
                        if (ImGui.MenuItem(displayName)) TryAddObject(() => AddCollectible(objectName, explorer));
                    }

                    if (ImGui.BeginMenu("Gem..."))
                    {
                        foreach (string name in _gemNames)
                        {
                            if (ImGui.MenuItem(name + " Gem")) TryAddObject(() => AddCollectible("Gem_" + name, explorer));
                        }
                        ImGui.EndMenu();
                    }
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("New platform..."))
                {
                    if (ImGui.BeginMenu("Gem Platform..."))
                    {
                        ImGuiUtils.Prefix("Gem Color:");
                        if (ImGui.BeginCombo("##GemColor", _gemColor))
                        {
                            foreach (string col in _gemNames)
                            {
                                if (ImGui.MenuItem(col)) _gemColor = col;
                            }
                            ImGui.EndCombo();
                        }
                        ImGui.Separator();
                        if (ImGui.MenuItem("Floating Gem Platform")) TryAddObject(() => AddGenericTemplate("Gem_Platform_" + _gemColor, "Platforms", explorer));
                        if (ImGui.MenuItem("Moving Gem Platform"))
                        {
                            string platformName = (_gemColor == "Orange" ? "C2_" : "") + "Gem_Path_Platform_Start_";
                            TryAddObject(() => AddGenericTemplate(platformName + _gemColor, "Platforms", explorer));
                        }
                        ImGui.EndMenu();
                    }

                    if (ImGui.MenuItem("Fade In/Out Teleporter")) TryAddObject(() => AddGeneric("L202_SnowGo", "L202_SnowGo", "Generic_Path_Platform_Start_FadeOut", "Platforms", explorer, objects =>
                    {
                        if (objects.Count == 4 && objects[0] is NSTEntity start && objects[3] is NSTEntity end)
                        {
                            end.Object._parentSpacePosition = new igVec3fMetaField(start.Position.X + 600, start.Position.Y, start.Position.Z - 500);
                            explorer.SelectionManager.UpdateSelection([end], false);
                        }
                    }));
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("New vehicle..."))
                {
                    if (ImGui.MenuItem("JetBoard")) TryAddObject(() => AddGeneric("L203_HangEight", "L203_HangEight", "Spawner_RideBoard", "Vehicles", explorer));
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("New bonus round..."))
                {
                    if (ImGui.BeginMenu("C1"))
                    {
                        if (ImGui.MenuItem("Bonus Teleporter")) TryAddObject(() => AddBonusRoundTeleporter(explorer));
                        ImGui.Separator();
                        if (ImGui.MenuItem("Tawna Small")) AddBonusRound("Tawna_Small", explorer);
                        if (ImGui.MenuItem("Tawna Large")) AddBonusRound("Tawna_Large", explorer);
                        if (ImGui.MenuItem("Brio"))        AddBonusRound("Brio", explorer);
                        if (ImGui.MenuItem("Cortex"))      AddBonusRound("Cortex", explorer);
                        ImGui.EndMenu();
                    }
                    if (ImGui.BeginMenu("C2"))
                    {
                        // L202, L206, L218, L221, L225: Trigger Zone Drop (snow, machinery)

                        ImGui.SeparatorText("Platform Up");
                        if (ImGui.MenuItem("L203_HangEight"))    AddC2BonusRound("L203_HangEight", explorer);
                        if (ImGui.MenuItem("L205_CrashDash"))    AddC2BonusRound("L205_CrashDash", explorer);
                        if (ImGui.MenuItem("L207_AirCrash"))     AddC2BonusRound("L207_AirCrash", explorer);
                        if (ImGui.MenuItem("L211_PlantFood"))    AddC2BonusRound("L211_PlantFood", explorer);

                        ImGui.SeparatorText("Platform Drop");
                        // if (ImGui.MenuItem("L201_TurtleWoods (X)")) AddC2BonusRound("L201_TurtleWoods", explorer); // crash on exit
                        if (ImGui.MenuItem("L204_ThePits"))      AddC2BonusRound("L204_ThePits", explorer);
                        // if (ImGui.MenuItem("L209_CrashCrush (X)"))  AddC2BonusRound("L209_CrashCrush", explorer);  // no tp
                        if (ImGui.MenuItem("L215_UnBearable"))   AddC2BonusRound("L215_UnBearable", explorer);
                        if (ImGui.MenuItem("L217_DigginIt"))     AddC2BonusRound("L217_DigginIt", explorer);
                        if (ImGui.MenuItem("L220_BeeHaving"))    AddC2BonusRound("L220_BeeHaving", explorer);
                        if (ImGui.MenuItem("L223_NightFight"))   AddC2BonusRound("L223_NightFight", explorer);
                        // if (ImGui.MenuItem("L227_TotallyFly (X)"))  AddC2BonusRound("L227_TotallyFly", explorer);  // no tp

                        ImGui.SeparatorText("Platform Down");
                        if (ImGui.MenuItem("L210_TheEelDeal"))   AddC2BonusRound("L210_TheEelDeal", explorer);
                        if (ImGui.MenuItem("L212_SewerOrLater")) AddC2BonusRound("L212_SewerOrLater", explorer);
                        if (ImGui.MenuItem("L216_HanginOut"))    AddC2BonusRound("L216_HanginOut", explorer);

                        ImGui.SeparatorText("Platform Path");
                        if (ImGui.MenuItem("L214_RoadToRuin"))   AddC2BonusRound("L214_RoadToRuin", explorer);
                        if (ImGui.MenuItem("L219_Ruination")) AddC2BonusRound("L219_Ruination", explorer);

                        ImGui.EndMenu();
                    }
                    if (ImGui.BeginMenu("C3"))
                    {
                        ImGui.SeparatorText("Medieval");
                        if (ImGui.MenuItem("L301_ToadVillage"))     AddC2BonusRound("L301_ToadVillage", explorer);
                        // if (ImGui.MenuItem("L306_GeeWiz"))       AddC2BonusRound("L306_GeeWiz", explorer);       // no tp
                        // if (ImGui.MenuItem("L315_DoubleHeader")) AddC2BonusRound("L315_DoubleHeader", explorer); // no tp

                        ImGui.SeparatorText("Prehistoric");
                        if (ImGui.MenuItem("L304_BoneYard"))     AddC2BonusRound("L304_BoneYard", explorer); // (cam issue on exit)
                        if (ImGui.MenuItem("L311_DinoMight"))    AddC2BonusRound("L311_DinoMight", explorer);

                        ImGui.SeparatorText("Ancient Egypt");
                        if (ImGui.MenuItem("L309_TombTime"))     AddC2BonusRound("L309_TombTime", explorer);
                        if (ImGui.MenuItem("L316_Sphynxinator")) AddC2BonusRound("L316_Sphynxinator", explorer);
                        if (ImGui.MenuItem("L320_TombWader"))    AddC2BonusRound("L320_TombWader", explorer);
                        if (ImGui.MenuItem("L325_BugLite"))      AddC2BonusRound("L325_BugLite", explorer);
                        
                        ImGui.SeparatorText("Future");
                        // if (ImGui.MenuItem("L319_FutureFrenzy")) AddC2BonusRound("L319_FutureFrenzy", explorer); // (missing background + platforms)
                        // if (ImGui.MenuItem("L321_GoneTomorrow")) AddC2BonusRound("L321_GoneTomorrow", explorer); // (missing background + platforms)
                        if (ImGui.MenuItem("L333_FutureTense"))  AddC2BonusRound("L333_FutureTense", explorer);

                        // ImGui.SeparatorText("Middle Eastern");
                        // if (ImGui.MenuItem("L307_HangemHigh"))     AddC2BonusRound("L307_HangemHigh", explorer);     // (missing background)
                        // if (ImGui.MenuItem("L313_HighTime"))       AddC2BonusRound("L313_HighTime", explorer);       // (missing background)
                        // if (ImGui.MenuItem("L323_FlamingPassion")) AddC2BonusRound("L323_FlamingPassion", explorer); // (missing background)

                        ImGui.EndMenu();
                    }

                    // if (ImGui.MenuItem("Generic Platform Path")) AddPlatformPath("Generic", explorer);
                    // if (ImGui.MenuItem("Bonus Platform Path")) AddPlatformPath("Bonus", explorer);
                    // if (ImGui.MenuItem("Death Platform Path")) AddPlatformPath("Death", explorer);
                    
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("New camera..."))
                {
                    if (ImGui.MenuItem("Relative camera")) TryAddObject(() => AddRelativeCamera(explorer));
                    if (ImGui.MenuItem("Spline camera")) TryAddObject(() => AddSplineCamera(explorer));
                    if (ImGui.MenuItem("Free camera")) TryAddObject(() => AddStackCamera(explorer));
                    if (ImGui.MenuItem("Camera Box")) TryAddObject(() => AddCameraBox(explorer));
                    if (ImGui.MenuItem("Camera Trigger")) TryAddObject(() => AddCameraTrigger(explorer));
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Other..."))
                {
                    if (ImGui.MenuItem("New DynamicClipEntity")) TryAddObject(() => AddCDynamicClipEntity(explorer));
                    if (ImGui.MenuItem("New Death Trigger")) TryAddObject(() => AddDeathTrigger(explorer));
                    ImGui.Separator();
                    if (ImGui.MenuItem("New Boost Pad")) TryAddObject(() => AddGenericTemplate("Chase_BoostPad", "Platforms", explorer));
                    if (ImGui.MenuItem("New Bounce Mine")) TryAddObject(() => AddGenericTemplate("Chase_BounceMine", "Hazards", explorer));
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
                templateIgz.FindObject<CVfxTextComponentData>("Crate_Checkpoint_entityData_componentData_VfxText_gen")!._displayText = "Checkpoint";
                templateIgz.FindObject<common_Collectible_TimeTrial_StartData>("Collectible_TimeTrial_Start_entityData_componentData_CommonCollectibleTimeTrialStart_gen")!._Bool = true;
            }
        }

        private static void TryAddObject(Action callback)
        {
            try
            {
                callback();
            }
            catch (Exception e)
            {
                ModalRenderer.ShowMessageModal("Could not create the object", "An error occured while creating the object(s):\n\n" + e.Message);
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

            crate = (CEntity)crate.Clone(new());

            // Apply settings

            if (_bonusCrate && crate.TryGetComponent(out common_Crate_LevelCountData? levelCountComponent) && levelCountComponent != null)
            {
                levelCountComponent._Bool = true;
            }

            if (_outlinedCrate)
            {
                CEntity outlinedCrate = (CEntity)templateIgz.FindObject<CEntity>("Crate_Basic_Outlined001")!.Clone(new());

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

            string fileIdentifier = _bonusCrate ? "BonusCrates" : "Crates";
            explorer.GetOrCreateIgzFile(fileIdentifier, out IgArchiveFile destination, out IgzFile crateIgz);
            explorer.Clone([crate], templateArchive, templateIgz, destination, crateIgz, initializeObjects: true);

            if (_floatMode == "Floating" || _floatMode == "Flood")
            {
                templateIgz = templateFile?.ToIgzFile();
            }
        }

        private static void AddBigTNTCrate(LevelExplorer explorer)
        {
            SetupTemplateArchive();

            CEntity spawner = templateIgz!.FindObject<CEntity>("Crate_BigTNT")!;

            IgArchive ripperRooArchive = IgArchive.Open(Path.Combine(LocalStorage.ArchivePath, "B102_RipperRoo.pak"));
            IgArchiveFile ripperRooFile = ripperRooArchive.FindFile("B102_RipperRoo.igz")!;
            IgzFile ripperRooIgz = ripperRooFile.ToIgzFile();

            CPhysicalEntity template = ripperRooIgz.FindObject<CPhysicalEntity>("BossRipperRoo_BigTNT_Character_gen")!;

            explorer.GetOrCreateIgzFile("Crates", out IgArchiveFile crateFile, out IgzFile crateIgz);

            var spawnerClone = explorer.Clone([spawner], templateArchive, templateIgz, crateFile, crateIgz).FirstOrDefault();
            var templateClone = explorer.Clone([template], ripperRooArchive, ripperRooIgz, crateFile, crateIgz, addToSelection: null).FirstOrDefault();

            if (spawnerClone is NSTEntity spawnerEntity && templateClone is NSTEntity templateEntity)
            {
                templateEntity.Object.RemoveComponent("archetype_Scripts.Graph.BossRipperRoo_CrateHandlerData");

                spawnerEntity.Object.GetComponent<common_Spawner_TemplateData>()!._EntityToSpawn.Reference = templateEntity.ToReference();
                spawnerEntity.RefreshModel(explorer, templateEntity.Model!);
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
            explorer.Clone([collectible], templateArchive, templateIgz, collectibleFile, collectibleIgz, initializeObjects: true, offsetZ: 75.0f);
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
            splineEntity.ObjectName = "Spline_Camera_Path";
            splineCamera._splineEntity.Reference!.objectName = splineEntity.ObjectName;

            explorer.GetOrCreateIgzFile("Camera", out IgArchiveFile cameraFile, out IgzFile cameraIgz);

            explorer.Clone([splineCamera], sourceArchive, sourceIgz, cameraFile, cameraIgz, initializeObjects: true);
        }

        private static void AddStackCamera(LevelExplorer explorer)
        {
            IgArchive sourceArchive = IgArchive.Open(Path.Join(LocalStorage.ArchivePath, "L305_MakinWaves.pak"));
            IgzFile sourceIgz = sourceArchive.FindFile("L305_MakinWaves.igz")!.ToIgzFile();

            CStackCamera stackCamera = sourceIgz.FindObject<CStackCamera>()!;
            stackCamera.ObjectName = "StackCamera";

            explorer.GetOrCreateIgzFile("Camera", out IgArchiveFile cameraFile, out IgzFile cameraIgz);

            explorer.Clone([stackCamera], sourceArchive, sourceIgz, cameraFile, cameraIgz);
        }

        private static void AddCameraBox(LevelExplorer explorer)
        {
            CCameraBox cameraBox = new CCameraBox() { ObjectName = "CameraBox" };

            cameraBox._rotation = new igVec3fMetaField(0, 0, 90);
            cameraBox._min = new igVec3fMetaField(-200, -500, 0);
            cameraBox._max = new igVec3fMetaField(200, 500, 1200);

            cameraBox._cameraBlends = new CCameraBlendList();

            cameraBox._cameraModel._unknown_0xa0 = new igVec3fMetaField(4000, 8000, 16000);
            cameraBox._cameraModel._unknown_0xac = new igVec3fMetaField(24000, 500, 1);
            cameraBox._cameraModel._unknown_0xb8 = new igVec3fMetaField(1000, 1000, 1500);

            cameraBox.MemoryPool.alignment = 16;
            cameraBox._cameraBlends.MemoryPool.alignment = 16;

            explorer.GetOrCreateIgzFile("Camera", out IgArchiveFile cameraFile, out IgzFile cameraIgz);
            explorer.Clone([cameraBox], null, null, cameraFile, cameraIgz, 800);
        }

        private static void AddCameraTrigger(LevelExplorer explorer)
        {
            IgArchive sourceArchive = IgArchive.Open(Path.Join(LocalStorage.ArchivePath, "L201_TurtleWoods.pak"));
            IgzFile sourceIgz = sourceArchive.FindFile("L201_TurtleWoods_Hazards.igz")!.ToIgzFile();

            var trigger = sourceIgz.FindObject<CScriptTriggerEntity>("MousePit_CameraTrigger00")!;
            var triggerComponent = trigger.GetComponent<L201_TurtleWoods_MousePit_CameraTriggerData>()!;

            trigger.ObjectName = "CameraTrigger";
            trigger._min = new igVec3fMetaField(-500, -200, 0);
            trigger._max = new igVec3fMetaField(500, 200, 1200);
            triggerComponent._Camera_Base_0x28.Reference = null;
            triggerComponent._Camera_Base_0x38.Reference = null;

            explorer.GetOrCreateIgzFile("Hazards", out IgArchiveFile hazardFile, out IgzFile hazardIgz);
            explorer.Clone([trigger], sourceArchive, sourceIgz, hazardFile, hazardIgz, 800, initializeObjects: true);
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

            explorer.Clone([bonusTeleporter], templateArchive, templateIgz, bonusFile, bonusIgz, initializeObjects: true);
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

                List<NSTObject> newObjects = explorer.Clone(crates, sourceArchive, sourceIgz, bonusFile, bonusIgz, 2000, true, true);

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

                explorer.InstanceManager.RefreshInstances(explorer.InstanceManager.AllObjects);

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
            }, TaskContinuationOptions.OnlyOnFaulted);
        }

        private static void AddGeneric(string archiveName, string fileName, string objectName, string identifier, LevelExplorer explorer, Action<List<NSTObject>>? callback = null)
        {
            IgArchive sourceArchive = IgArchive.Open(Path.Combine(LocalStorage.ArchivePath, archiveName + ".pak"));
            IgzFile sourceIgz = sourceArchive.FindFile(fileName, FileSearchType.Name, FileSearchParams.MapIgz)!.ToIgzFile();
            
            igObject obj = sourceIgz.FindObject<igObject>(objectName)!;

            explorer.GetOrCreateIgzFile(identifier, out IgArchiveFile dstFile, out IgzFile dstIgz);

            var clones = explorer.Clone([obj], sourceArchive, sourceIgz, dstFile, dstIgz, addToSelection: false, initializeObjects: true);

            callback?.Invoke(clones);
        }

        private static void AddGenericTemplate(string name, string identifier, LevelExplorer explorer)
        {
            SetupTemplateArchive();
            
            igObject obj = templateIgz!.FindObject<igObject>(name)!;

            explorer.GetOrCreateIgzFile(identifier, out IgArchiveFile dstFile, out IgzFile dstIgz);

            explorer.Clone([obj], templateArchive, templateIgz, dstFile, dstIgz, initializeObjects: true);
        }

        private static readonly List<string> _bonusFileNames = [ 
            "", "Art", "Camera", "Art_Bonus", "Crates_Bonus", "Bonus",
            "BonusArea", "BonusAreas", "BonusRound", "BonusPath", "BonusZone",
            "Crates", "Collectibles", "Geo", "Hazards", "Platforms",
        ];
        private static readonly List<string> _bonusAdditionalObjects = [
            "HolePitrim02", "Teleportbase", "PineTree01_2480", "platform01_19"
        ];
        private static readonly List<string> _bonusExcludedObjects = [
            "CameraSpline_Main_F5", "CameraSpline_BonusAreaLong_H1", "CameraSpline_BonusAreaLong_H2", // L214_RoadToRuin
            "BonusLarge_FireStatueRotating_StartTrigger" // L219_Ruination
        ];
        private static readonly Dictionary<string, (THREE.Vector3, THREE.Vector3, THREE.Vector3, bool)> _bonusBounds = new()
        {
            // { "L201_TurtleWoods_DeathRoute", (new THREE.Vector3(-27575, 25860, -1489), new THREE.Vector3(-9000, -3000, -2000), new THREE.Vector3(9000, 2000, 2000)) }
            { "L201_TurtleWoods", (new THREE.Vector3(33750, 26993, 5579), new THREE.Vector3(-4000, -3000, 0), new THREE.Vector3(4000, 3000, 0), true ) },
            { "L203_HangEight", (new THREE.Vector3(34914, 16492, 2071), new THREE.Vector3(-10000, -10000, 0), new THREE.Vector3(10000, 10000, 0), true ) },
            { "L204_ThePits", (new THREE.Vector3(35965, 21361, 648), new THREE.Vector3(-10000, -10000, 0), new THREE.Vector3(10000, 10000, 0), true ) },
            { "L205_CrashDash", (new THREE.Vector3(-38948, 26365, 1260), new THREE.Vector3(-10000, -10000, 0), new THREE.Vector3(10000, 10000, 0), true ) },
            { "L207_AirCrash", (new THREE.Vector3(-13771, 32917, 19342), new THREE.Vector3(-8000, -6000, 0), new THREE.Vector3(8000, 6000, 0), true ) },
            { "L209_CrashCrush", (new THREE.Vector3(-14949, 10000, -2923), new THREE.Vector3(-5000, -5000, 0), new THREE.Vector3(5000, 5000, 0), true ) },
            { "L210_TheEelDeal", (new THREE.Vector3(-16478, 7707, 39891), new THREE.Vector3(-7000, -3000, 0), new THREE.Vector3(6000, 4000, 0), true ) },
            { "L211_PlantFood", (new THREE.Vector3(-42910, 23331, 10836), new THREE.Vector3(-12000, -10000, 0), new THREE.Vector3(12000, 10000, 0), true ) },
            { "L212_SewerOrLater", (new THREE.Vector3(-18379, 20428, 41868), new THREE.Vector3(-8000, -5000, 0), new THREE.Vector3(8000, 5000, 0), true ) },
            { "L214_RoadToRuin", (new THREE.Vector3(16488, 11993, -258), new THREE.Vector3(-3744, -1200, 0), new THREE.Vector3(2945, 400, 0), false ) },
            { "L215_UnBearable", (new THREE.Vector3(-16895, -441, 428), new THREE.Vector3(-5000, -5000, 0), new THREE.Vector3(5000, 5000, 0), true ) },
            { "L216_HanginOut", (new THREE.Vector3(-13020, 12012, 33049), new THREE.Vector3(-8000, -2000, 0), new THREE.Vector3(6000, 4000, 0), true ) },
            { "L217_DigginIt", (new THREE.Vector3(-13016, 70280, 3143), new THREE.Vector3(-5000, -5000, 0), new THREE.Vector3(5000, 5000, 0), true ) },
            { "L219_Ruination", (new THREE.Vector3(1718, -2916, 22), new THREE.Vector3(-2742, -520, 0), new THREE.Vector3(2847, 1050, 0), false ) },
            { "L220_BeeHaving", (new THREE.Vector3(41045, 43217, 3375), new THREE.Vector3(-5000, -3000, 0), new THREE.Vector3(5000, 2000, 0), true ) },
            { "L223_NightFight", (new THREE.Vector3(-24033, 4957, 3281), new THREE.Vector3(-7000, -5000, 0), new THREE.Vector3(7000, 5000, 0), true ) },
            { "L227_TotallyFly", (new THREE.Vector3(-28188, 43342, -5128), new THREE.Vector3(-7000, -5000, 0), new THREE.Vector3(7000, 5000, 0), true ) },
            { "L301_ToadVillage", (new THREE.Vector3(-52727, 3608, 3579), new THREE.Vector3(-10000, -6000, 0), new THREE.Vector3(10000, 6000, 0), true ) },
            { "L304_BoneYard", (new THREE.Vector3(34867, -10701, 372), new THREE.Vector3(-7000, -5000, 0), new THREE.Vector3(7000, 5000, 0), true ) },
            { "L306_GeeWiz", (new THREE.Vector3(-44536, 80656, -3670), new THREE.Vector3(-10000, -7000, 0), new THREE.Vector3(10000, 7000, 0), true ) },
            { "L307_HangemHigh", (new THREE.Vector3(13356, 11205, 2252), new THREE.Vector3(-3000, -1000, 0), new THREE.Vector3(5000, 1000, 0), false ) },
            { "L309_TombTime", (new THREE.Vector3(7352, 11230, 312), new THREE.Vector3(-4000, -2000, 0), new THREE.Vector3(4000, 4000, 0), false ) },
            { "L311_DinoMight", (new THREE.Vector3(41876, 66312, 480), new THREE.Vector3(-7000, -4000, 0), new THREE.Vector3(7000, 4000, 0), true ) },
            { "L313_HighTime", (new THREE.Vector3(6321, 1272, 2311), new THREE.Vector3(-2700, -1500, 0), new THREE.Vector3(2700, 200, 0), false ) },
            { "L315_DoubleHeader", (new THREE.Vector3(21404, 78981, -3997), new THREE.Vector3(-10000, -7000, 0), new THREE.Vector3(10000, 7000, 0), true ) },
            { "L316_Sphynxinator", (new THREE.Vector3(-1953, 36027, 543), new THREE.Vector3(-4000, -3000, 0), new THREE.Vector3(3500, 3000, 0), false ) },
            { "L319_FutureFrenzy", (new THREE.Vector3(32385, 14949, -778), new THREE.Vector3(-3500, -1600, -2000), new THREE.Vector3(3000, 1000, 1000), false ) },
            { "L320_TombWader", (new THREE.Vector3(6311, 12373, 33), new THREE.Vector3(-4500, -3000, 0), new THREE.Vector3(6000, 3000, 0), false ) },
            { "L323_FlamingPassion", (new THREE.Vector3(-3485, 16910, 4165), new THREE.Vector3(-3000, -1000, 0), new THREE.Vector3(3000, 1000, 0), false ) },
            { "L325_BugLite", (new THREE.Vector3(37704, 40242, 54300), new THREE.Vector3(-4000, -1000, 0), new THREE.Vector3(4000, 2000, 0), false ) },
            { "L333_FutureTense", (new THREE.Vector3(25651, 25118, 919), new THREE.Vector3(-4000, -1000, 0), new THREE.Vector3(4000, 6000, 0), true ) },
        };

        private static void AddC2BonusRound(string archiveName, LevelExplorer explorer)
        {
            ModalRenderer.ShowLoadingModal("Importing bonus round... (this can take a few seconds)");
            Task.Run(() =>
            {
                AddC2BonusRoundInternal(archiveName, explorer);
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
            }, TaskContinuationOptions.OnlyOnFaulted);
        }

        private static void AddC2BonusRoundInternal(string archiveName, LevelExplorer explorer)
        {
            var archive = IgArchive.Open(Path.Join(LocalStorage.ArchivePath, archiveName + ".pak"));
            var collisionData = StaticCollisionsUtils.GetCollisionData(archive);
            var collisionFile = archive.FindCollisionFile(".hkx")!.ToHavokFile();
            var compoundShape = (hknpCompoundShape)collisionFile.GetRootObjects().Find(e => e is hknpCompoundShape)!;

            (THREE.Vector3 center, THREE.Vector3 min, THREE.Vector3 max, bool isTeleport) = _bonusBounds[archiveName];
            THREE.Box3 bounds = new THREE.Box3(center + min, center + max);

            if (min.Z == 0 && max.Z == 0)
            {
                bounds.Min.Z = -1e6f; 
                bounds.Max.Z = 1e6f;
            }

            List<NSTObject> selection = [];

            foreach (string fileName in _bonusFileNames)
            {
                IgArchiveFile? archiveFile = archive.FindFile(fileName == "" ? $"{archiveName}.igz" : $"{archiveName}_{fileName}.igz");
                IgzFile? srcIgz = archiveFile?.ToIgzFile();
                if (srcIgz == null) continue;

                List<igObject> entities = [];
                Dictionary<igObject, igObject> clones = [];
                Dictionary<igEntity, hknpShapeInstance> collisionEntities = [];

                foreach (igObject obj in srcIgz.Objects)
                {
                    if (obj is not igEntity entity) continue;
                    if (_bonusExcludedObjects.Any(e => e == entity.ObjectName)) continue;

                    bool valid = bounds.ContainsPoint(entity._parentSpacePosition.ToVector3());
                    
                    if (!valid && entity.ObjectName?.StartsWith("Crate_") == false)
                    {
                        valid |= (entity.ObjectName?.Contains("Bonus") == true && entity.ObjectName?.Contains("Death") == false) ||
                                  entity.ObjectName?.Contains("Path_AltCheckpointEntity") == true ||
                                  _bonusAdditionalObjects.Any(e => entity.ObjectName == e);
                    }

                    if (!valid) continue;

                    // Find objects with collisions
                    HashedReference reference = obj.ToNamedReference(srcIgz.GetName(false)).ToEXID();
                    if (collisionData.TryGetValue(reference, out int collisionShapeIndex))
                    {
                        collisionEntities.Add(entity, compoundShape._elements[collisionShapeIndex]);
                    }

                    // Remove L301 nested prefabs
                    if (entity.ObjectName == "BonusCastleMoat") 
                    {
                        var prefabComponentData = entity.GetComponent<igPrefabComponentData>()!._prefabEntities!._data;
                        foreach (igEntity child in prefabComponentData.ToList())
                        {
                            if (child.TryGetComponent<igPrefabComponentData>(out _))
                            {
                                prefabComponentData.Remove(child);
                            }
                        }
                    }

                    entities.Add(entity);
                }

                if (entities.Count == 0) continue;

                // Clone objects
                explorer.GetOrCreateIgzFile(fileName, out IgArchiveFile bonusFile, out IgzFile bonusIgz);

                var objs = explorer.Clone(entities, archive, srcIgz, bonusFile, bonusIgz, initializeObjects: true, addToSelection: null, clones: clones);

                // Add new collisions
                foreach ((igEntity entity, hknpShapeInstance shape) in collisionEntities)
                {
                    igObject cloneObject = clones[entity];
                    NSTEntity cloneEntity = (NSTEntity)objs.Find(o => o is NSTEntity e && e.Object == cloneObject)!;
                    explorer.ArchiveRenderer.SetEntityUpdated(cloneEntity, shape);
                }

                // Update handles
                foreach ((igObject src, igObject dst) in clones)
                {
                    foreach (var handle in dst.GetHandles())
                    {
                        if (handle.namespaceName.StartsWith(archiveName))
                        {
                            IgArchiveFile? refFile = archive.FindFile(handle.namespaceName, FileSearchType.Name);
                            if (refFile == null || !refFile.GetPath().StartsWith("maps/")) continue;

                            string id = handle.namespaceName.Replace(archiveName, "");
                            
                            id = explorer.GetFileNameFromIdentifier(id);
                            // Console.WriteLine($"Updated handle for {dst} ({handle.namespaceName} => {id}) exid: {handle.isEXID}");
                            handle.namespaceName = id;
                            handle.isEXID = false;
                        }
                    }
                }

                foreach (NSTObject obj in objs)
                {
                    igObject original = clones.First(e => e.Value == obj.GetObject()).Key;

                    // Update selection
                    if (original.ObjectName == "Bonus_Path_Platform_Start_FadeOut" || 
                        original.ObjectName == "Bonus_Path_Drop_Platform_Start" || 
                        original.ObjectName == "Bonus_Path_Platform_Start")
                    {
                        selection.Insert(0, obj);
                    }
                    else if (obj is NSTEntity entity && !entity.IsPrefabInstance && !entity.IsPrefabChild && entity.IsSpawned
                             && (!isTeleport || !bounds.ContainsPoint(entity.Position))
                             )
                    {
                        selection.Add(obj);
                    }

                    if (obj is not NSTEntity e || !e.IsPrefabInstance) continue;

                    // Find prefab collisions
                    foreach (NSTEntity child in e.Children.OfType<NSTEntity>())
                    {
                        if (!child.IsPrefabChild) continue;

                        var entityPos = new THREE.Vector3();
                        child.ObjectToWorld().Decompose(entityPos, new THREE.Quaternion(), new THREE.Vector3());

                        for (int i = 0; i < compoundShape._elements.Count; i++)
                        {
                            var shape = compoundShape._elements[i];
                            var havokPos = new THREE.Vector3(shape._transform.M41, shape._transform.M42, shape._transform.M43);
                            float distance = havokPos.DistanceTo(entityPos * 0.0254f);
                            
                            if (distance < 0.01f)
                            {
                                child.CollisionShapeIndex = i;
                                child.CollisionPrefabHash = collisionData.First(e => e.Value == i).Key.objectHash;
                                explorer.ArchiveRenderer.SetEntityUpdated(child, shape);
                                break;
                            }
                        }
                    }
                }
            }

            explorer.SelectionManager.UpdateSelection(selection);
            explorer.MoveSelectionToCamera(isTeleport ? 400 : 2000);
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