using System.Text.RegularExpressions;

namespace Alchemy
{
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

    /// <summary>
    /// Instance of a .pak file.
    /// Provides utilities for manipulating files within the archive.
    /// </summary>
    public class IgArchive
    {
        private const u32 SIGNATURE = 0x1A414749;
        private const u32 VERSION = 11;
        private const u32 HEADER_SIZE = 0x38;
        public const i32 SECTOR_SIZE = 0x800;
        
        private struct IgArchiveHeader
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
            public i32 offset;
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

        private string _path = "";
        private List<IgArchiveFile> _files = [];

        public string GetName(bool includeExtension = true) => NamespaceUtils.GetFileName(_path, includeExtension);
        public string GetPath() => _path;
        public void SetPath(string path) => _path = path;

        public List<IgArchiveFile> GetFiles() => _files;
        public void AddFile(IgArchiveFile file) => _files.Add(file);
        public void RemoveFile(IgArchiveFile file) => _files.Remove(file);

        public IgArchive(string path) => _path = path;

        public IgArchive(string path, List<IgArchiveFile> files)
        {
            _path = path;
            _files = files;
        }

        /// <summary>
        /// Opens a .pak file from disk
        /// </summary>
        /// <param name="filePath">The path to the .pak file</param>
        /// <returns>A new IgArchive instance</returns>
        public static IgArchive Open(string filePath) => Open(new FileStream(filePath, FileMode.Open, FileAccess.Read), filePath);

        public static IgArchive Open(Stream fs, string filePath) 
        {
            // Open file
            using BinaryReader reader = new BinaryReader(fs);

            // Parse header
            IgArchiveHeader header = reader.ReadStruct<IgArchiveHeader>();
            
            // LogHeader(header);
            VerifyHeader(header);

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

            reader.Seek(0);
            byte[] allBytes = reader.ReadBytes((int)fs.Length); //todo: clean

            for (int i = 0; i < header.fileCount; i++)
            {
                (string fullPath, string path) = filePaths[i];

                IgArchiveFile file = new IgArchiveFile(path, fileInfos[i], blockTables, allBytes);

                if (fileIds[i] != file.GetHash())
                    Console.WriteLine($"[ERROR] {i}: {fileIds[i]} != {file.GetHash()} for {path}");
                if (fullPath != file.GetFullPath())
                    Console.WriteLine($"[ERROR] {i}: {fullPath} != {file.GetFullPath()} for {path}");

                files.Add(file);
            }

            return new IgArchive(filePath, files);
        }

