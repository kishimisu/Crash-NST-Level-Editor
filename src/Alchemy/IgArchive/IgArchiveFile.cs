using Havok;
using SevenZip;
using SevenZip.Compression.LZMA;
using System.IO.Compression;

namespace Alchemy
{
    /// <summary>
    /// Instance of a file in a .pak archive.
    /// Provides utilities for compressing/decompressing files and converting to IgzFile.
    /// </summary>
    public class IgArchiveFile
    {
        private enum BlockSize
        {
            Small = 0x7F,
            Medium = 0x7FFF,
            Large = 0x7FFFFFFF
        }
        
        private enum CompressionType : byte
        {
            Uncompressed = 0x0,
            ZLIB = 0x1,
            LZMA = 0x2,
            LZ4 = 0x3
        }

        private struct BlockData
        {
            public CompressionType compressionType;
            public int sourceOffset;
            public int compressedSize;
            public int uncompressedSize;
        }

        public string Path { get; private set; }
        public string FullPath { get; private set; }

        public uint Hash { get; private set; }
        public GameVersion GameVersion { get; private set; }

        private CompressionType _compressionType = CompressionType.Uncompressed;
        private BlockData[] _blocksData = [];
        private int _uncompressedSize;
        private byte[]? _data = null;

        private string _archivePath;
        private long _archiveOffset;

        public Stream? ArchiveStream { get; set; } = null;

        public bool IsCompressed() => _compressionType != CompressionType.Uncompressed;
        public bool IsIGZ() => Path.EndsWith(".igz") || Path.EndsWith(".lng");
        public bool IsHKX() => NamespaceUtils.GetExtension(Path).StartsWith(".hk");

        /// <summary>
        /// Uncompress and convert this file to an IGZ file
        /// </summary>
        public IgzFile ToIgzFile() => new IgzFile(Path, Uncompress(), GameVersion);

        /// <summary>
        /// Uncompress and convert this file to a Havok file
        /// </summary>
        public HavokFile ToHavokFile() => new HavokFile(Path, Uncompress(), GameVersion);

        public IgArchiveFile(string path, GameVersion version)
        {
            Path = path;
            FullPath = version.GetRootPath(path);
            Hash = NamespaceUtils.ComputeHash(path);

            GameVersion = version;
        }

        /// <summary>
        /// Constructor used when parsing an IgArchive
        /// </summary>
        public IgArchiveFile(string archivePath, string path, string fullPath, IgArchive.FileInfo fileInfo, IgArchive.BlockTables blockTables, Stream igArchiveStream, GameVersion version) 
        {
            Path = path;
            FullPath = fullPath;
            Hash = NamespaceUtils.ComputeHash(path);

            GameVersion = version;

            Setup(igArchiveStream, archivePath, blockTables, fileInfo);
        }

        /// <summary>
        /// Constructor used when cloning a file
        /// </summary>
        private IgArchiveFile(string path, byte[]? data, int uncompressedSize, CompressionType compressionType, BlockData[] blocksData)
        {
            Path = path;
            Hash = NamespaceUtils.ComputeHash(path);

            _data = data;
            _uncompressedSize = uncompressedSize;
            _compressionType = compressionType;
            _blocksData = blocksData;
        }

        public void Setup(Stream igArchiveStream, string archivePath, IgArchive.BlockTables blockTables, IgArchive.FileInfo fileInfo)
        {
            _uncompressedSize = fileInfo.uncompressedSize;

            _archivePath = archivePath;
            _archiveOffset = GetGlobalOffset(fileInfo);
            
            _compressionType = GetCompressionType(fileInfo.blockIndex);
            _blocksData = ReadBlockTable(igArchiveStream, blockTables, fileInfo.blockIndex);
        }

        /// <summary>
        /// Update the file's raw content
        /// </summary>
        /// <param name="data">The new data for this file (must be uncompressed)</param>
        public void SetData(byte[] data)
        {
            _data = data;
            _uncompressedSize = data.Length;
            _compressionType = CompressionType.Uncompressed;
            _blocksData = [];
        }

