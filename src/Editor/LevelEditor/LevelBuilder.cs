using Alchemy;
using ImGuiNET;
using System.Reflection;

namespace NST
{
    public static class LevelBuilder
    {
        public static readonly string[] CrashModes = [ "Crash 1", "Crash 2", "Crash 3" ];
        public static readonly string[] CrashCharacters = [ "Crash", "Coco" ]; // , "BlasterTech", "BruiserUndead" ];
        private static int _currentMode = 0;
        public static bool _newLevelOpen = false;

        private static int _selectedLevel = 2;
        private static int _selectedLighting = 1;
        private static int _selectedMusic = 1;

        private static string[]? _levels = null;
        private static string[]? _baseLevels = null;
        private static string[]? _musicLevels = null;

        public static void Render()
        {
            if (!_newLevelOpen)
            {
                ImGui.SeparatorText("Level Editor    ");

                ImGui.SameLine();
                ImGui.SetCursorPosX(ImGui.GetCursorPosX() - ImGui.CalcTextSize("    ").X);
                ImGui.TextDisabled("(?)");
                ImGui.SetItemTooltip("Create, edit and play custom levels (.pak):\n\n- New Level: Create a new level from scratch or based on an existing level\n- Open Level Editor: Open an existing level using the level editor\n- Play Custom Level: Launch the game and load the selected level");
                ImGuiUtils.VerticalSpacing(10);

                System.Numerics.Vector2 size = new System.Numerics.Vector2(200, 0);

                if (ImGuiUtils.CenteredButton("New Level...", size))
                {
                    _newLevelOpen = true;
                }
                ImGui.Spacing();

                if (ImGuiUtils.CenteredButton("Open Level Editor", size))
                {
                    List<string> files = FileExplorer.OpenFiles(LocalStorage.ArchivePath, FileExplorer.EXT_ARCHIVES, false);
                    if (files.Count == 0) return;

                    try
                    {
                        App.OpenArchive(files[0], true);
                    }
                    catch (Exception e)
                    {
                        ModalRenderer.ShowMessageModal("Error", e.Message);
                    }
                }
                
                ImGuiUtils.VerticalSpacing(10);

                if (ImGuiUtils.CenteredButton("Play Custom Level", size))
                {
                    List<string> files = FileExplorer.OpenFiles(LocalStorage.ArchivePath, FileExplorer.EXT_ARCHIVES, false);
                    if (files.Count == 0) return;
                    IgArchive.Open(files[0]).TryRunLevel();
                }
            }
            else
            {
                if (_baseLevels == null || _levels == null || _musicLevels == null)
                {
                    List<string> levels = ModManager._levels.Skip(1).ToList();
                    _levels = levels.ToArray();

                    _musicLevels = levels.Where((_, i) => i < 106).ToArray();

                    levels.Insert(0, "none");
                    _baseLevels = levels.ToArray();
                }

                ImGui.SeparatorText("Create new level");
                ImGuiUtils.VerticalSpacing(10);

                ImGui.Text("Base Level:");
                ImGui.SameLine(100);
                if (ImGui.Combo("##SelectedBaseLevel", ref _selectedLevel, _baseLevels, _baseLevels.Length))
                {
                    if (_selectedLevel != 0)
                    {
                        _selectedLighting = _selectedMusic = _selectedLevel - 1;
                        _currentMode = GetGameYearInt(_baseLevels[_selectedLevel].Split("/").First().ToLowerInvariant());
                    }
                }
                ImGui.SameLine(); 
                float buttonEndX = ImGui.GetCursorPosX() - ImGui.GetStyle().ItemSpacing.X;
                ImGui.TextDisabled("(?)");
                ImGui.SetItemTooltip("- Choose \"none\" to create a new empty level\n- Or choose an existing level to use as a base");
                
                ImGui.Separator();

                if (_selectedLevel != 0) ImGui.BeginDisabled();

                ImGui.Text("Lighting:");
                ImGui.SameLine(100);
                ImGui.Combo("##SelectedLighting", ref _selectedLighting, _levels, _levels.Length);
                ImGui.SameLine(); ImGui.TextDisabled("(?)");
                ImGui.SetItemTooltip("These options are only available if the base level is set to \"none\".");

                ImGui.Text("Music:");
                ImGui.SameLine(100);
                ImGui.Combo("##SelectedMusic", ref _selectedMusic, _musicLevels, _musicLevels.Length);

                ImGui.Text("Mode:");
                ImGui.SameLine(100);
                ImGui.Combo("##SelectedMode", ref _currentMode, CrashModes, CrashModes.Length);

                if (_selectedLevel != 0) ImGui.EndDisabled();

                ImGui.Spacing();
                ImGui.SameLine(100);
                if (ImGui.Button("Cancel", new System.Numerics.Vector2(90, 0)))
                {
                    _newLevelOpen = false;
                }
                ImGui.SameLine();
                if (ImGui.Button("Create New Level", new System.Numerics.Vector2(buttonEndX - ImGui.GetCursorPosX(), 0)))
                {
                    var explorer = new LevelExplorer(_baseLevels[_selectedLevel], _levels[_selectedLighting], _musicLevels[_selectedMusic], _currentMode);
                    App.AddLevelExplorer(explorer);
                    _newLevelOpen = false;
                }
            }

            ImGuiUtils.VerticalSpacing(10);
        }

