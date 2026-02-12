using Alchemy;
using System.Text.RegularExpressions;

namespace NST
{
    public static partial class GameplayModeManager
    {
        public static readonly string[] GameplayModes = [ "Traditional", "Swimming", "Motorbike", "Jetski", "Plane", /*"Jetpack"*/ ];

        public static void ChangeGameMode(this LevelExplorer explorer, string mode)
        {
            if      (mode == "Jetpack")   EnableJetpack(explorer);
            else if (mode == "Swimming")  EnableSwimming(explorer);
            else if (mode == "Motorbike") EnableMotorbike(explorer);
            else if (mode == "Jetski")    EnableJetski(explorer);
            else if (mode == "Plane")     EnablePlane(explorer);
            else                          EnableTraditional(explorer);
        }

        private static void EnableJetpack(LevelExplorer explorer)
        {
            if (explorer.InstanceManager.AllEntities.Find(e => e.Object is CWorldEntity) is not NSTEntity worldEntity) return;

            ModalRenderer.ShowWarningModal("Auto-update?", "Automatically update WorldInstance?", () =>
            {
                IgArchive srcArchive = IgArchive.Open(Path.Combine(LocalStorage.ArchivePath, "L224_PackAttack.pak"));
                IgzFile srcIgz = srcArchive.FindFile("L224_PackAttack.igz")!.ToIgzFile();
                IgzFile dstIgz = explorer.FileManager.GetIgz(worldEntity.ArchiveFile)!;

                var worldEntityData = srcIgz.FindObject<CWorldEntityData>()!;

                if (worldEntity.Object._entityData != null)
                {
                    dstIgz.Remove(worldEntity.Object._entityData);
                }

                worldEntity.Object._entityData = explorer.ArchiveRenderer.Clone(worldEntityData, srcArchive, srcIgz, dstIgz, excludeMapFiles: true);
                worldEntity.Components?.Refresh();

                explorer.ArchiveRenderer.SetObjectUpdated(worldEntity.ArchiveFile, worldEntity.Object, true);

                ChangeZoneInfoCharacter(explorer, "Crash");
            });
        }

        private static void EnableSwimming(LevelExplorer explorer)
        {
            if (explorer.InstanceManager.AllEntities.Find(e => e.Object is CWorldEntity) is not NSTEntity worldEntity) return;

            ChangeZoneInfoGameMode(explorer, "swim");
            
            ModalRenderer.ShowWarningModal("Auto-update?", "Automatically update WorldInstance and IntroCutscene?", () =>
            {
                ResetToTraditional(explorer, worldEntity);

                IgArchive srcArchive = IgArchive.Open(Path.Combine(LocalStorage.ArchivePath, "L302_UnderPressure.pak"));
                IgzFile srcIgz = srcArchive.FindFile("L302_UnderPressure.igz")!.ToIgzFile();
                IgzFile dstIgz = explorer.FileManager.GetIgz(worldEntity.ArchiveFile)!;
                Dictionary<igObject, igObject> clones = [];

                var worldEntityData = srcIgz.FindObject<CWorldEntityData>()!;

                // Update WorldEntity

                if (worldEntity.Object._entityData != null)
                {
                    dstIgz.Remove(worldEntity.Object._entityData);
                }

                worldEntity.Object._entityData = explorer.ArchiveRenderer.Clone(worldEntityData, srcArchive, srcIgz, dstIgz, clones, true);

                explorer.ArchiveRenderer.SetObjectUpdated(worldEntity.ArchiveFile, worldEntity.Object, true);

                // Import IntroCutscene

                var existingCutscene = explorer.InstanceManager.AllEntities.Find(e => e.Object.GetComponent<common_C3_IntroSequenceData>() != null);
                var existingComponent = existingCutscene?.Object.GetComponent<common_C3_IntroSequenceData>();

                if (existingComponent == null)
                {
                    var introCutscene = srcIgz.FindObject<CEntity>("IntroCutsceneSequencePlayer")!;
                    var cutsceneComponent = introCutscene.GetComponent<common_CutsceneSequencePlayerData>()!;
                    
                    cutsceneComponent._CutsceneSequenceShotList.Reference = null;

                    explorer.Clone([introCutscene], srcArchive, srcIgz, worldEntity.ArchiveFile, dstIgz, addToSelection: null, initializeObjects: true, clones: clones);

                    explorer.TreeView.RebuildTree(explorer.InstanceManager.AllObjects);
                }
                else
                {
                    existingComponent._BehaviorEventCrashIntro = "SwimIntro";
                }

                worldEntity.Components?.Refresh();

                ChangeZoneInfoCharacter(explorer, "Crash");
            });
        }