        /// <summary>
        /// Update the file's path
        /// </summary>
        /// <param name="newPath">The new path for this file, including the name and extension</param>
        /// <param name="updateHandles">(IGZ files only) Also update self-referencing handles to match the new path.</param>
        public void SetPath(string newPath, bool updateHandles = true)
        {
            if (Path == newPath) return;

            if (updateHandles && IsIGZ())
            {
                string newNamespace = NamespaceUtils.GetFileName(newPath, false);
                SetData(ToIgzFile().Save(newNamespace));
            }

            Path = newPath;
            Hash = NamespaceUtils.ComputeHash(newPath);

            if (FullPath.Contains(Path))
            {
                FullPath = FullPath.Replace(Path, newPath);
            }
            else
            {
                FullPath = GameVersion.GetRootPath(newPath);
            }
        }
        
        /// <summary>
        /// Change the file's game version and update its full path accordingly
        /// </summary>
        /// <param name="version"></param>
        public void SetGameVersion(GameVersion version)
        {
            GameVersion = version;
            FullPath = version.GetRootPath(Path);
        }

        /// <summary>
        /// Update the file's name without changing its path
        /// </summary>
        /// <param name="nameWithExtension">The new name for this file, including the extension</param>
        public void Rename(string nameWithExtension)
        {
            string newPath = Path.Replace(GetName(), nameWithExtension);
            SetPath(newPath);
        }

        /// <summary>
        /// Create a copy of this file, including its data
        /// </summary>
        /// <param name="path">(Optional) The new path for the copy</param>
        /// <returns>A new copy of this file</returns>
        public IgArchiveFile Clone(string? path = null)
        {
            IgArchiveFile clone = new IgArchiveFile(Path, _data, _uncompressedSize, _compressionType, _blocksData)
            {
                FullPath = FullPath,
                GameVersion = GameVersion,
                _archivePath = _archivePath,
                _archiveOffset = _archiveOffset,
            };

            if (path != null)
            {
                clone.SetPath(path);
            }

            return clone;
        }
        
        /// <summary>
        /// Uncompress and save the file to disk
        /// </summary>
        /// <param name="path">The path to save the file to</param>
        public void Save(string path)
        {
            File.WriteAllBytes(path, Uncompress());
        }

        /// <summary>
        /// Get the file's name
        /// </summary>
        /// <param name="includeExtension"></param>
        public string GetName(bool includeExtension = true)
        {
            return NamespaceUtils.GetFileName(Path, includeExtension);
        }

        private byte[] ReadDataFromDisk()
        {
            int compressedSize = GetCompressedSize();
            byte[] data = new byte[compressedSize];

            if (ArchiveStream == null)
            {
                using FileStream fs = File.OpenRead(_archivePath);
                fs.Seek(_archiveOffset, SeekOrigin.Begin);
                fs.ReadExactly(data, 0, compressedSize);
            }
            else
            {
                ArchiveStream.Seek(_archiveOffset, SeekOrigin.Begin);
                ArchiveStream.ReadExactly(data, 0, compressedSize);
            }

            return data;
        }

        /// <summary>
        /// Read raw data from the file
        /// </summary>
        public byte[] GetData()
        {
            if (_data != null)
                return _data;

            return ReadDataFromDisk();
        }

        /// <summary>
        /// Read and uncompress data from the file
        /// </summary>
        /// <returns>The uncompressed data</returns>
        public byte[] Uncompress(bool update = false)
        {
            byte[] data = GetData();

            if (!IsCompressed())
                return data;

            MemoryStream compressedData = new MemoryStream(data);
            MemoryStream uncompressedData = new MemoryStream(_uncompressedSize);

            for (int blockId = 0; blockId < _blocksData.Length; blockId++)
            {
                BlockData block = _blocksData[blockId];
                int destinationOffset = blockId * 0x8000;
                UncompressBlock(block.compressionType, block.sourceOffset, destinationOffset, block.uncompressedSize, compressedData, uncompressedData, GameVersion);
            }

            if (uncompressedData.Length != _uncompressedSize)
                throw new Exception($"Invalid uncompressed size: {uncompressedData.Length} != {_uncompressedSize}");

            byte[] uncompressedBytes = uncompressedData.ToArray();

            if (update)
            {
                _blocksData = [];
                _compressionType = CompressionType.Uncompressed;

                if (_data != null)
                    _data = uncompressedBytes;
            }

            return uncompressedBytes;
        }