        public static IgArchive CreateLevel(string baseLevel, string level, string musicLevel, int crashMode, ProgressManager progress)
        {
            if (baseLevel == "none")
            {
                return CreateNewLevel(level, musicLevel, crashMode, progress);
            }
            else
            {
                return DuplicateExistingLevel(baseLevel, progress);
            }
        }

        private static IgArchive DuplicateExistingLevel(string level, ProgressManager progress)
        {
            progress.SetProgress("newlevel", 0.0f, $"Duplicating level...");

            string levelName = level.Split("/").Last();

            string levelPath = Directory
                .GetFiles(LocalStorage.ArchivePath)
                .First(f => Path.GetFileName(f).ToLowerInvariant() == $"{levelName}.pak");

            IgArchive archive = IgArchive.Open(levelPath);

            string newLevelName = ConvertToCustomLevel(archive);

            Console.WriteLine($"Duplicating level: {levelName} ({newLevelName})");

            archive.RebuildPackageFile(archive.GetFiles().Where(f => !f.GetPath().StartsWith("update/")).ToList(), out _);

            archive.SetPath($"{newLevelName}.pak");

            progress.SetProgress("newlevel", 1.0f, $"Duplicating level...");

            return archive;
        }

        public static string ConvertToCustomLevel(IgArchive archive)
        {
            string newLevelName = $"{archive.GetName(false)}_Custom";

            // Rename collision files

            IgArchiveFile? collisionFileIgz = archive.FindCollisionFile(".igz");
            IgArchiveFile? collisionFileHkx = archive.FindCollisionFile(".hkx");

            if (collisionFileIgz != null && collisionFileHkx != null)
            {
                IgzFile collisionIgz = collisionFileIgz.ToIgzFile();
                collisionIgz.Objects.OfType<igNameList>().Last()._data[0]._name = $"StaticCollision_{newLevelName}";
                collisionFileIgz.SetData(collisionIgz.Save());

                collisionFileIgz.Rename($"StaticCollision_{newLevelName}.igz");
                collisionFileHkx.Rename($"StaticCollision_{newLevelName}.hkx");
            }

            // Rename package file

            IgArchiveFile packageFile = archive.FindPackageFile()!;
            packageFile.Rename($"{newLevelName}_pkg.igz");

            // Update Crash data if necessary

            UpdateCrashCharacterData(archive, newLevelName, "Crash");

            // Create zone info file

            int index = packageFile.GetPath().IndexOf("maps/");
            string levelIdentifier = packageFile.GetPath().Substring(index + 5).Replace("_pkg.igz", "").ToLowerInvariant();
            string zoneInfoPath = $"update/maps/{levelIdentifier}_zoneinfo.igz";
            string crashMode = levelIdentifier.Substring(0, levelIdentifier.IndexOf('/'));
            EGameYear year = GetGameYear(crashMode);
            
            (CZoneInfo zoneInfo, igLocalizedInfo localizedInfo) = ObjectFactory.CreateZoneInfo(levelIdentifier, year);
            
            IgArchiveFile infoFile = new IgArchiveFile(zoneInfoPath);
            IgzFile infoIgz = new IgzFile(zoneInfoPath);
            
            infoIgz.Objects.Add(zoneInfo);
            infoIgz.Objects.Add(localizedInfo);
            infoFile.SetData(infoIgz.Save());

            archive.AddFile(infoFile);

            return newLevelName;
        }

