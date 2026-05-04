using Alchemy;

namespace NST
{
    public static partial class IgArchiveExtensions
    {
        /// <summary>
        /// Rebuild the archive's package file by adding new files
        /// </summary>
        public static void RebuildPackageFile(this IgArchive archive, List<IgArchiveFile> files, out IgArchiveFile? newPackageFile, string? newPackagePath = null)
        {
            List<string> fileTypeOrder = [
                "script", "sound_sample", "sound_bank", "lang_file", "loose", "shader",
                "texture", "material_instances", "font", "vsc", "igx_file", 
                "havokrigidbody", "model", "asset_behavior", 
                "havokanimdb", "hkb_behavior", "hkc_character", 
                "behavior", "sky_model", "effect", "actorskin", 
                "sound_stream", "character_events", "graphdata_behavior", 
                "character_data", "gui_project",
                "navmesh", "igx_entities", "pkg"
            ];

            IgArchiveFile? packageFile = archive.FindPackageFile();

            newPackageFile = null;

            if (packageFile == null)
            {
                newPackagePath ??= ("packages/generated/" + archive.GetName(false) + "_pkg.igz");

                var chunkInfos = new igStreamingChunkInfo() { ObjectName = "chunk_info" };
                // chunkInfos.MemoryPool.alignment = 8;

                IgzFile igz = new IgzFile(newPackagePath, [ chunkInfos ]);
                packageFile = new IgArchiveFile(newPackagePath, archive.GameVersion);
                packageFile.SetData(igz.Save());

                if (files.Count == 0)
                {
                    files = archive.GetFiles();
                }

                archive.AddFile(packageFile);

                newPackageFile = packageFile;

                Console.WriteLine("Created new package file: " + packageFile.GetPath());
            }

            IgzFile packageIgz = packageFile.ToIgzFile();

            var chunkInfo = packageIgz.FindObject<igStreamingChunkInfo>()!;
            bool needsRebuild = false;

            List<ChunkFileInfoMetaField> existingFiles = chunkInfo._required._data.ToList();
            List<ChunkFileInfoMetaField> newFiles = [];

            foreach (IgArchiveFile file in files)
            {
                if (file == packageFile) continue;

                string filePath = file.GetPath().ToLower();

                ChunkFileInfoMetaField? chunk = existingFiles.Find(x => x._name == filePath);

                if (chunk == null)
                {
                    needsRebuild = true;
                    var newChunk = new ChunkFileInfoMetaField
                    {
                        _name = filePath,
                        _type = GetFileType(filePath)
                    };
                    newFiles.Add(newChunk);
                    // Console.WriteLine($"[Package file] Added {newChunk._name} ({newChunk._type})");
                }
                else
                {
                    existingFiles.Remove(chunk);
                    newFiles.Add(chunk);
                }
            }

            foreach (ChunkFileInfoMetaField file in existingFiles.ToList())
            {
                if (file._type == "pkg")
                {
                    existingFiles.Remove(file);
                    newFiles.Add(file);
                }
            }

            if (existingFiles.Count > 0)
            {
                needsRebuild = true;
                // existingFiles.ForEach(e => Console.WriteLine("[Package file] Removed " + e._name));
            }

            if (needsRebuild) 
            {
                newFiles.Sort((a, b) => {
                    int comp = fileTypeOrder.IndexOf(a._type!) - fileTypeOrder.IndexOf(b._type!);
                    if (comp != 0) return comp;
                    return a._name!.CompareTo(b._name!);
                });

                chunkInfo._required._data.Set(newFiles);

                packageFile.SetData(packageIgz.Save());
            }
        }