        private static void EnableMotorbike(LevelExplorer explorer)
        {
            if (explorer.InstanceManager.AllEntities.Find(e => e.Object is CWorldEntity) is not NSTEntity worldEntity) return;
            if (explorer.InstanceManager.AllEntities.Find(e => e.Object is CPlayerStartEntity) is not NSTEntity playerStartEntity) return;

            ChangeZoneInfoGameMode(explorer, "bike");

            ModalRenderer.ShowWarningModal("Auto-update?", "Automatically update WorldInstance and PlayerStart?", () =>
            {
                ResetToTraditional(explorer, worldEntity);

                IgArchive srcArchive = IgArchive.Open(Path.Combine(LocalStorage.ArchivePath, "L328_Area51.pak"));
                IgzFile srcCameraIgz = srcArchive.FindFile("L328_Area51_Camera.igz")!.ToIgzFile();
                IgzFile srcIgz = srcArchive.FindFile("L328_Area51.igz")!.ToIgzFile();
                IgzFile dstIgz = explorer.FileManager.GetIgz(worldEntity.ArchiveFile)!;
                Dictionary<igObject, igObject> clones = [];

                var worldEntityData = srcIgz.FindObject<CWorldEntityData>()!;
                var playerStartData = srcIgz.FindObject<CPlayerStartEntityData>()!;
                var camera = srcCameraIgz.FindObject<CMotorcycleCamera>()!;

                // Delete objects
                
                if (worldEntity.Object._entityData != null)
                {
                    dstIgz.Remove(worldEntity.Object._entityData);
                }
                if (playerStartEntity.Object._entityData != null)
                {
                    dstIgz.Remove(playerStartEntity.Object._entityData);
                }
                if (explorer.InstanceManager.AllEntities.Find(e => e.Object.GetComponent<common_C3_IntroSequenceData>() != null) is NSTEntity introCutscene)
                {
                    explorer.RemoveObjects([introCutscene]);
                }

                // Import Camera

                explorer.GetOrCreateIgzFile("Camera", out IgArchiveFile cameraFile, out IgzFile cameraIgz);
                
                var res = explorer.Clone([camera], srcArchive, srcCameraIgz, cameraFile, cameraIgz, addToSelection: null, initializeObjects: true);

                // Update PlayerStart

                (playerStartEntity.Object as CPlayerStartEntity)!._camera!.Reference = new NamedReference(cameraFile.GetName(false), res[0].GetObject().ObjectName!);

                playerStartEntity.Object._entityData = explorer.ArchiveRenderer.Clone(playerStartData, srcArchive, srcIgz, dstIgz, clones, true);
                
                // Update WorldEntity
                
                worldEntity.Object._entityData = explorer.ArchiveRenderer.Clone(worldEntityData, srcArchive, srcIgz, dstIgz, clones, true);
                worldEntity.Object.GetComponent<common_BikeSpline_RespawnHelperData>()!._bitfield._isEnabled = false;

                explorer.ArchiveRenderer.SetObjectUpdated(worldEntity.ArchiveFile, playerStartEntity.Object, true);
                explorer.ArchiveRenderer.SetObjectUpdated(worldEntity.ArchiveFile, worldEntity.Object, true);

                worldEntity.Components?.Refresh();
                playerStartEntity.Components?.Refresh();

                explorer.TreeView.RebuildTree(explorer.InstanceManager.AllObjects);

                ChangeZoneInfoCharacter(explorer, "Crash");
            });
        }

