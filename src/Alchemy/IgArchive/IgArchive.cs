namespace Alchemy
{
    public enum GameVersion
    {
        None = 0,
        NST = 1,
        CTR = 2
    }

    public enum FileSearchType 
    { 
        Name, 
        NameWithExtension, 
        NameContains,
        NameStartsWith,
        Path, 
        FullPath,
        NamespaceHash
    }

    [Flags]
    public enum FileSearchParams
    {
        All = 0,
        Map = 1 << 0,
        Igz = 1 << 1,
        Hkx = 1 << 2,
        MapIgz = Map | Igz
    }

    /// <summary>
    /// Instance of a .pak file.
    /// Provides utilities for manipulating files within the archive.
    /// </summary>
    public class IgArchive
    {
        private const u32 SIGNATURE = 0x1A414749;
        private const u32 HEADER_SIZE = 0x38;
        public const i32 SECTOR_SIZE = 0x800;
        
        public struct IgArchiveHeader
        {
            public u32 signature;
            public u32 version;
            public u32 tocSize;
            public u32 fileCount;
            public u32 sectorSize;
            public u32 hashSearchDivider;
            public u32 hashSearchMargin;
            public u32 largeBlockCount;
            public u32 mediumBlockCount;
            public u32 smallBlockCount;
            public u64 pathTableOffset;
            public u32 pathTableSize;
            public u32 flags;
        }

        public struct FileInfo
        {
            public u32 offset;
            public i32 ordinal;
            public i32 uncompressedSize;
            public i32 blockIndex; // also stores compression
        }

        public class BlockTables
        {
            public List<u32> largeBlocks = [];
            public List<u16> mediumBlocks = [];
            public List<u8> smallBlocks = [];
        }

        public string Path { get; set; } = "";
        public List<IgArchiveFile> Files { get; } = [];
        public GameVersion GameVersion { get; set; } = GameVersion.NST;

        public void AddFile(IgArchiveFile file) => Files.Add(file);
        public void RemoveFile(IgArchiveFile file) => Files.Remove(file);
        public string GetName(bool includeExtension = true) => NamespaceUtils.GetFileName(Path, includeExtension);

        public IgArchive(string path, GameVersion version, List<IgArchiveFile>? files = null)
        {
            Path = path;
            Files = files ?? [];
            GameVersion = version;
        }

        /// <summary>
        /// Opens a .pak file from disk
        /// </summary>
        /// <param name="archivePath">The path to the .pak file</param>
        /// <returns>A new IgArchive instance</returns>
        public static IgArchive Open(string archivePath)
        {
            using var fs = new FileStream(archivePath, FileMode.Open, FileAccess.Read);
            return Open(fs, archivePath);
        }

        public static IgArchive Open(Stream fs, string archivePath) 
        {
            // Open file
            BinaryReader reader = new BinaryReader(fs);

            // Parse header
            IgArchiveHeader header = reader.ReadStruct<IgArchiveHeader>();

            // Parse file ids
            u32[] fileIds = reader.ReadArray<u32>((int)header.fileCount);
            
            // Parse file infos
            FileInfo[] fileInfos = reader.ReadArray<FileInfo>((int)header.fileCount);

            // Parse block tables
            BlockTables blockTables = new BlockTables() {
                largeBlocks = reader.ReadList<u32>((int)header.largeBlockCount),
                mediumBlocks = reader.ReadList<u16>((int)header.mediumBlockCount),
                smallBlocks = reader.ReadList<u8>((int)header.smallBlockCount)
            };

            // Parse file paths
            List<(string, string)> filePaths = ParseFilePaths(header, reader);

            // Construct files objects
            List<IgArchiveFile> files = [];

            GameVersion version = header.GetGameVersion();

            for (int i = 0; i < header.fileCount; i++)
            {
                (string fullPath, string path) = filePaths[i];

                var file = new IgArchiveFile(archivePath, path, fullPath, fileInfos[i], blockTables, fs, version);

                files.Add(file);
            }

            return new IgArchive(archivePath, version, files);
        }

        /// <summary>
        /// Save the archive to disk. Use SafeSave() instead if overwriting the original archive
        /// </summary>
        /// <param name="filePath">The path to save the archive to</param>
        /// <param name="updatePath">Whether to update this IgArchive's path to match the file path</param>
        public void Save(string? filePath = null, bool updatePath = false, bool compress = false, string? temporaryPath = null)
        {
            if (filePath == null)
            {
                filePath = Path;
            }
            else if (updatePath)
            {
                Path = filePath;
            }

            // Sort files by hash
            Files.Sort((f1, f2) => f1.Hash.CompareTo(f2.Hash));

            // Output writer
            using FileStream fs = new FileStream(temporaryPath ?? filePath, FileMode.Create, FileAccess.ReadWrite);
            using BinaryWriter writer = new BinaryWriter(fs);

            // File data writer
            using MemoryStream fileStream = new MemoryStream(Files.Count * SECTOR_SIZE);
            using BinaryWriter fileWriter = new BinaryWriter(fileStream);

            FileInfo[] fileInfos = new FileInfo[Files.Count];
            long[] fileOffsets = new long[Files.Count];
            int[] blockIndices = new int[Files.Count];

            // Dump file data
            for (int i = 0; i < Files.Count; i++)
            {
                fileOffsets[i] = fileWriter.BaseStream.Position;

                if (compress && !Files[i].SkipCompression())
                {
                    fileWriter.Write(Files[i].Compress(true));
                }
                else
                {
                    fileWriter.Write(Files[i].GetData());
                }

                fileWriter.Align(SECTOR_SIZE);
            }

            // Build block tables
            BlockTables blockTables = BuildBlockTables(blockIndices);

            // Build header
            IgArchiveHeader header = BuildHeader(blockTables);
            
            uint filesOffset = HEADER_SIZE + header.tocSize;

            writer.Seek((int)filesOffset, SeekOrigin.Begin);
            writer.Align(SECTOR_SIZE);

            // Build file infos
            for (int i = 0; i < Files.Count; i++)
            {
                fileInfos[i] = Files[i].BuildFileInfos(i, writer.BaseStream.Position, fileOffsets[i], blockIndices[i]);
            }

            // Write file data
            fileWriter.Write((byte)0);
            writer.Write(fileStream.ToArray(), 0, fileWriter.GetPosition() - 1);

            int pathsOffsetsStart = writer.GetPosition();
            int pathsNamesStart = writer.GetPosition() + Files.Count * sizeof(uint);
            writer.Seek(pathsNamesStart, SeekOrigin.Begin);

            // Write file paths
            for (int i = 0; i < Files.Count; i++)
            {
                int offset = writer.GetPosition();
                writer.Seek(pathsOffsetsStart + i * sizeof(uint), SeekOrigin.Begin);
                writer.Write(offset - pathsOffsetsStart);

                writer.Seek(offset, SeekOrigin.Begin);
                writer.WriteNullTerminatedString(Files[i].FullPath);
                writer.WriteNullTerminatedString(Files[i].Path);
                writer.Write(0);
            }

            int archiveSize = writer.GetPosition();
            header.pathTableOffset = (u64)pathsOffsetsStart;
            header.pathTableSize = (uint)(archiveSize - pathsOffsetsStart);

            // Write header
            writer.Seek(0, SeekOrigin.Begin);
            writer.WriteStruct(header);

            // Write file hashes
            for (int i = 0; i < Files.Count; i++)
                writer.Write(Files[i].Hash);

            // Write file infos
            for (int i = 0; i < Files.Count; i++)
                writer.WriteStruct(fileInfos[i]);

            // Write block tables
            for (int i = 0; i < blockTables.largeBlocks.Count; i++)
                writer.Write(blockTables.largeBlocks[i]);

            for (int i = 0; i < blockTables.mediumBlocks.Count; i++)
                writer.Write(blockTables.mediumBlocks[i]);

            for (int i = 0; i < blockTables.smallBlocks.Count; i++)
                writer.Write(blockTables.smallBlocks[i]);

            // Update file infos
            for (int i = 0; i < Files.Count; i++)
                Files[i].Setup(fs, filePath, blockTables, fileInfos[i]);

            fs.Dispose();

            if (temporaryPath != null)
            {
                File.Move(temporaryPath, filePath, true);
                File.Delete(temporaryPath);
            }

            Console.WriteLine($"Saved {filePath} ({Files.Count} files, {archiveSize/1024f/1024f:0.00} MB)");
        }

        /// <summary>
        /// Clone a file in the archive. 
        /// Will generate the file name using the following pattern until the file has a unique path: name_1, name_2, ...
        /// </summary>
        /// <param name="file">The file to clone</param>
        /// <param name="newName">The new name of the file. If null, the input file name will be used as a base</param>
        /// <returns>The cloned file</returns>
        public IgArchiveFile CloneFile(IgArchiveFile file, string? newName = null)
        {
            string fileName = newName ?? file.GetName(false);
            
            string path;
            int index = 1;
            do
            {
                path = file.Path.Replace(fileName, fileName + "_" + index++);
            } 
            while (FindFile(path, FileSearchType.Path) != null);

            IgArchiveFile clone = file.Clone(path);

            Files.Add(clone);

            return clone;
        }
        
        /// <summary>
        /// Returns a list of files in the archive verifying the specified filter
        /// </summary>
        public List<IgArchiveFile> GetFiles(FileSearchParams searchParams)
        {
            if (searchParams == FileSearchParams.All)
            {
                return Files;
            }

            bool includeIgz = searchParams.HasFlag(FileSearchParams.Igz);
            bool includeHkx = searchParams.HasFlag(FileSearchParams.Hkx);
            bool includeAll = !includeIgz && !includeHkx;

            if (includeAll) includeIgz = includeHkx = true;

            return Files.Where(f =>
            {
                if (searchParams.HasFlag(FileSearchParams.Map) && !f.Path.StartsWith("maps/")) return false;

                string ext = NamespaceUtils.GetExtension(f.GetName());
                if (ext == ".igz") return includeIgz;
                else if (ext == ".hkx") return includeHkx;
                else return includeAll;

            }).ToList();
        }

        /// <summary>
        /// Find a file in the archive
        /// </summary>
        /// <param name="name">The string to search for</param>
        /// <param name="searchType">How the string should be compared</param>
        /// <returns>The first file that matches the search criteria, or null if no match is found</returns>
        public IgArchiveFile? FindFile(
            string name, 
            FileSearchType searchType = FileSearchType.NameWithExtension, 
            FileSearchParams searchParams = FileSearchParams.All, 
            StringComparison comp = StringComparison.InvariantCultureIgnoreCase)
        {
            var files = GetFiles(searchParams);

            IgArchiveFile? file = searchType switch
            {
                FileSearchType.Name => 
                    files.Find(f => f.GetName(false).Equals(name, comp)),
                FileSearchType.NameContains =>
                    files.Find(f => f.GetName(false).Contains(name, comp)),
                FileSearchType.NameStartsWith =>
                    files.Find(f => f.GetName(false).StartsWith(name, comp)),
                FileSearchType.NameWithExtension =>
                    files.Find(f => f.GetName().Equals(name, comp)),
                FileSearchType.Path => 
                    files.Find(f => f.Path.Equals(name, comp)),
                FileSearchType.FullPath => 
                    files.Find(f => f.FullPath.Equals(name, comp)),
                FileSearchType.NamespaceHash =>
                    files.Find(f => NamespaceUtils.ComputeHash(f.GetName(false)).ToString() == name),

                _ => throw new ArgumentOutOfRangeException(nameof(searchType), searchType, null)
            };
            
            return file;
        }

        /// <summary>
        /// Find a .igz file in the archive based on an object reference
        /// </summary>
        /// <param name="reference">The object reference. Only the namespace name is used to find the file</param>
        /// <returns>The first .igz file that matches the namespace name</returns>
        public IgArchiveFile? FindIgzFile(NamedReference reference) => FindFile(reference.namespaceName + ".igz");

        public IgArchiveFile? FindCollisionFile(string extension = ".igz")
        {
            return Files.Find(f => f.Path.Contains("StaticCollision") && f.Path.EndsWith(extension));
        }

        public IgArchiveFile? FindPackageFile()
        {
            return Files.Find(f => f.Path.EndsWith("_pkg.igz"));
        }

        public IgArchiveFile? FindMainMapFile()
        {
            IgArchiveFile? packageFile = FindPackageFile();
            if (packageFile == null) return null;

            string? levelName = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(packageFile.Path));
            if (levelName == null) return null;
            
            return FindFile(levelName, FileSearchType.Name, FileSearchParams.MapIgz);
        }

        /// <summary>
        /// Find an igObject in the archive
        /// </summary>
        /// <param name="reference">The object reference</param>
        /// <returns>The unique object associated with the reference, or null if no match is found</returns>
        public igObject? FindObject(NamedReference reference)
        {
            IgArchiveFile? file = FindIgzFile(reference);

            if (file == null) return null;

            return file.ToIgzFile().FindObject(reference);
        }

        public T? FindObject<T>(NamedReference reference) where T : igObject
        {
            return FindObject(reference) as T;
        }

        private static List<(string, string)> ParseFilePaths(IgArchiveHeader header, BinaryReader reader)
        {   
            reader.Seek(header.pathTableOffset);

            u32[] filePathOffsets = reader.ReadArray<u32>((int)header.fileCount);

            var paths = new List<(string, string)>((int)header.fileCount);

            for (int i = 0; i < header.fileCount; i++)
            {
                ulong offset = header.pathTableOffset + filePathOffsets[i];
                reader.Seek(offset);

                string fullPath = reader.ReadNullTerminatedString();
                string path = reader.ReadNullTerminatedString();

                paths.Add((fullPath, path));
            }

            return paths;
        }

        private BlockTables BuildBlockTables(int[] blockIndices)
        {
            BlockTables blockTables = new BlockTables();

            for (int i = 0; i < Files.Count; i++)
            {
                blockIndices[i] = Files[i].BuildBlockTable(blockTables);
            }
            
            return blockTables;
        }

        private IgArchiveHeader BuildHeader(BlockTables blockTables)
        {
            (uint hashSearchDivider, uint hashSearchMargin) = ComputeHashSearchParams(Files);

            uint tocSize = (uint)(Files.Count * sizeof(u32) * 5
                            + blockTables.largeBlocks.Count  * sizeof(u32)
                            + blockTables.mediumBlocks.Count * sizeof(u16)
                            + blockTables.smallBlocks.Count  * sizeof(u8));

            IgArchiveHeader header = new IgArchiveHeader() 
            {
                signature = SIGNATURE,
                version = GameVersion.GetArchiveVersion(),
                tocSize = tocSize,
                fileCount = (uint)Files.Count,
                sectorSize = SECTOR_SIZE,
                hashSearchDivider = hashSearchDivider,
                hashSearchMargin = hashSearchMargin,
                largeBlockCount = (uint)blockTables.largeBlocks.Count,
                mediumBlockCount = (uint)blockTables.mediumBlocks.Count,
                smallBlockCount = (uint)blockTables.smallBlocks.Count,
                pathTableOffset = 0,
                pathTableSize = 0,
                flags = 1
            };

            return header;
        }

        private static (uint, uint) ComputeHashSearchParams(List<IgArchiveFile> files)
        {
            if (files.Count == 0)
            {
                return (0, 0);
            }
            
            uint hashSearchDivider = uint.MaxValue / (uint)files.Count;
            uint hashSearchMargin = 0;

            // Find the first margin value that works for all files
            for (uint margin = 0; margin < files.Count; margin++)
            {
                if (files.All(file => HashBinarySearch(hashSearchDivider, margin, file.Hash, files) != -1))
                {
                    hashSearchMargin = margin;
                    break;
                }
            }

            return (hashSearchDivider, hashSearchMargin);
        }

        private static int HashBinarySearch(uint divider, uint margin, uint target, List<IgArchiveFile> files)
        {
            long quotient = target / divider;
            
            // Calculate search range
            long startLong = Math.Max(0, quotient - margin);
            long endLong = Math.Min(files.Count - 1, quotient + margin + 1);
            
            if (startLong >= files.Count || endLong < 0)
                return -1;

            int start = (int)startLong;
            int end = (int)endLong;
            
            // Standard binary search within the calculated range
            while (start <= end)
            {
                if (start < 0 || end >= files.Count || start > end)
                    return -1;
                    
                int mid = start + (end - start) / 2;
                
                if (files[mid].Hash == target)
                    return mid;
                
                if (files[mid].Hash < target)
                    start = mid + 1;
                else
                    end = mid - 1;
            }
            
            return -1;
        }
    }

    public static class GameVersionUtils
    {
        public static GameVersion GetGameVersion(this IgArchive.IgArchiveHeader header)
        {
            if (header.version == 11) return GameVersion.NST;
            if (header.version == 13) return GameVersion.CTR;
            throw new Exception("Unknown archive version: " + header.version);
        }

        public static uint GetArchiveVersion(this GameVersion version)
        {
            if (version == GameVersion.NST) return 11;
            if (version == GameVersion.CTR) return 13;
            throw new Exception("Unknown game version: " + version);
        }

        public static string GetRootPath(this GameVersion version, string path = "")
        {
            if (version == GameVersion.NST) return "temporary/mack/data/win64/output/" + path;
            if (version == GameVersion.CTR) return "temporary/octane/data/ps4/output/" + path;
            throw new Exception("Unknown game version: " + version);
        }

        public static int GetLZMAHeaderSize(this GameVersion version)
        {
            if (version == GameVersion.NST) return 2;
            if (version == GameVersion.CTR) return 4;
            throw new Exception("Unknown game version: " + version);
        }
    }
}