        private static string GetFileType(string filePath)
        {
            if (filePath.Contains("characterassets/")) return "asset_behavior";

            if (filePath.EndsWith(".hkx"))                 return "havokrigidbody";
            if (filePath.EndsWith(".hka"))                 return "havokanimdb";
            if (filePath.EndsWith(".hkb"))                 return "hkb_behavior";
            if (filePath.EndsWith(".hkc"))                 return "hkc_character";
            if (filePath.EndsWith(".hkp"))                 return "behavior";
            if (filePath.EndsWith(".lng"))                 return "lang_file";
            if (filePath.EndsWith(".mapnav"))              return "navmesh";

            if (filePath.StartsWith("maps/"))              return "igx_entities";
            if (filePath.StartsWith("scripts/"))           return "script";
            if (filePath.StartsWith("sound_samples/"))     return "sound_sample";
            if (filePath.StartsWith("sound_streams/"))     return "sound_stream";
            if (filePath.StartsWith("sounds/banks/"))      return "sound_bank";
            if (filePath.StartsWith("textures/"))          return "texture";
            if (filePath.StartsWith("loosetextures/"))     return "texture";
            if (filePath.StartsWith("materialinstances/")) return "material_instances";
            if (filePath.StartsWith("vsc/"))               return "vsc";
            if (filePath.StartsWith("models/"))            return "model";
            if (filePath.StartsWith("sky/"))               return "sky_model";
            if (filePath.StartsWith("vfx/"))               return "effect";
            if (filePath.StartsWith("actors/"))            return "actorskin";
            if (filePath.StartsWith("animation_events/"))  return "character_events";
            if (filePath.StartsWith("behavior_events/"))   return "character_events";
            if (filePath.StartsWith("behaviors/"))         return "graphdata_behavior";
            if (filePath.StartsWith("packages/"))          return "pkg";

            return "igx_file";
        }

        /// <summary>
        /// Find all dependencies of a file in a source archive that are not already in the destination archive
        /// </summary>
        public static List<IgArchiveFile> FindDependencies(IgArchive sourceArchive, IgArchive destinationArchive, HashSet<string> dependencies, bool excludeMapFiles, bool ctrToNst = false)
        {
            Dictionary<string, List<IgArchiveFile>> fileNamespaces = [];
            Queue<IgArchiveFile> files = [];
            List<IgArchiveFile> added = [];
            HashSet<string> visited = [];
            HashSet<string> behaviors = [];

            foreach (IgArchiveFile f in destinationArchive.GetFiles())
            {
                visited.Add(f.GetPath());
            }

            var AddSourceFile = (IgArchiveFile file, string name) =>
            {
                if (!fileNamespaces.TryGetValue(name, out List<IgArchiveFile>? value))
                {
                    value = [];
                    fileNamespaces[name] = value;
                }
                value.Add(file);
            };

            foreach (IgArchiveFile f in sourceArchive.GetFiles())
            {
                if (excludeMapFiles && (f.GetPath().StartsWith("maps/") || f.GetName().StartsWith("StaticCollision_"))) continue;

                string originalName = f.GetName(false).ToLowerInvariant();
                string name = originalName;

                if (name.StartsWith("shared")) name = name.Substring(6);
                if (name.EndsWith("_character")) name = name.Substring(0, name.Length - 10);
                else if (name.EndsWith("_behavior")) name = name.Substring(0, name.Length - 9);
                else if (name.EndsWith("_script")) name = name.Substring(0, name.Length - 7);

                AddSourceFile(f, originalName);

                if (name != originalName)
                {
                    AddSourceFile(f, name);
                    behaviors.Add(f.GetPath().Replace(f.GetName(), ""));
                }
            }

            var AddDependency = (string name) =>
            {
                if (!fileNamespaces.TryGetValue(name, out var outFiles)) return;

                foreach (IgArchiveFile dependency in fileNamespaces[name])
                {
                    files.Enqueue(dependency);

                    string? dir = dependency.GetPath().Replace(dependency.GetName(), "");

                    if (behaviors.Contains(dir))
                    {
                        foreach (IgArchiveFile other in sourceArchive.GetFiles().Where(f => f.GetPath().StartsWith(dir) && !files.Contains(f)))
                        {
                            files.Enqueue(other);
                        }
                    }
                }
            };

            foreach (string originalName in dependencies)
            {
                string name = originalName.Replace("_", "");

                AddDependency(originalName);

                if (name != originalName)
                {
                    AddDependency(name);
                }
            }

            while (files.Count > 0)
            {
                IgArchiveFile current = files.Dequeue();
                string path = current.GetPath();

                if (!visited.Add(path)) continue;

                if (ctrToNst && (path.StartsWith("vsc/") || Path.GetExtension(current.GetName()).StartsWith(".hk")))
                {
                    Console.WriteLine("Exclude incompatible CTR file: " + current.GetPath());
                    continue;
                }

                added.Add(current);

                if (!current.IsIGZ()) continue;

                IgzFile igz = current.ToIgzFile();

                foreach (string name in igz.GetDependencies(destinationArchive.GameVersion))
                {
                    if (!fileNamespaces.ContainsKey(name)) continue;

                    foreach (IgArchiveFile dependency in fileNamespaces[name])
                    {
                        files.Enqueue(dependency);
                    }
                }
            }

            return added;
        }
        