        private static void EnableJetski(LevelExplorer explorer)
        {
            if (explorer.InstanceManager.AllEntities.Find(e => e.Object is CWorldEntity) is not NSTEntity worldEntity) return;

            ChangeZoneInfoGameMode(explorer, "jetski");

            if (worldEntity.Object._entityData is CWorldEntityData worldEntityData)
            {
                worldEntityData._startingGameplayMode = EWorldGameplayMode.eWGM_JetSki;
            }

            ModalRenderer.ShowWarningModal("Auto-update?", "Automatically import JetSkiTransition?", () =>
            {
                ResetToTraditional(explorer, worldEntity);

                IgArchive srcArchive = IgArchive.Open(Path.Combine(LocalStorage.ArchivePath, "L326_SkiCrazed.pak"));
                IgzFile srcIgz = srcArchive.FindFile("L326_SkiCrazed.igz")!.ToIgzFile();
                IgzFile dstIgz = explorer.FileManager.GetIgz(worldEntity.ArchiveFile)!;

                var transitionEntity = srcIgz.FindObject<CEntity>("JetSkiTransition")!;

                var playerStart = explorer.InstanceManager.AllEntities.Find(e => e.Object is CPlayerStartEntity);

                if (playerStart != null) playerStart.Object._parentSpacePosition.CopyTo(transitionEntity._parentSpacePosition);
                else transitionEntity._parentSpacePosition = new igVec3fMetaField(0, 0, 0);

                if (explorer.InstanceManager.AllEntities.Find(e => e.Object.GetComponent<common_C3_IntroSequenceData>() != null) is NSTEntity introCutscene)
                {
                    explorer.RemoveObjects([introCutscene]);
                }

                explorer.Clone([transitionEntity], srcArchive, srcIgz, worldEntity.ArchiveFile, dstIgz, addToSelection: null, initializeObjects: true);

                explorer.TreeView.RebuildTree(explorer.InstanceManager.AllObjects);

                ChangeZoneInfoCharacter(explorer, "Coco");
            });
        }

        private static void EnablePlane(LevelExplorer explorer)
        {
            if (explorer.InstanceManager.AllEntities.Find(e => e.Object is CWorldEntity) is not NSTEntity worldEntity) return;

            ChangeZoneInfoGameMode(explorer, "plane");

            if (worldEntity.Object._entityData is CWorldEntityData worldEntityData)
            {
                worldEntityData._startingGameplayMode = EWorldGameplayMode.eWGM_Plane;
            }

            ModalRenderer.ShowWarningModal("Auto-update?", "Automatically import AirVehicleTransition?", () =>
            {
                ResetToTraditional(explorer, worldEntity);

                IgArchive srcArchive = IgArchive.Open(Path.Combine(LocalStorage.ArchivePath, "L317_ByeByeBlimps.pak"));
                IgzFile srcIgz = srcArchive.FindFile("L317_ByeByeBlimps.igz")!.ToIgzFile();
                IgzFile dstIgz = explorer.FileManager.GetIgz(worldEntity.ArchiveFile)!;

                var transitionEntity = srcIgz.FindObject<CEntity>("AirVehicleTransition")!;

                var playerStart = explorer.InstanceManager.AllEntities.Find(e => e.Object is CPlayerStartEntity);

                if (playerStart != null) playerStart.Object._parentSpacePosition.CopyTo(transitionEntity._parentSpacePosition);
                else transitionEntity._parentSpacePosition = new igVec3fMetaField(0, 0, 0);

                if (explorer.InstanceManager.AllEntities.Find(e => e.Object.GetComponent<common_C3_IntroSequenceData>() != null) is NSTEntity introCutscene)
                {
                    explorer.RemoveObjects([introCutscene]);
                }

                explorer.Clone([transitionEntity], srcArchive, srcIgz, worldEntity.ArchiveFile, dstIgz, addToSelection: null, initializeObjects: true);

                explorer.TreeView.RebuildTree(explorer.InstanceManager.AllObjects);
            });
        }