        private static void UpdateCrashCharacterData(IgArchive archive, string levelName, string characterName = "Crash")
        {
            IgArchive crashArchive = IgArchive.Open(Path.Join(LocalStorage.ArchivePath, $"{characterName}.pak"))!;
            IgArchiveFile file = crashArchive.FindFile($"{characterName}_CharacterData.igz")!;
            IgzFile igz = file.ToIgzFile();

            string levelID = levelName.Substring(0, 4);
            bool updated = true;

            switch (levelID)
            {
                case "L107":
                case "L114":
                    var hogData = igz.FindObject<Crash_Ride_HogData>()!;
                    hogData._Zone_Info_0x78.Reference!.namespaceName = $"{levelName}_zoneInfo";
                    break;

                case "L208":
                case "L213":
                case "L215":
                case "L226":
                    var bearData = igz.FindObject<Crash_Ride_BearData>()!;
                    bearData._Zone_Info_0xb0.Reference!.namespaceName = $"{levelName}_zoneInfo";
                    break;

                case "L217":
                case "L220":
                    var diggingData = igz.FindObject<Crash_DiggingData>()!;
                    diggingData._Zone_Info_0x80.Reference!.namespaceName = $"{levelName}_zoneInfo";
                    break;

                case "L222":
                case "L224":
                case "B205":
                    var jetPackData = igz.FindObjects<Crash_JetPackData>().Last()!;
                    jetPackData._Zone_Info_0x138.Reference!.namespaceName = $"{levelName}_zoneInfo";
                    break;

                case "L303":
                case "L310":
                    var tigerData = igz.FindObject<Crash_Ride_TigerData>()!;
                    tigerData._Zone_Info_0x80.Reference!.namespaceName = $"{levelName}_zoneInfo";
                    break;

                case "L305":
                case "L318":
                case "L326":
                case "L331":
                    var jetskiData = igz.FindObject<Crash_Ride_JetskiData>()!;
                    jetskiData._Zone_Info_0x38.Reference!.namespaceName = $"{levelName}_zoneInfo";
                    break;

                case "L317":
                case "L324":
                case "L330":
                    var planeData = igz.FindObject<Crash_Ride_PlaneData>()!;
                    planeData._Zone_Info_0x38.Reference!.namespaceName = $"{levelName}_zoneInfo";
                    break;

                // case "L104":
                // case "L113":
                // case "L205":
                // case "L209":
                // case "L215":
                //     Crash_BoulderData boulderData = igz.FindObject<Crash_BoulderData>()!;
                //     boulderData._Zone_Info_0x38.Reference!.namespaceName = $"{levelName}_zoneInfo";
                //     break;

                default:
                    updated = false;
                    break;
            }

            if (updated)
            {
                file.SetData(igz.Save());
                file.SetPath($"update/Characters/Playable/{characterName}_CharacterData.igz", false);
                archive.AddFile(file);
            }
        }