        /// <summary>
        /// Compress the file using LZMA
        /// </summary>
        /// <returns>The compressed data</returns>
        public byte[] Compress(bool update = false)
        {
            byte[] data = GetData();

            if (IsCompressed())
                return data;

            int blockCount = GetBlockCount();
            BlockData[] blocksData = new BlockData[blockCount];

            MemoryStream dataStream = new MemoryStream(data);
            MemoryStream compressedData = new MemoryStream();

            dataStream.Seek(0, SeekOrigin.Begin);

            for (int i = 0; i < blockCount; i++)
            {
                byte[] buffer = new byte[0x8000];
                byte[] packedData = new byte[0x10000];
                byte[] properties = new byte[5];

                int uncompressedBlockSize = dataStream.Read(buffer, 0, 0x8000);
                int compressedBlockSize = CompressBlock(buffer, uncompressedBlockSize, packedData, packedData.Length, properties);
                bool compressed = compressedBlockSize < 0x7800;
                
                blocksData[i].sourceOffset = (int)compressedData.Position;
                blocksData[i].uncompressedSize = uncompressedBlockSize;

                if (compressed)
                {
                    var compressedSizeBytes = GameVersion.GetLZMAHeaderSize() == 2
                        ? BitConverter.GetBytes((u16)compressedBlockSize)
                        : BitConverter.GetBytes(compressedBlockSize);

                    compressedData.Write(compressedSizeBytes);
                    compressedData.Write(properties);
                    compressedData.Write(packedData, 0, compressedBlockSize);

                    blocksData[i].compressedSize = compressedBlockSize + 7;
                    blocksData[i].compressionType = CompressionType.LZMA;
                }
                else 
                {
                    compressedData.Write(buffer, 0, uncompressedBlockSize);

                    blocksData[i].compressedSize = uncompressedBlockSize;
                    blocksData[i].compressionType = CompressionType.Uncompressed;
                }

                compressedData.Align(IgArchive.SECTOR_SIZE);
            }

            byte[] compressedBytes = compressedData.ToArray();

            if (update)
            {
                _blocksData = blocksData;
                _compressionType = CompressionType.LZMA;

                if (_data != null)
                    _data = compressedBytes;
            }
            
            return compressedBytes;
        }

        /// <summary>
        /// Whether to skip compression for this file or not.
        /// Some files have been observed to freeze the game after a while when compressed.
        /// </summary>
        public bool SkipCompression()
        {
            return Path.StartsWith("sound_samples") || Path.StartsWith("sound_streams");
        }

        public IgArchive.FileInfo BuildFileInfos(int index, long offset, long fileOffset, int blockIndex)
        {
            var fileInfos = new IgArchive.FileInfo()
            {
                ordinal = (index - 1) << 0x8,
                uncompressedSize = _uncompressedSize,
                blockIndex = blockIndex,
            };

            offset += fileOffset;
            
            if (offset > uint.MaxValue)
            {
                fileInfos.offset = (u32)(offset - uint.MaxValue - 1);
                fileInfos.ordinal |= 0x1;
            }
            else
            {
                fileInfos.offset = (u32)offset;
            }

            return fileInfos;
        }

        /// <summary>
        /// Called upon saving an igArchive.
        /// Compute the file's block indices and add them to the igArchive's global block table.
        /// </summary>
        /// <param name="blockTables">igArchive's block tables</param>
        public int BuildBlockTable(IgArchive.BlockTables blockTables)
        {
            if (!IsCompressed())
                return -1;

            BlockSize blockSize = GetBlockSize();
            dynamic blockTable = GetBlockTable(blockTables, blockSize);
            uint flag = blockSize == BlockSize.Small ? 0x80u : blockSize == BlockSize.Medium ? 0x8000u : 0x80000000u;

            return BuildBlockTable(blockTable, flag);
        }