        private static void EnableTraditional(LevelExplorer explorer)
        {
            if (explorer.InstanceManager.AllEntities.Find(e => e.Object is CWorldEntity) is not NSTEntity worldEntity) return;

            ChangeZoneInfoGameMode(explorer, null);

            if (worldEntity.Object._entityData is CWorldEntityData worldEntityData)
            {
                worldEntityData._startingGameplayMode = EWorldGameplayMode.eWGM_Traditional;
            }

            ModalRenderer.ShowWarningModal("Auto-update?", "Automatically clean up WorldInstance?", () => ResetToTraditional(explorer, worldEntity));
        }

        private static void ResetToTraditional(LevelExplorer explorer, NSTEntity worldEntity)
        {
            IgzFile dstIgz = explorer.FileManager.GetIgz(worldEntity.ArchiveFile)!;

            // Update WorldEntity

            foreach ((string key, igComponentData component) in worldEntity.Object.GetComponentsDictionary())
            {
                if (component is common_Level_ManagerData || component is DDA_CheckpointData || component is global_WorldInstance_Enviromental_VFXData)
                {
                    continue;
                }

                dstIgz.Remove(component);
            }

            explorer.ArchiveRenderer.SetObjectUpdated(worldEntity.ArchiveFile, worldEntity.Object._entityData?._componentData, true);

            // Update PlayerStart

            var playerStartEntity = explorer.InstanceManager.AllEntities.Find(e => e.Object is CPlayerStartEntity);

            if (playerStartEntity != null)
            {
                foreach ((string key, igComponentData component) in playerStartEntity.Object.GetComponentsDictionary())
                {
                    dstIgz.Remove(component);
                }

                if (playerStartEntity.Object is CPlayerStartEntity playerStart && playerStart._camera?.Reference != null)
                {
                    var cam = (NSTCamera?)explorer.InstanceManager.AllObjects.Find(e => e is NSTCamera c && NamedReference.Compare(playerStart._camera.Reference, e.ToReference()));
                    
                    if (cam?.Object is CMotorcycleCamera)
                    {
                        var otherCam = (NSTCamera?)explorer.InstanceManager.AllObjects.Find(e => e is NSTCamera c && c != cam && c.Object is not CCutsceneCamera);
                        playerStart._camera.Reference = otherCam?.ToReference();
                    }
                }

                explorer.ArchiveRenderer.SetObjectUpdated(playerStartEntity.ArchiveFile, playerStartEntity.Object._entityData?._componentData, true);
            }

            // Remove vehicle transitions

            var transitionEntities = explorer.InstanceManager.AllEntities
                .Where(e => e.Object.GetComponent<CVehicleTransitionComponentData>() != null)
                .Cast<NSTObject>()
                .ToList();

            if (transitionEntities.Count > 0)
            {
                explorer.RemoveObjects(transitionEntities);
            }

            // Update C3 intro cutscene

            UpdateC3IntroCutscene(explorer, worldEntity, dstIgz, "Cutscene_Crash2_Portal_Exit_Victory");

            worldEntity.Components?.Refresh();
            playerStartEntity?.Components?.Refresh();
        }

        public static void TryAddC3IntroCutscene(this LevelExplorer explorer)
        {
            if (explorer.CrashMode != 2) return;
            if (explorer.InstanceManager.AllEntities.Any(e => e.Object.GetComponent<common_C3_IntroSequenceData>() != null)) return;
            if (explorer.InstanceManager.AllEntities.Find(e => e.Object is CWorldEntity) is not NSTEntity worldEntity) return;
            if (explorer.FileManager.GetIgz(worldEntity.ArchiveFile) is not IgzFile dstIgz) return;

            ModalRenderer.ShowWarningModal("Auto-update?", "Automatically import C3 IntroCutsceneSequence?", () => AddC3IntroCutscene(explorer, worldEntity, dstIgz));
        }