        /// <summary>
        /// Save the archive to disk
        /// </summary>
        /// <param name="filePath">The path to save the archive to</param>
        /// <param name="updatePath">Whether to update this IgArchive's path to match the file path</param>
        public void Save(string? filePath = null, bool updatePath = false)
        {
            if (filePath == null)
            {
                filePath = _path;
            }
            else if (updatePath)
            {
                _path = filePath;
            }

            // Sort files by hash
            _files.Sort((f1, f2) => f1.GetHash().CompareTo(f2.GetHash()));

            // Build block tables
            BlockTables blockTables = BuildBlockTables();

            // Build header
            IgArchiveHeader header = BuildHeader(blockTables);

            // Create writer
            using FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using BinaryWriter writer = new BinaryWriter(fs);
            
            uint filesOffset = HEADER_SIZE + header.tocSize;

            writer.Seek((int)filesOffset, SeekOrigin.Begin);
            writer.Align(SECTOR_SIZE);

            FileInfo[] fileInfos = new FileInfo[_files.Count];

            // Write file contents and build file infos
            for (int i = 0; i < _files.Count; i++)
            {
                fileInfos[i].ordinal = (i - 1) << 0x8;
                fileInfos[i].offset = writer.GetPosition();
                fileInfos[i].blockIndex = _files[i].GetBlockIndex();
                fileInfos[i].uncompressedSize = _files[i].GetUncompressedSize();

                writer.Write(_files[i].GetData());
                writer.Align(SECTOR_SIZE);
            }

            int pathsOffsetsStart = writer.GetPosition();
            int pathsNamesStart = writer.GetPosition() + _files.Count * sizeof(uint);
            writer.Seek(pathsNamesStart, SeekOrigin.Begin);

            // Write file paths
            for (int i = 0; i < _files.Count; i++)
            {
                int offset = writer.GetPosition();
                writer.Seek(pathsOffsetsStart + i * sizeof(uint), SeekOrigin.Begin);
                writer.Write(offset - pathsOffsetsStart);

                writer.Seek(offset, SeekOrigin.Begin);
                writer.WriteNullTerminatedString(_files[i].GetFullPath());
                writer.WriteNullTerminatedString(_files[i].GetPath());
                writer.Write(0);
            }

            int archiveSize = writer.GetPosition();
            header.pathTableOffset = (u64)pathsOffsetsStart;
            header.pathTableSize = (uint)(archiveSize - pathsOffsetsStart);

            // Write header
            writer.Seek(0, SeekOrigin.Begin);
            writer.WriteStruct(header);

            // Write file hashes
            for (int i = 0; i < _files.Count; i++)
                writer.Write(_files[i].GetHash());

            // Write file infos
            for (int i = 0; i < _files.Count; i++)
                writer.WriteStruct(fileInfos[i]);

            // Write block tables
            for (int i = 0; i < blockTables.largeBlocks.Count; i++)
                writer.Write(blockTables.largeBlocks[i]);

            for (int i = 0; i < blockTables.mediumBlocks.Count; i++)
                writer.Write(blockTables.mediumBlocks[i]);

            for (int i = 0; i < blockTables.smallBlocks.Count; i++)
                writer.Write(blockTables.smallBlocks[i]);

            Console.WriteLine($"Saved {filePath} ({_files.Count} files, {archiveSize/1024f/1024f:0.00} MB)");
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
                path = file.GetPath().Replace(fileName, fileName + "_" + index++);
            } 
            while (FindFile(path, FileSearchType.Path) != null);

            IgArchiveFile clone = file.Clone(path);
            AddFile(clone);

            return clone;
        }