        private int GetBlockCount()
        {
            return (_uncompressedSize + 0x7FFF) >> 0xF;
        }

        private static long GetGlobalOffset(IgArchive.FileInfo fileInfo)
        {
            if ((fileInfo.ordinal & 1) == 0)
            {
                return fileInfo.offset;
            }
            else
            {
                return (long)uint.MaxValue + fileInfo.offset + 1;
            }
        }

        private static CompressionType GetCompressionType(int blockIndex)
        {
            if (blockIndex == -1)
                return CompressionType.Uncompressed;

            return (CompressionType)(blockIndex >> 0x1C);
        }

        // Space used by the file in the archive
        private int GetCompressedSize()
        {
            if (!IsCompressed())
                return _uncompressedSize;
            
            BlockData lastBlock = _blocksData.Last();

            return lastBlock.sourceOffset + lastBlock.compressedSize;
        }

        private BlockSize GetBlockSize()
        {
            if (_uncompressedSize <= (int)BlockSize.Small * IgArchive.SECTOR_SIZE)
                return BlockSize.Small;
            else if (_uncompressedSize <= (int)BlockSize.Medium * IgArchive.SECTOR_SIZE)
                return BlockSize.Medium;
            else
                return BlockSize.Large;
        }

        private static dynamic GetBlockTable(IgArchive.BlockTables blockTables, BlockSize blockSize)
        {
            return blockSize switch
            {
                BlockSize.Small => blockTables.smallBlocks,
                BlockSize.Medium => blockTables.mediumBlocks,
                BlockSize.Large => blockTables.largeBlocks,
                _ => throw new NotImplementedException("Unknown block size: " + blockSize),
            };
        }

        // Store local blocks data from the igArchive's global block tables so that the file can be uncompressed later
        private BlockData[] ReadBlockTable(Stream igArchiveStream, IgArchive.BlockTables blockTables, int blockIndex)
        {
            if (!IsCompressed())
                return [];

            int blockCount = GetBlockCount();
            BlockSize blockSize = GetBlockSize();

            dynamic blockTable = GetBlockTable(blockTables, blockSize);

            int mask = (int)blockSize;
            int shift = blockSize == BlockSize.Small ? 0x7 : blockSize == BlockSize.Medium ? 0xF : 0x1F;
            int blockStartIndex = blockIndex & 0xFFFFFFF;
            int lzma_header_size = GameVersion.GetLZMAHeaderSize();

            BlockData[] blocksData = new BlockData[blockCount];
            byte[] sizeBytes = new byte[lzma_header_size];

            for (int i = 0; i < blockCount; i++)
            {
                int block = blockTable[blockStartIndex + i];
                int blockOffset = (block & mask) * IgArchive.SECTOR_SIZE;
                bool blockCompressed = (block >> shift) == 1;
                
                CompressionType compressionType = blockCompressed ? _compressionType : CompressionType.Uncompressed;

                int uncompressedBlockSize = (_uncompressedSize < (i + 1) * 0x8000) ? (_uncompressedSize & 0x7FFF) : 0x8000;

                int compressedBlockSize = uncompressedBlockSize;

                if (compressionType == CompressionType.LZMA)
                {
                    // Read compressed size from LZMA header
                    igArchiveStream.Seek(_archiveOffset + blockOffset, SeekOrigin.Begin);
                    igArchiveStream.ReadExactly(sizeBytes);
                    int compressedSize = lzma_header_size == 2 ? BitConverter.ToUInt16(sizeBytes) : BitConverter.ToInt32(sizeBytes);
                    compressedBlockSize = 5 + lzma_header_size + compressedSize;
                }

                blocksData[i] = new BlockData
                {
                    compressionType = compressionType,
                    sourceOffset = blockOffset,
                    uncompressedSize = uncompressedBlockSize,
                    compressedSize = compressedBlockSize
                };
            }

            return blocksData;
        }