        private static void UpdateC3IntroCutscene(LevelExplorer explorer, NSTEntity worldEntity, IgzFile dstIgz, string? behaviorEvent = null)
        {
            bool c3mode = explorer.CrashMode == 2;

            NSTEntity? introCutscene = explorer.InstanceManager.AllEntities.Find(e => e.Object.GetComponent<common_C3_IntroSequenceData>() != null);

            if (introCutscene != null)
            {
                if (!c3mode)
                {
                    explorer.RemoveObjects([introCutscene]);
                }
                else if (behaviorEvent != null && introCutscene.Object.TryGetComponent(out common_C3_IntroSequenceData? introSequence))
                {
                    introSequence._BehaviorEventCrashIntro = behaviorEvent;
                }
            }
            else if (c3mode)
            {
                AddC3IntroCutscene(explorer, worldEntity, dstIgz);
            }
        }

        private static void AddC3IntroCutscene(LevelExplorer explorer, NSTEntity worldEntity, IgzFile dstIgz)
        {
            string srcArchivePath = Path.Combine(LocalStorage.ArchivePath, "L321_GoneTomorrow.pak");
            IgArchive srcArchive = IgArchive.Open(srcArchivePath);
            IgzFile srcIgz = srcArchive.FindFile("L321_GoneTomorrow.igz")!.ToIgzFile();

            var newCutscene = srcIgz.FindObject<CEntity>("IntroCutsceneSequencePlayer")!;
            var introComponent = newCutscene.GetComponent<common_C3_IntroSequenceData>()!;
            var cutsceneComponent = newCutscene.GetComponent<common_CutsceneSequencePlayerData>()!;
                    
            introComponent._Float_0x30 = 0.5f;
            cutsceneComponent._CutsceneSequenceShotList.Reference = null;

            explorer.Clone([newCutscene], srcArchive, srcIgz, worldEntity.ArchiveFile, dstIgz, addToSelection: null, initializeObjects: true);

            explorer.TreeView.RebuildTree(explorer.InstanceManager.AllObjects);
        }

        private static void ChangeZoneInfoGameMode(LevelExplorer explorer, string? mode)
        {
            if (explorer.ZoneInfoFile == null || explorer.ZoneInfo == null) return;

            explorer.ZoneInfo._build = SetSpecialZoneInfoGameMode(explorer.ZoneInfo._build, mode);
            explorer.ArchiveRenderer.SetObjectUpdated(explorer.ZoneInfoFile, explorer.ZoneInfo);
        }

        private static void ChangeZoneInfoCharacter(LevelExplorer explorer, string characterName)
        {
            if (explorer.ZoneInfoFile == null || explorer.ZoneInfo == null) return;

            explorer.DefaultCharacter = characterName == "Crash" ? 0 : 1;
            explorer.ZoneInfo._overrideCharacter = characterName;
            explorer.ArchiveRenderer.SetObjectUpdated(explorer.ZoneInfoFile, explorer.ZoneInfo);
        }

        //////////// ZoneInfo ////////////

        private static readonly string[] _uniqueGameplayModes = [ "swim", "bike", "jetski", "plane" ];

        public static string SetSpecialZoneInfoGameMode(string? buildName, string? mode)
        {
            List<string> options = GetSpecialZoneInfoOptions(buildName).Where(e => !_uniqueGameplayModes.Contains(e)).ToList();

            if (mode != null)
            {
                options.Add(mode);
            }

            return UpdateSpecialZoneInfoOptions(buildName, options);
        }

        public static List<string> GetSpecialZoneInfoOptions(string? buildName)
        {
            if (buildName == null) return [];

            var match = ZoneInfoOptionsRegex().Match(buildName);

            if (!match.Success) return [];

            return match.Groups[1].Value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
        }