        /// <summary>
        /// Find a file in the archive
        /// </summary>
        /// <param name="name">The string to search for</param>
        /// <param name="searchType">How the string should be compared</param>
        /// <returns>The first file that matches the search criteria, or null if no match is found</returns>
        public IgArchiveFile? FindFile(string name, FileSearchType searchType = FileSearchType.NameWithExtension, StringComparison comp = StringComparison.InvariantCultureIgnoreCase)
        {
            IgArchiveFile? file = searchType switch
            {
                FileSearchType.Name => 
                    _files.Find(f => f.GetName(false).Equals(name, comp)),
                FileSearchType.NameContains =>
                    _files.Find(f => f.GetName(false).Contains(name, comp)),
                FileSearchType.NameStartsWith =>
                    _files.Find(f => f.GetName(false).StartsWith(name, comp)),
                FileSearchType.NameWithExtension =>
                    _files.Find(f => f.GetName().Equals(name, comp)),
                FileSearchType.Path => 
                    _files.Find(f => f.GetPath().Equals(name, comp)),
                FileSearchType.FullPath => 
                    _files.Find(f => f.GetFullPath().Equals(name, comp)),
                FileSearchType.NamespaceHash =>
                    _files.Find(f => NamespaceUtils.ComputeHash(f.GetName(false)).ToString() == name),

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
            return _files.Find(f => f.GetPath().Contains("StaticCollision") && f.GetPath().EndsWith(extension));
        }

        public IgArchiveFile? FindPackageFile()
        {
            return _files.Find(f => f.GetPath().EndsWith("_pkg.igz"));
        }

        public IgArchiveFile? FindMainMapFile()
        {
            Regex regex = new Regex(@"^maps\/([^\/]+)\/([^\/\.]+)\/\2\.igz$");
            return _files.Find(f => regex.IsMatch(f.GetPath()));
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

        /// <summary>
        /// Compress all files in the archive
        /// </summary>
        public void CompressAll()
        {
            Compress(_files);
        }

        /// <summary>
        /// Uncompress all files in the archive
        /// </summary>
        public void UncompressAll()
        {
            Uncompress(_files);
        }

        /// <summary>
        /// Compress a list of files using multiple threads
        /// </summary>
        /// <param name="files">The files to compress</param>
        public static void Compress(List<IgArchiveFile> files)
        {
            Parallel.For(0, files.Count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, i =>
            {
                files[i].Compress();
            });
        }

        /// <summary>
        /// Uncompress a list of files using multiple threads
        /// </summary>
        /// <param name="files">The files to uncompress</param>
        public static void Uncompress(List<IgArchiveFile> files)
        {
            Parallel.For(0, files.Count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, i =>
            {
                files[i].Uncompress();
            });
        }

        private static List<(string, string)> ParseFilePaths(IgArchiveHeader header, BinaryReader reader)
        {   
            reader.Seek((int)header.pathTableOffset);

            u32[] filePathOffsets = reader.ReadArray<u32>((int)header.fileCount);

            var paths = new List<(string, string)>((int)header.fileCount);

            for (int i = 0; i < header.fileCount; i++)
            {
                int offset = (int)header.pathTableOffset + (int)filePathOffsets[i];
                reader.Seek(offset);

                string fullPath = reader.ReadNullTerminatedString();
                string path = reader.ReadNullTerminatedString();

                paths.Add((fullPath, path));
            }

            return paths;
        }

        private BlockTables BuildBlockTables()
        {
            BlockTables blockTables = new BlockTables();

            for (int i = 0; i < _files.Count; i++)
            {
                _files[i].BuildBlockTable(blockTables);
            }
            
            return blockTables;
        }

        private IgArchiveHeader BuildHeader(BlockTables blockTables)
        {
            (uint hashSearchDivider, uint hashSearchMargin) = ComputeHashSearchParams(_files);

            uint tocSize = (uint)(_files.Count * sizeof(u32) * 5
                            + blockTables.largeBlocks.Count  * sizeof(u32)
                            + blockTables.mediumBlocks.Count * sizeof(u16)
                            + blockTables.smallBlocks.Count  * sizeof(u8));

            IgArchiveHeader header = new IgArchiveHeader() 
            {
                signature = SIGNATURE,
                version = VERSION,
                tocSize = tocSize,
                fileCount = (uint)_files.Count,
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
                if (files.All(file => HashBinarySearch(hashSearchDivider, margin, file.GetHash(), files) != -1))
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
                
                if (files[mid].GetHash() == target)
                    return mid;
                
                if (files[mid].GetHash() < target)
                    start = mid + 1;
                else
                    end = mid - 1;
            }
            
            return -1;
        }

        private static void VerifyHeader(IgArchiveHeader header)
        {
            if (header.signature != SIGNATURE)
                throw new Exception($"Invalid IgArchive signature: 0x{header.signature:X}");
            if (header.version != VERSION)
                throw new Exception($"Invalid IgArchive version: {header.version}");
            if (header.sectorSize != SECTOR_SIZE)
                throw new Exception($"Invalid IgArchive sector size: {header.sectorSize}");
        }

        private static void LogHeader(IgArchiveHeader header)
        {
            Console.WriteLine($"[ igArchive header ] File count: {header.fileCount}");
            Console.WriteLine($"Signature: 0x{header.signature:X}, version: {header.version}");
            Console.WriteLine($"TOC size: {header.tocSize}, Sector size: {header.sectorSize}, Flags: 0x{header.flags:X}");
            Console.WriteLine($"Hash search params: {header.hashSearchDivider}/{header.hashSearchMargin}");
            Console.WriteLine($"Block count (small, medium, large): {header.smallBlockCount}, {header.mediumBlockCount}, {header.largeBlockCount}");
            Console.WriteLine($"Path table offset: 0x{header.pathTableOffset:X}, size: {header.pathTableSize}");
        }

        private static void LogFileInfo(FileInfo fileInfo)
        {
            Console.WriteLine($"[ igArchive file ] offset: 0x{fileInfo.offset:X} ordinal: {fileInfo.ordinal} size: {fileInfo.uncompressedSize} blockIndex: {fileInfo.blockIndex}");
        }
    }
}