        private static void UncompressBlock(CompressionType compressionType, int sourceOffset, int destinationOffset, int uncompressedSize, MemoryStream source, MemoryStream destination, GameVersion version)
        {
            switch (compressionType)
            {
                case CompressionType.Uncompressed:
                    destination.Write(source.ToArray(), sourceOffset, uncompressedSize);
                    break;

                case CompressionType.ZLIB:
                    byte[] compressedSizeBytes = new byte[2];
                    source.Seek(sourceOffset, SeekOrigin.Begin);
                    source.Read(compressedSizeBytes, 0, 2);

                    int compressedSize = BitConverter.ToUInt16(compressedSizeBytes, 0);

                    byte[] compressed = new byte[compressedSize];
                    source.Read(compressed, 0, compressedSize);

                    MemoryStream compressedStream = new MemoryStream(compressed);
                    DeflateStream stream = new DeflateStream(compressedStream, CompressionMode.Decompress);
                    
                    byte[] buffer = new byte[uncompressedSize];
                    stream.ReadExactly(buffer, 0, uncompressedSize);

                    destination.Seek(destinationOffset, SeekOrigin.Begin);
                    destination.Write(buffer);
                    break;

                case CompressionType.LZMA:
                    int lzma_header_size = version.GetLZMAHeaderSize();
                    compressedSizeBytes = new byte[lzma_header_size];
                    source.Seek(sourceOffset, SeekOrigin.Begin);
                    source.Read(compressedSizeBytes, 0, lzma_header_size);

                    compressedSize = lzma_header_size == 2 ? BitConverter.ToUInt16(compressedSizeBytes) : BitConverter.ToInt32(compressedSizeBytes);
                    
                    byte[] properties = new byte[5];
                    source.Seek(sourceOffset + lzma_header_size, SeekOrigin.Begin);
                    source.Read(properties, 0, 5);

                    Decoder decoder = new Decoder();
                    decoder.SetDecoderProperties(properties);
                    decoder.Code(source, destination, compressedSize, uncompressedSize, null);
                    break;

                default:
                    throw new NotImplementedException("Unknown compression type: " + compressionType);
            }
        }        

        private static CoderPropID[] coderPropIDs =
        [
            CoderPropID.DictionarySize,
            CoderPropID.PosStateBits,
            CoderPropID.LitContextBits,
            CoderPropID.LitPosBits,
            CoderPropID.Algorithm,
            CoderPropID.NumFastBytes,
            CoderPropID.EndMarker,
            CoderPropID.MatchFinder,
        ];
        private static object[] coderProperties = [0x8000, 2, 3, 0, 2, 0x80, false, "bt4"];

        // Compress a block using LZMA algorithm
        private static int CompressBlock(byte[] source, int sourceLength, byte[] destination, int destinationLength, byte[] properties)
        {
            using MemoryStream sourceStream = new MemoryStream(source, 0, sourceLength, false);
            using MemoryStream destinationStream = new MemoryStream(destination, 0, destinationLength);

            Encoder encoder = new Encoder();
            encoder.SetCoderProperties(coderPropIDs, coderProperties);
            encoder.WriteCoderProperties(new MemoryStream(properties));
            encoder.Code(sourceStream, destinationStream, -1, -1, null);

            return (int)destinationStream.Position;
        }

        private int BuildBlockTable<T>(List<T> blockTable, uint flag) where T : struct
        {
            int initialCount = blockTable.Count;
            uint blockIndex = 0;

            foreach (BlockData block in _blocksData)
            {
                uint element = block.compressionType == CompressionType.LZMA ? flag : 0x0;
                element |= blockIndex;

                blockTable.Add((T)Convert.ChangeType(element, typeof(T)));
                blockIndex += ((uint)block.compressedSize + 0x7FF) >> 0xB;
            }

            blockTable.Add((T)Convert.ChangeType(blockIndex, typeof(T)));

            return ((int)_compressionType << 0x1C) | initialCount;
        }
    }
}