        private record VertexData
        {
            public uint vertexSize { get; init; }
            public int elementCount { get; init; }
            public int platformCount { get; init; }
            public uint platformHash { get; init; }
            public byte[] platformData { get; init; }
        }

        // Converts a file from CTR:NF to NST - (WIP)
        public static void FixVersionDifferences(this IgArchiveRenderer renderer, IgzFile igz)
        {
            IgArchive archive = renderer.Archive;
            
            if (igz.GameVersion == archive.GameVersion) return;

            // Console.WriteLine($"Convert {igz.GetName()} from {igz.GameVersion} to {archive.GameVersion}");

            igz.GameVersion = archive.GameVersion;

            using Stream platformDataNST = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("NST.assets.platform_data.json")!;

            var data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<uint, List<VertexData>>>(platformDataNST)!;

            foreach (igObject obj in igz.Objects)
            {
                if (obj is igVertexFormat vertexFormat)
                {
                    // Console.WriteLine($"igVertexFormat: {vertexFormat}, Vertex size: {vertexFormat._vertexSize}, Elements: {vertexFormat._elements.Count}");
                    var list = data[vertexFormat._vertexSize];
                    var platformData = list.Find(e => e.elementCount == vertexFormat._elements.Count)?.platformData ?? list[0].platformData;
                    vertexFormat._platformData.Set(platformData);
                    vertexFormat._platformFormat = new igVertexFormatPlatform() { Reference = new NamedReference("vertexformat", "igVertexFormatDX11", true) };
                }
                else if (obj is igIndexBuffer indexBuffer)
                {
                    // Console.WriteLine("igIndexBuffer: " + indexBuffer._format?.Reference);
                    indexBuffer._format = new igIndexFormat() { Reference = new NamedReference("indexformats", "i16_dx11", true) };
                }
                else if (obj is igMemoryCommandStream commandStream)
                {
                    byte[] bytes = commandStream._memory.ToArray();
                    
                    for (int i = 0; i <= commandStream._memory.Count - 4; i += 4)
                    {
                        int value = BitConverter.ToInt32(bytes, i);
                        if (value == 56)
                        {
                            // Console.WriteLine($"igMemoryCommandStream: replaced command id {value}");
                            commandStream._memory[i] = 54;
                        }
                    }
                }
                else if (obj is igImage2 image)
                {
                    // Console.WriteLine("igImage2: " + image._format?.Reference?.objectName);
                    if (image._format?.Reference?.objectName.Contains("tile_ps4") == true)
                    {
                        byte[] pixels = image.GetPixels(false);
                        string format = image._format.Reference.objectName;

                        if (format == "b8g8r8a8_tile_ps4")
                        {
                            for (int i = 0; i < pixels.Length; i += 4)
                            {
                                (pixels[i], pixels[i+2]) = (pixels[i+2], pixels[i]);
                            }
                            format = "r8g8b8a8_dx11";
                        }

                        image._data.Set(pixels);
                        image._format.Reference.objectName = format.Replace("tile_ps4", "dx11");
                        image._levelCount = 1;
                    }
                }
                else if (obj is igGraphicsTexture texture)
                {
                    string? name = texture._imageHandle?.Reference?.namespaceName;

                    if (name != null && !name.Contains("@!default_") &&!name.Contains("@!Common!") && archive.FindFile(name, FileSearchType.Name) == null)
                    {
                        IgArchiveFile? textureFile = AlchemyUtils.FindFileInArchives(NamespaceUtils.GetFileName(name, false), out _);

                        if (textureFile != null)
                        {
                            IgzFile textureIgz = textureFile.ToIgzFile();
                            renderer.AddFile(textureFile);
                            renderer.FixVersionDifferences(textureIgz);
                            textureFile.SetGameVersion(archive.GameVersion);
                            textureFile.SetData(textureIgz.Save());
                            Console.WriteLine("Found external texture: " + textureFile.GetPath());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Safely saves an archive by writing it to a temporary file first, then moving it to the destination path.
        /// This avoids concurrent streams issues when reading and writing to the same archive.
        /// </summary>
        public static void SafeSave(this IgArchive archive, string? filePath = null, bool updatePath = false, bool compress = false)
        {
            // File doesn't exist, no risk of concurrent read/write
            if (!File.Exists(filePath ?? archive.GetPath()))
            {
                archive.Save(filePath, updatePath, compress);
            }
            else
            {
                // Save to a temporary file
                string temporaryPath = LocalStorage.GetStoragePath("tmp_archive.pak");
                archive.Save(filePath, updatePath, compress, temporaryPath);
            }
        }

        public static IgArchiveFile? FindCustomZoneInfoFile(this IgArchive archive)
        {
            return archive.GetFiles().Find(e => e.GetPath().StartsWith("update/") && e.GetPath().EndsWith("_zoneinfo.igz"));
        }

        public static void TryRunLevel(this IgArchive archive)
        {
            try
            {
                archive.RunLevel();
                LocalStorage.AddRecentFile(archive.GetPath(), true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while launching the game: {e.Message}\n{e.StackTrace}");
                ModalRenderer.ShowMessageModal("Could not launch the level", e.Message);
            }
        }

        private static void RunLevel(this IgArchive archive)
        {
            ModManager.PlayButtonTimeout();

            if (archive.GameVersion == GameVersion.CTR) throw new Exception("This feature is only available for Crash NST");
            
            if (LocalStorage.GamePath == null) throw new Exception("The path to the game folder is not set.");

            // Find package file
            IgArchiveFile? pkg = archive.FindPackageFile();
            if (pkg == null) throw new Exception("The current archive is not a level.");

            // Find level path
            int index = pkg.GetPath().IndexOf("maps/");
            if (index == -1) throw new Exception("The current archive is not a level.");

            if (LocalStorage.IsFileLocked(Path.Join(LocalStorage.GamePath, "CrashBandicootNSaneTrilogy.exe")))
            {
                throw new Exception("The game is already running.");
            }

            string levelPath = pkg.GetPath().Substring(index + 5);
            levelPath = levelPath.Replace("_pkg.igz", "");                                // Crash1/L101_NSanityBeach/L101_NSanityBeach

            // Create required strings
            string levelName = levelPath.Substring(levelPath.LastIndexOf("/") + 1);       // L101_NSanityBeach
            string levelIdentifier = levelPath.ToLowerInvariant();                        // crash1/l101_nsanitybeach/l101_nsanitybeach
            string zoneInfoPath = $"maps/{levelIdentifier}_zoneinfo.igz";                 // maps/crash1/l101_nsanitybeach/l101_nsanitybeach_zoneinfo.igz
            string archivePath = Path.Join(LocalStorage.ArchivePath, levelName + ".pak"); // <game_folder>/archives/L101_NSanityBeach.pak

            IgArchive chunkInfosArchive = IgArchive.Open(Path.Join(LocalStorage.ArchivePath, "chunkInfos.pak"));
            IgArchiveFile packageFile = chunkInfosArchive.FindPackageFile()!;
            IgzFile? packageIgz = packageFile.ToIgzFile();
            igStreamingChunkInfo chunkInfos = packageIgz.FindObject<igStreamingChunkInfo>()!;

            // Run original level

            if (chunkInfosArchive.GetFiles().Any(f => f.GetPath() == zoneInfoPath))
            {
                Console.WriteLine("Running existing level...");

                if (archive.GetPath() != archivePath)
                {
                    Console.WriteLine("Archive path mismatch, saving level to: " + archivePath);

                    if (File.Exists(archivePath) && !File.Exists(archivePath + ".backup"))
                    {
                        ModalRenderer.ShowConfirmationModal($"You're about to overwrite a game file and no backup has been found:\n\n{archivePath}", 
                        () => {
                            File.Copy(archivePath, archivePath + ".backup"); // Backup
                            File.Copy(archive.GetPath(), archivePath, true); // Overwrite
                            ModManager.LaunchLevel(levelIdentifier);
                        },
                        () => {
                            File.Copy(archive.GetPath(), archivePath, true);
                            ModManager.LaunchLevel(levelIdentifier);
                        },
                        "Backup first",
                        "Overwrite");
                        return;
                    }
                    else
                    {
                        File.Copy(archive.GetPath(), archivePath, true);
                    }
                }
                else Console.WriteLine("Archive name is the same as the level name, nothing to do.");

                ModManager.LaunchLevel(levelIdentifier);
                return;
            }

            // Run custom level

            Console.WriteLine("Running custom level...");

            IgArchive update = File.Exists(LocalStorage.UpdateFilePath)
                ? IgArchive.Open(LocalStorage.UpdateFilePath)
                : new IgArchive(LocalStorage.UpdateFilePath, GameVersion.NST);
                
            foreach (IgArchiveFile file in update.GetFiles().ToList())
            {
                if (file.GetName(false).EndsWith("_zoneinfo"))
                {
                    update.RemoveFile(file);
                }
            }

            IgArchiveFile? zoneInfoFile = archive.FindCustomZoneInfoFile();
            IgzFile? zoneInfoIgz = zoneInfoFile?.ToIgzFile();
            CZoneInfo? zoneInfo = zoneInfoIgz?.FindObject<CZoneInfo>();

            if (zoneInfoFile == null || zoneInfoIgz == null || zoneInfo == null)
            {
                Console.WriteLine("No zone info found, creating new one...");
                
                string crashMode = levelIdentifier.Substring(0, levelIdentifier.IndexOf('/'));
                EGameYear year = LevelBuilder.GetGameYear(crashMode);
                
                (CZoneInfo newZoneInfo, igLocalizedInfo newLocalizedInfo) = ObjectFactory.CreateZoneInfo(levelIdentifier, year);

                zoneInfo = newZoneInfo;
                zoneInfoIgz = new IgzFile(zoneInfoPath, [ newZoneInfo, newLocalizedInfo ]);
                zoneInfoFile = new IgArchiveFile(zoneInfoPath, archive.GameVersion);
                update.AddFile(zoneInfoFile);
            }

            IgArchiveFile? previousCharacterFileCrash = update.FindFile($"Crash_CharacterData.igz");
            IgArchiveFile? previousCharacterFileCoco = update.FindFile($"Coco_CharacterData.igz");

            if (previousCharacterFileCrash != null) update.RemoveFile(previousCharacterFileCrash);
            if (previousCharacterFileCoco != null) update.RemoveFile(previousCharacterFileCoco);

            List<string> options = GameplayModeManager.GetSpecialZoneInfoOptions(zoneInfo._build);
            if (options.Count > 0)
            {
                IgArchiveFile characterData = GameplayModeManager.CreateCharacterData(options, zoneInfoFile.GetName(false), zoneInfo._overrideCharacter ?? "Crash");
                update.AddFile(characterData);
            }

            zoneInfo._zoneVehicle = null;

            if (options.Contains("jetski")) zoneInfo._zoneVehicle = "CocoJetski";
            else if (options.Contains("plane")) zoneInfo._zoneVehicle = "CrashCocoPlane";

            zoneInfoFile.SetData(zoneInfoIgz.Save());

            chunkInfos._required._data.Add(new ChunkFileInfoMetaField() { _type = "igx_file", _name = zoneInfoPath});
            packageFile.SetData(packageIgz.Save());

            foreach (IgArchiveFile file in archive.GetFiles().Where(f => f.GetPath().StartsWith("update/")))
            {
                string path = file.GetPath().Substring(7);

                if (update.FindFile(path, FileSearchType.Path) is IgArchiveFile previousFile)
                {
                    update.RemoveFile(previousFile);
                }

                IgArchiveFile clone = file.Clone(path);
                update.AddFile(clone);
            }

            if (update.FindFile(packageFile.GetPath(), FileSearchType.Path) is IgArchiveFile previousPackageFile)
            {
                update.RemoveFile(previousPackageFile);
            }

            update.AddFile(packageFile);
            update.SafeSave();

            if (archive.GetPath() != archivePath)
            {
                Console.WriteLine("Archive path mismatch, saving level to: " + archivePath);
                File.Copy(archive.GetPath(), archivePath, true);
            }
            else Console.WriteLine("Archive name is the same as the level name, nothing to do.");

            ModManager.LaunchLevel(levelIdentifier);
        }
    }
}