        private static IgArchive CreateNewLevel(string level, string musicLevel, int crashMode, ProgressManager progress)
        {
            progress.SetProgress("newlevel", 1/8f, $"Creating new level (1/8)...");

            string levelName = level.Split("/").Last();

            string levelPath = Directory
                .GetFiles(LocalStorage.ArchivePath)
                .First(f => Path.GetFileName(f).ToLowerInvariant() == $"{levelName}.pak");

            // Load source archive

            IgArchive sourceArchive = IgArchive.Open(levelPath);
            IgArchiveFile sourceFile = sourceArchive.FindFile($"{levelName}.igz")!;
            IgzFile sourceIgz = sourceFile.ToIgzFile();

            IgArchiveFile sourceLighting = sourceArchive.FindFile($"{levelName}_lighting.igz")!;
            IgzFile sourceLightingIgz = sourceLighting.ToIgzFile();

            IgArchive modelArchive = IgArchive.Open(Path.Join(LocalStorage.ArchivePath, "L332_EggipusRex.pak"));

            progress.SetProgress("newlevel", 2/8f, $"Creating new level (2/8)...");

            // Create new archive

            IgArchive archive = new IgArchive("Custom_Level.pak");

            string basePath = sourceFile.GetPath().Split("/").SkipLast(2).Aggregate((a, b) => a + "/" + b);
            string mainPath = $"{basePath}/Custom_Level/Custom_Level.igz";
            string cameraPath = $"{basePath}/Custom_Level/Custom_Level_Camera.igz";
            string lightingPath = $"{basePath}/Custom_Level/Custom_Level_lighting.igz";
            string cratePath = $"{basePath}/Custom_Level/Custom_Level_Crates.igz";
            string musicPath = $"{basePath}/Custom_Level/Custom_Level_Music.igz";
            string infoPath = $"update/{basePath}/Custom_Level/Custom_Level_zoneinfo.igz".ToLowerInvariant();

            // Create new files

            IgArchiveFile mainFile = new IgArchiveFile(mainPath);
            IgArchiveFile cameraFile = new IgArchiveFile(cameraPath);
            IgArchiveFile lightingFile = new IgArchiveFile(lightingPath);
            IgArchiveFile crateFile = new IgArchiveFile(cratePath);
            IgArchiveFile musicFile = new IgArchiveFile(musicPath);
            IgArchiveFile infoFile = new IgArchiveFile(infoPath);

            IgzFile mainIgz = new IgzFile(mainPath);
            IgzFile cameraIgz = new IgzFile(cameraPath);
            IgzFile lightingIgz = new IgzFile(lightingPath);
            IgzFile crateIgz = new IgzFile(cratePath);
            IgzFile musicIgz = new IgzFile(musicPath);
            IgzFile infoIgz = new IgzFile(infoPath);

            Dictionary<igObject, igObject> clones = [];

            // Load source objects

            CWorldEntity worldEntity = sourceIgz.FindObject<CWorldEntity>()!;
            CWorldVisualData worldVisualData = sourceLightingIgz.FindObject<CWorldVisualData>()!;

            CNavMeshBuildDataList? navmeshList = sourceIgz.FindObject<CNavMeshBuildDataList>();
            navmeshList?._data.Clear();

            // CWorldEntity

            var components = worldEntity.GetComponentsDictionary();

            foreach ((string key, igComponentData component) in components)
            {
                if (component is DDA_CheckpointData checkpointData)
                {
                    checkpointData._Entity_0x50.Reference = null;
                }
                else if (component is common_Level_ManagerData levelManager)
                {
                    levelManager._spawnEntity.Reference = null;
                    levelManager._Entity_0x48.Reference = null; // dark lighting
                    levelManager._E_Zone_Collectible_Type = EZoneCollectibleType.eZCT_Gem_Clear;
                }
                else if (component is not global_WorldInstance_Enviromental_VFXData)
                {
                    worldEntity.RemoveComponent(key);
                }
            }

            (worldEntity._entityData as CWorldEntityData)!._startingGameplayMode = EWorldGameplayMode.eWGM_Traditional;
            (worldEntity._entityData as CWorldEntityData)!._worldEntityFlags = 0; // 0x8 = cutscene camera (l101) => black screen if not handled
            (worldEntity._entityData as CWorldEntityData)!._killz = -2000;

            archive.Clone(worldEntity, sourceArchive, sourceIgz, mainIgz, clones);

            // CPlayerStartEntity

            CPlayerStartEntity playerStart = ObjectFactory.CreatePlayerStart();
            var children = playerStart.GetChildrenRecursive();
            children.Insert(0, playerStart);
            children.ForEach(c => 
            {
                c.MemoryPool = worldEntity.MemoryPool;
                c.GetFields().ToList().ForEach(f =>
                {
                    object? value = f.GetValue(c);
                    if (value is IMemoryRef mem) mem.MemoryPool = worldEntity.MemoryPool;
                });
            });
            mainIgz.Objects.Add(playerStart);

            progress.SetProgress("newlevel", 3/8f, $"Creating new level (3/8)...");

            // Level End

            if (crashMode == 0)
            {
                IgArchive levelEndArchive = IgArchive.Open(Path.Join(LocalStorage.ArchivePath, "L101_NSanityBeach.pak"));
                IgzFile levelEndIgz = levelEndArchive.FindFile("L101_NSanityBeach.igz")!.ToIgzFile();

                igEntity levelEndScenePrefab = levelEndIgz.FindObject<igEntity>("LevelEndScene_prefab")!;
                CGameEntity levelEndTeleporter = levelEndIgz.FindObject<CGameEntity>("LevelEndTeleporter")!;

                levelEndTeleporter._parentSpacePosition = new igVec3fMetaField(1450, 0, 0);
                levelEndScenePrefab._parentSpacePosition = new igVec3fMetaField(0, -15000, 0);

                archive.Clone(levelEndScenePrefab, levelEndArchive, levelEndIgz, mainIgz, clones);
                archive.Clone(levelEndTeleporter, levelEndArchive, levelEndIgz, mainIgz, clones);
            }
            else if (crashMode == 1)
            {
                IgArchive levelEndArchive = IgArchive.Open(Path.Join(LocalStorage.ArchivePath, "L219_Ruination.pak"));
                IgzFile levelEndIgz = levelEndArchive.FindFile("L219_Ruination.igz")!.ToIgzFile();

                CGameEntity levelEndTeleporter = levelEndIgz.FindObject<CGameEntity>("C2_LevelEndTeleporter")!;

                levelEndTeleporter._parentSpacePosition = new igVec3fMetaField(1400, 0, 0);

                archive.Clone(levelEndTeleporter, levelEndArchive, levelEndIgz, mainIgz, clones);
            }
            else if (crashMode == 2)
            {
                IgArchive levelEndArchive = IgArchive.Open(Path.Join(LocalStorage.ArchivePath, "L321_GoneTomorrow.pak"));
                IgzFile levelEndIgz = levelEndArchive.FindFile("L321_GoneTomorrow.igz")!.ToIgzFile();

                CEntity introCutscene = levelEndIgz.FindObject<CEntity>("IntroCutsceneSequencePlayer")!;
                CGameEntity levelEndTeleporter = levelEndIgz.FindObject<CGameEntity>("C3_LevelEndTeleporter")!;

                playerStart._parentSpacePosition = new igVec3fMetaField(0, 0, 560);
                levelEndTeleporter._parentSpacePosition = new igVec3fMetaField(1400, 0, 0);

                var introComponent = introCutscene.GetComponent<common_C3_IntroSequenceData>()!;
                var cutsceneList = levelEndIgz.FindObject<CEntityHandleList>("IntroCutsceneSequencePlayer_entityData_componentData_CommonCutsceneSequencePlayer_CutsceneSequenceShotList001")!;
                introComponent._BehaviorEventCrashIntro = "Cutscene_Crash2_Portal_Exit_Victory";
                introComponent._Float_0x30 = 1.0f;
                introComponent._Float_0x34 = 1.0f;
                introComponent._Float_0x40 = 2.45f;
                introComponent._Float_0x4c = 300;
                cutsceneList._data.Clear();

                archive.Clone(levelEndTeleporter, levelEndArchive, levelEndIgz, mainIgz, clones);
                archive.Clone(introCutscene, levelEndArchive, levelEndIgz, mainIgz, clones);
            }

            progress.SetProgress("newlevel", 4/8f, $"Creating new level (4/8)...");

            // Add Camera

            CRelativeCamera camera = ObjectFactory.CreateRelativeCamera("Default_Camera");
            
            playerStart._camera = new CCameraBase() { Reference = camera.ToNamedReference("Custom_Level_Camera") };

            cameraIgz.Objects.Add(camera);

            // Add crates

            IgArchive sourceCrateArchive = IgArchive.Open(Path.Join(LocalStorage.ArchivePath, "Crash_Crates.pak"));
            IgArchiveFile sourceCrateFile = sourceCrateArchive.FindFile("Crash_Crates.igz")!;
            IgzFile sourceCrateIgz = sourceCrateFile.ToIgzFile();

            sourceCrateIgz.FindObject<CVfxTextComponentData>("Crate_Checkpoint_entityData_componentData_VfxText_gen")!._displayText = "Woah!";

            CEntity basicCrate = sourceCrateIgz.FindObject<CEntity>("Crate_Basic")!;
            CEntity bounceCrate = sourceCrateIgz.FindObject<CEntity>("Crate_Bounce")!;
            CEntity randomCrate = sourceCrateIgz.FindObject<CEntity>("Crate_Random")!;
            CEntity arrowCrate = sourceCrateIgz.FindObject<CEntity>("Crate_Arrow")!;
            CEntity akuCrate = sourceCrateIgz.FindObject<CEntity>("Crate_AkuAku")!;
            CEntity extraLifeCrate = sourceCrateIgz.FindObject<CEntity>("Crate_ExtraLife")!;
            CEntity tntCrate = sourceCrateIgz.FindObject<CEntity>("Crate_TNT")!;
            CEntity checkpointCrate = sourceCrateIgz.FindObject<CEntity>("Crate_Checkpoint")!;
            CEntity ironCrate = sourceCrateIgz.FindObject<CEntity>("Crate_Basic_Iron")!;
            CEntity crystal = sourceCrateIgz.FindObject<CEntity>("Collectible_PowerCrystal")!;
            CEntity crateCounter = sourceCrateIgz.FindObject<CEntity>("LevelEnd_CrateCounter")!;

            Dictionary<igObject, igObject> crateClones = [];

            CEntity basicCrateClone = archive.Clone(basicCrate, sourceCrateArchive, sourceCrateIgz, crateIgz, crateClones);
            CEntity bounceCrateClone = archive.Clone(bounceCrate, sourceCrateArchive, sourceCrateIgz, crateIgz, crateClones);
            CEntity randomCrateClone = archive.Clone(randomCrate, sourceCrateArchive, sourceCrateIgz, crateIgz, crateClones);
            CEntity arrowCrateClone = archive.Clone(arrowCrate, sourceCrateArchive, sourceCrateIgz, crateIgz, crateClones);
            CEntity akuCrateClone = archive.Clone(akuCrate, sourceCrateArchive, sourceCrateIgz, crateIgz, crateClones);
            CEntity extraLifeCrateClone = archive.Clone(extraLifeCrate, sourceCrateArchive, sourceCrateIgz, crateIgz, crateClones);
            CEntity tntCrateClone = archive.Clone(tntCrate, sourceCrateArchive, sourceCrateIgz, crateIgz, crateClones);
            CEntity checkpointCrateClone = archive.Clone(checkpointCrate, sourceCrateArchive, sourceCrateIgz, crateIgz, crateClones);
            CEntity ironCrateClone = archive.Clone(ironCrate, sourceCrateArchive, sourceCrateIgz, crateIgz, crateClones);

            // C2/C3 crystal
            if (crashMode != 0)
            {
                CEntity crystalClone = archive.Clone(crystal, sourceCrateArchive, sourceCrateIgz, crateIgz, crateClones);
                crystalClone._parentSpacePosition = new igVec3fMetaField(900, 0, 150);
            }

            // Crate counter
            CEntity crateCounterClone = archive.Clone(crateCounter, sourceCrateArchive, sourceCrateIgz, mainIgz);
            crateCounterClone._parentSpacePosition =  new igVec3fMetaField(1160, 0, 100);

            basicCrateClone._parentSpacePosition = new igVec3fMetaField(-400, 0, 0);
            bounceCrateClone._parentSpacePosition = new igVec3fMetaField(-300, 0, 0);
            randomCrateClone._parentSpacePosition = new igVec3fMetaField(-200, 0, 0);
            arrowCrateClone._parentSpacePosition = new igVec3fMetaField(-100, 0, 0);
            akuCrateClone._parentSpacePosition = new igVec3fMetaField(100, 0, 0);
            extraLifeCrateClone._parentSpacePosition = new igVec3fMetaField(200, 0, 0);
            checkpointCrateClone._parentSpacePosition = new igVec3fMetaField(300, 0, 0);
            tntCrateClone._parentSpacePosition = new igVec3fMetaField(400, 0, 0);
            ironCrateClone._parentSpacePosition = new igVec3fMetaField(600, 0, 0);

            for (int i = 0; i < 8; i++)
            {
                CEntity ironCrateCloneClone = crateIgz.AddClone(ironCrateClone);
                ironCrateClone._parentSpacePosition = new igVec3fMetaField(600 + (i+1) * 75.5f, 0, 0);
            }

            checkpointCrateClone.GetComponent<CDynamicCheckpointComponentData>()!._camera = new CCameraBase() { Reference = new NamedReference("Custom_Level_Camera", "Camera") };
            checkpointCrateClone.GetComponent<CDynamicCheckpointComponentData>()!._dynamicCheckpointOffset = new igVec3fMetaField(0, 0, 200);

            progress.SetProgress("newlevel", 5/8f, $"Creating new level (5/8)...");

            // Music

            IgArchive sourceMusicArchive = sourceArchive;

            if (musicLevel != level)
            {
                string musicLevelName = musicLevel.Split("/").Last();
                
                string musicLevelPath = Directory
                    .GetFiles(LocalStorage.ArchivePath)
                    .First(f => Path.GetFileName(f).ToLowerInvariant() == $"{musicLevelName}.pak");

                sourceMusicArchive = IgArchive.Open(musicLevelPath);
            }

            var CreateMusicFromFile = (string identifier) =>
            {
                IgArchiveFile? sourceMusicFile = sourceMusicArchive.GetFiles().Find(f => f.GetPath().StartsWith("maps/") && f.GetName().ToLowerInvariant().Contains(identifier));
                if (sourceMusicFile == null) return false;

                IgzFile sourceMusicIgz = sourceMusicFile.ToIgzFile();

                var startMusicData = (CEntity?)sourceMusicIgz.Objects.Find(e => e is CEntity entity && entity.GetComponent<common_OnStartMusicData>() != null);
                if (startMusicData != null)
                {
                    startMusicData.ObjectName = "MainMusic";
                    startMusicData._parentSpacePosition = new igVec3fMetaField(0, 0, 0);
                    archive.Clone(startMusicData, sourceMusicArchive, sourceMusicIgz, musicIgz);
                    return true;
                }
                
                // Special case for L101, L222 & L224
                var musicSettings = (CGameSoundMusicSettings?)sourceMusicIgz.Objects.Find(e => e is CGameSoundMusicSettings s && s.ObjectName != null && s._nextStream.Reference != null && (s.ObjectName.ToLowerInvariant().Contains("first") || s.ObjectName.ToLowerInvariant().Contains("onstart")));
                if (musicSettings != null)
                {
                    IgArchiveFile startMusicVSC = modelArchive.FindFile("common_OnStartMusic_c", FileSearchType.Name)!;
                    archive.AddFile(startMusicVSC);

                    archive.Clone(musicSettings, sourceMusicArchive, sourceMusicIgz, musicIgz);

                    CEntity startMusic = modelArchive.FindObject<CEntity>(new NamedReference("L332_EggipusRex_Music", "Music_Entity"))!;
                    startMusic.ObjectName = "MainMusic";
                    startMusic._parentSpacePosition = new igVec3fMetaField(0, 0, 0);
                    startMusic.GetChildrenRecursive().ForEach(c =>
                    {
                        c.MemoryPool = musicSettings.MemoryPool;
                        c.GetFields().ToList().ForEach(f =>
                        {
                            if (f.GetValue(c) is IMemoryRef mem) mem.MemoryPool = musicSettings.MemoryPool;
                        });
                    });

                    var startMusicComponent = startMusic.GetComponent<common_OnStartMusicData>()!;
                    startMusicComponent._OnStartMusic.Reference = musicSettings.ToNamedReference(musicFile.GetName(false));

                    musicIgz.Objects.Add(startMusic);

                    return true;
                }

                return false;
            };

            if (!CreateMusicFromFile("music") && !CreateMusicFromFile("audio"))
            {
                Console.WriteLine("Warning: Could not find default music object");
            }

            // CZoneInfo

            string levelIdentifier = $"{basePath.Substring(5)}/custom_level/custom_level".ToLowerInvariant();
            EGameYear year = GetGameYear(crashMode);
            (CZoneInfo zoneInfo, igLocalizedInfo localizedInfo) = ObjectFactory.CreateZoneInfo(levelIdentifier, year);
            infoIgz.Objects.Add(zoneInfo);
            infoIgz.Objects.Add(localizedInfo);

            // Find largest visual box

            Dictionary<igEntity, float> visualBoxes = [];

            foreach (igObject obj in sourceLightingIgz.Objects)
            {
                if (obj.GetType() != typeof(igEntity)) continue;

                igEntity entity = (igEntity)obj;
                if (!entity._bitfield._canSpawn) continue;

                var component = entity.GetComponent<CVisualDataBoxComponentData>();
                if (component != null)
                {
                    visualBoxes[entity] = component._dimensions.ToVector3().ManhattanLength();
                }
            }

            progress.SetProgress("newlevel", 6/8f, $"Creating new level (6/8)...");

            // Find default collision object

            IgArchiveFile modelFile = modelArchive.FindFile("L332_EggipusRex_Art.igz")!;
            IgzFile modelIgz = modelFile.ToIgzFile();
            igEntity modelEntity = modelIgz.FindObject<igEntity>("Pltfrm05_01")!;
            modelEntity._parentSpacePosition = new igVec3fMetaField(0, 0, -35);

            Stream template = Assembly.GetExecutingAssembly().GetManifestResourceStream("NST.assets.L332_CollisionTemplate.pak")!;
            IgArchive collisionArchive = IgArchive.Open(template, "L332_CollisionTemplate.pak");
            
            foreach (IgArchiveFile collisionFile in collisionArchive.GetFiles())
            {
                string newPath = collisionFile.GetPath().Replace("maps/Crash1", basePath);
                archive.AddFile(collisionFile.Clone(newPath));
            }

            archive.Clone(modelEntity, modelArchive, modelIgz, mainIgz, clones);

            progress.SetProgress("newlevel", 7/8f, $"Creating new level (7/8)...");

            // Clone objects

            clones.Clear();
            archive.Clone(worldVisualData, sourceArchive, sourceLightingIgz, lightingIgz, clones);

            if (visualBoxes.Count > 0)
            {
                igEntity largestBox = visualBoxes.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
                largestBox.ObjectName = "MainLighting";
                largestBox._parentSpacePosition = new igVec3fMetaField(0, 0, 0);
                archive.Clone(largestBox, sourceArchive, sourceLightingIgz, lightingIgz, clones);
            }

            // Add and save files

            mainFile.SetData(mainIgz.Save());
            cameraFile.SetData(cameraIgz.Save());
            lightingFile.SetData(lightingIgz.Save());
            crateFile.SetData(crateIgz.Save());
            musicFile.SetData(musicIgz.Save());
            infoFile.SetData(infoIgz.Save());

            archive.AddFile(mainFile);
            archive.AddFile(cameraFile);
            archive.AddFile(lightingFile);
            archive.AddFile(crateFile);
            archive.AddFile(musicFile);

            // Build package file

            string packagePath = $"packages/generated/{mainPath}".Replace(".igz", "_pkg.igz");
            archive.RebuildPackageFile(archive.GetFiles(), out IgArchiveFile? packageFile, packagePath);

            if (packageFile != null)
            {
                IgzFile packageIgz = packageFile.ToIgzFile();
                var chunkInfos = packageIgz.FindObject<igStreamingChunkInfo>()!;
                chunkInfos._required._data.Add(new(){ _type = "pkg", _name = $"packages/generated/packagexmls/crash{crashMode+1}_pkg.igz" });
                chunkInfos._required._data.Add(new(){ _type = "pkg", _name = "packages/generated/ui/domains/juicedomain_story_pkg.igz" });
                packageFile.SetData(packageIgz.Save());
            }

            archive.AddFile(infoFile);

            progress.SetProgress("newlevel", 8/8f, $"Creating new level (8/8)...");

            return archive;
        }

        public static EGameYear GetGameYear(int crashMode) => crashMode switch
        {
            0 => EGameYear.eGY_2017_Crash1,
            1 => EGameYear.eGY_2017_Crash2,
            2 => EGameYear.eGY_2017_Crash3,
            _ => EGameYear.eGY_2017_Crash2,
        };
        public static EGameYear GetGameYear(string crashMode) => crashMode switch
        {
            "crash1" => EGameYear.eGY_2017_Crash1,
            "crash2" => EGameYear.eGY_2017_Crash2,
            "crash3" => EGameYear.eGY_2017_Crash3,
            _        => EGameYear.eGY_2017_Crash2,
        };
        public static int GetGameYearInt(string crashMode) => crashMode switch
        {
            "crash1" => 0,
            "crash2" => 1,
            "crash3" => 2,
            _        => 1,
        };
    }
}