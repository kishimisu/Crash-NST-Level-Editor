using Alchemy;

namespace NST
{
    public static class IgArchiveExtensions
    {
        /// <summary>
        /// Clone an object from an external archive, including all its dependencies
        /// </summary>
        public static T Clone<T>(this IgArchive archive, T sourceObject, IgArchive sourceArchive, IgzFile sourceIgz, IgzFile destIgz, Dictionary<igObject, igObject>? clones = null) where T : igObject
        {
            T clone = IgzFile.Clone(sourceObject, sourceArchive, archive, sourceIgz, destIgz, out List<IgArchiveFile> newFiles, clones);

            foreach (IgArchiveFile file in newFiles)
            {
                archive.AddFile(file.Clone());
            }

            return clone;
        }

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
                packageFile = new IgArchiveFile(newPackagePath);
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
                    Console.WriteLine($"[Package file] Added {newChunk._name} ({newChunk._type})");
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
                existingFiles.ForEach(e => Console.WriteLine("[Package file] Removed " + e._name));
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
        public static List<IgArchiveFile> FindDependencies(IgArchive sourceArchive, IgArchive destinationArchive, HashSet<string> dependencies)
        {
            Dictionary<string, List<IgArchiveFile>> fileNamespaces = [];
            Queue<IgArchiveFile> files = [];
            List<IgArchiveFile> added = [];
            HashSet<string> visited = [];

            foreach (IgArchiveFile f in destinationArchive.GetFiles())
            {
                visited.Add(f.GetPath());
            }

            foreach (IgArchiveFile f in sourceArchive.GetFiles())
            {
                string name = f.GetName(false).ToLowerInvariant();

                if (!fileNamespaces.ContainsKey(name)) fileNamespaces[name] = [];
                fileNamespaces[name].Add(f);

                if (name.StartsWith("shared")) name = name.Substring(6);
                else if (name.EndsWith("_character")) name = name.Substring(0, name.Length - 10);
                else if (name.EndsWith("_behavior")) name = name.Substring(0, name.Length - 9);
                else continue;

                if (!fileNamespaces.ContainsKey(name)) fileNamespaces[name] = [];
                fileNamespaces[name].Add(f);
            }

            foreach (string name in dependencies)
            {
                if (!fileNamespaces.ContainsKey(name)) continue;

                foreach (IgArchiveFile dependency in fileNamespaces[name])
                {
                    files.Enqueue(dependency);
                }
            }

            while (files.Count > 0)
            {
                IgArchiveFile current = files.Dequeue();
                string path = current.GetPath();

                if (visited.Contains(path)) continue;
                
                visited.Add(path);
                added.Add(current);

                if (!current.IsIGZ()) continue;

                IgzFile igz = current.ToIgzFile();

                foreach (string name in igz.GetDependencies())
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

        public static IgArchiveFile? FindCustomZoneInfoFile(this IgArchive archive)
        {
            return archive.GetFiles().Find(e => e.GetPath().StartsWith("update/") && e.GetPath().EndsWith("_zoneinfo.igz"));
        }

        public static void RunLevel(this IgArchive archive)
        {
            ModManager.PlayButtonTimeout();
            
            if (LocalStorage.GamePath == null) throw new Exception("The path to the game folder is not set.");

            // Find package file
            IgArchiveFile? pkg = archive.FindPackageFile();
            if (pkg == null) throw new Exception("The current archive is not a level.");

            // Find level path
            int index = pkg.GetPath().IndexOf("maps/");
            if (index == -1) throw new Exception("The current archive is not a level.");

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
                : new IgArchive(LocalStorage.UpdateFilePath);
                
            foreach (IgArchiveFile file in update.GetFiles().ToList())
            {
                if (file.GetName(false).EndsWith("_custom_zoneinfo"))
                {
                    update.RemoveFile(file);
                }
            }

            IgArchiveFile? zoneInfoFile = archive.FindCustomZoneInfoFile();

            if (zoneInfoFile == null)
            {
                Console.WriteLine("No zone info found, creating new one...");
                
                string crashMode = levelIdentifier.Substring(0, levelIdentifier.IndexOf('/'));
                EGameYear year = LevelBuilder.GetGameYear(crashMode);
                
                (CZoneInfo zoneInfo, igLocalizedInfo localizedInfo) = ObjectFactory.CreateZoneInfo(levelIdentifier, year);

                IgzFile zoneInfoIgz = new IgzFile(zoneInfoPath, [ zoneInfo, localizedInfo ]);
                zoneInfoFile = new IgArchiveFile(zoneInfoPath);
                zoneInfoFile.SetData(zoneInfoIgz.Save());
                update.AddFile(zoneInfoFile);
            }

            chunkInfos._required._data.Add(new ChunkFileInfoMetaField() { _type = "igx_file", _name = zoneInfoPath});
            packageFile.SetData(packageIgz.Save());

            foreach (IgArchiveFile file in archive.GetFiles().Where(f => f.GetPath().StartsWith("update/")))
            {
                string path = file.GetPath().Substring(7);

                if (update.FindFile(path, FileSearchType.Path) is IgArchiveFile previousFile)
                {
                    update.RemoveFile(previousFile);
                }
                
                file.SetPath(path, false);
                update.AddFile(file);
            }

            if (update.FindFile(packageFile.GetPath(), FileSearchType.Path) is IgArchiveFile previousPackageFile)
            {
                update.RemoveFile(previousPackageFile);
            }

            update.AddFile(packageFile);
            update.Save();

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