        public static string UpdateSpecialZoneInfoOptions(string? buildName, List<string> options)
        {
            string optionsStr = "";

            if (options.Count > 0)
            {
                optionsStr = ",{" + string.Join(",", options) + "}";
            }

            buildName ??= "";

            var match = ZoneInfoOptionsRegex().Match(buildName);

            if (match.Success)
            {
                return ZoneInfoOptionsRegex().Replace(buildName, optionsStr);
            }
            
            return buildName + optionsStr;
        }

        public static IgArchiveFile CreateCharacterData(List<string> options, string zoneInfoName, string characterName = "Crash")
        {
            IgArchive crashArchive = IgArchive.Open(Path.Join(LocalStorage.ArchivePath, $"{characterName}.pak"))!;
            IgArchiveFile file = crashArchive.FindFile($"{characterName}_CharacterData.igz")!;
            IgzFile igz = file.ToIgzFile();

            foreach (var type in options)
            {
                Console.WriteLine($"Setup Character Data for {type}");

                switch (type)
                {
                    case "hog":
                        var hogData = igz.FindObject<Crash_Ride_HogData>()!;
                        hogData._Zone_Info_0x78.Reference!.namespaceName = zoneInfoName;
                        break;

                    case "bear":
                        var bearData = igz.FindObject<Crash_Ride_BearData>()!;
                        bearData._Zone_Info_0xb0.Reference!.namespaceName = zoneInfoName;
                        break;

                    case "tiger":
                        var tigerData = igz.FindObject<Crash_Ride_TigerData>()!;
                        tigerData._Zone_Info_0x80.Reference!.namespaceName = zoneInfoName;
                        break;

                    case "jetpack":
                        var jetPackData = igz.FindObjects<Crash_JetPackData>().Last()!;
                        jetPackData._Zone_Info_0x138.Reference!.namespaceName = zoneInfoName;
                        break;

                    case "dig":
                        var diggingData = igz.FindObject<Crash_DiggingData>()!;
                        diggingData._Zone_Info_0x80.Reference!.namespaceName = zoneInfoName;
                        break;

                    // case "jetski":
                    //     var jetskiData = igz.FindObject<Crash_Ride_JetskiData>()!;
                    //     jetskiData._Zone_Info_0x28.Reference!.namespaceName = zoneInfoName;
                    //     jetskiData._Zone_Info_0x38.Reference!.isEXID = false;
                    //     break;

                    // case "plane":
                    //     var planeData = igz.FindObject<Crash_Ride_PlaneData>()!;
                    //     planeData._Zone_Info_0x38.Reference!.namespaceName = zoneInfoName;
                    //     break;

                    // case "boulder":
                    //     Crash_BoulderData boulderData = igz.FindObject<Crash_BoulderData>()!;
                    //     boulderData._Zone_Info_0x38.Reference!.namespaceName = zoneInfoName;
                    //     break;
                }
            }

            file.SetData(igz.Save());

            return file;
        }

        public static string? GetSpecialLevelMode(string levelName)
        {
            string id = levelName.Substring(0, 4);

            if (id == "L107" || id == "L114")                                 return "hog";
            if (id == "L208" || id == "L213" || id == "L215" || id == "L226") return "bear";
            if (id == "L217" || id == "L220")                                 return "dig";
            if (id == "L222" || id == "L224" || id == "B205")                 return "jetpack";
            if (id == "L303" || id == "L310")                                 return "tiger";
            if (id == "L305" || id == "L318" || id == "L326" || id == "L331") return "jetski";
            if (id == "L317" || id == "L324" || id == "L330")                 return "plane";
            // if (id == "L104" || id == "L113" || id == "L205" || id == "L209" || id == "L215") return "boulder";

            return null;
        }

        [GeneratedRegex(@",\{([^}]*)\}")]
        private static partial Regex ZoneInfoOptionsRegex();
    }
}