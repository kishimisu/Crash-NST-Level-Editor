using Havok;
using SevenZip;
using SevenZip.Compression.LZMA;

namespace Alchemy
{
    /// <summary>
    /// Instance of a file in a .pak archive.
    /// Provides utilities for compressing/decompressing files and converting to IgzFile.
    /// </summary>
    public class IgArchiveFile
    {
        private const string ROOT_DIR = "temporary/mack/data/win64/output/";

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
        
        private string _path;
        private uint _hash;

        private byte[] _data;
        private CompressionType _compressionType = CompressionType.Uncompressed;
        private int _uncompressedSize;

        private BlockData[] _blocksData = [];
        private int _blockIndex;
        private int _sectorSize = IgArchive.SECTOR_SIZE;

        public string GetFullPath() => ROOT_DIR + _path;
        public string GetPath() => _path;
        public uint GetHash() => _hash;
        public int GetUncompressedSize() => _uncompressedSize;
        public int GetBlockIndex() => _blockIndex;
        public byte[] GetData() => _data;

        public bool IsCompressed() => _compressionType != CompressionType.Uncompressed;
        public bool IsIGZ() => _path.EndsWith(".igz") || _path.EndsWith(".lng");
        public bool IsHKX() => Path.GetExtension(_path).StartsWith(".hk");

        /// <summary>
        /// Uncompress and convert this file to an IGZ file
        /// </summary>
        public IgzFile ToIgzFile() => new IgzFile(_path, Uncompress());

        /// <summary>
        /// Uncompress and convert this file to a Havok file
        /// </summary>
        public HavokFile ToHavokFile() => new HavokFile(_path, Uncompress());

        public IgArchiveFile(string path)
        {
            _path = path;
            _hash = NamespaceUtils.ComputeHash(path);
        }

        /// <summary>
        /// Constructor used when parsing an IgArchive
        /// </summary>
        public IgArchiveFile(string path, IgArchive.FileInfo fileInfo, IgArchive.BlockTables blockTables, byte[] igArchiveData, int sectorSize = IgArchive.SECTOR_SIZE) 
        {
            _path = path;
            _sectorSize = sectorSize;
            _uncompressedSize = fileInfo.uncompressedSize;

            // Compute file hash
            _hash = NamespaceUtils.ComputeHash(path);

            // Get compression type (uncompressed or LZMA)
            _compressionType = GetCompressionType(fileInfo.blockIndex);

            // If compressed, extract blocks data for uncompression
            _blocksData = ReadBlockTable(igArchiveData, blockTables, fileInfo);

            // Extract file data
            _data = new byte[GetCompressedSize()];
            Buffer.BlockCopy(igArchiveData, fileInfo.offset, _data, 0, GetCompressedSize());
        }

        /// <summary>
        /// Constructor used when cloning a file
        /// </summary>
        private IgArchiveFile(string path, byte[] data, int uncompressedSize, CompressionType compressionType, BlockData[] blocksData, int sectorSize = IgArchive.SECTOR_SIZE)
        {
            _path = path;
            _data = data;
            _sectorSize = sectorSize;
            _uncompressedSize = uncompressedSize;
            _compressionType = compressionType;
            _blocksData = blocksData;
            _hash = NamespaceUtils.ComputeHash(path);
        }

        /// <summary>
        /// Update the file's raw content
        /// </summary>
        /// <param name="data">The new data for this file (must be uncompressed)</param>
        public void SetData(byte[] data)
        {
            _data = data;
            _uncompressedSize = (int)data.Length;
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
            if (_path == newPath) return;

            if (updateHandles && IsIGZ())
            {
                string newNamespace = Path.GetFileNameWithoutExtension(newPath);
                _data = ToIgzFile().Save(newNamespace);
            }

            _path = newPath;
            _hash = NamespaceUtils.ComputeHash(newPath);
        }

        /// <summary>
        /// Update the file's name without changing its path
        /// </summary>
        /// <param name="nameWithExtension">The new name for this file, including the extension</param>
        public void Rename(string nameWithExtension)
        {
            string newPath = GetPath().Replace(GetName(), nameWithExtension);
            SetPath(newPath);
        }

        /// <summary>
        /// Create a copy of this file, including its data
        /// </summary>
        /// <param name="path">(Optional) The new path for the copy</param>
        /// <returns>A new copy of this file</returns>
        public IgArchiveFile Clone(string? path = null)
        {
            IgArchiveFile clone = new IgArchiveFile(_path, _data.ToArray(), _uncompressedSize, _compressionType, _blocksData, _sectorSize);

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
            return NamespaceUtils.GetFileName(_path, includeExtension);
        }

        /// <summary>
        /// Uncompress the file
        /// </summary>
        /// <returns>The uncompressed data</returns>
        public byte[] Uncompress()
        {
            if (!IsCompressed())
                return _data;

            MemoryStream compressedData = new MemoryStream(_data);
            MemoryStream uncompressedData = new MemoryStream(_uncompressedSize);

            for (int blockId = 0; blockId < _blocksData.Length; blockId++)
            {
                BlockData block = _blocksData[blockId];
                int destinationOffset = blockId * 0x8000;
                UncompressBlock(block.compressionType, block.sourceOffset, destinationOffset, block.uncompressedSize, compressedData, uncompressedData);
            }

            _compressionType = CompressionType.Uncompressed;
            _data = uncompressedData.ToArray();
            _blocksData = [];
            
            if (_data.Length != _uncompressedSize)
                throw new Exception($"Invalid uncompressed size: {_data.Length} != {_uncompressedSize}");

            return _data;
        }

        /// <summary>
        /// Compress the file using LZMA
        /// </summary>
        /// <returns>The compressed data</returns>
        public byte[] Compress()
        {
            if (IsCompressed())
                return _data;

            int blockCount = GetBlockCount();
            BlockData[] blocksData = new BlockData[blockCount];

            MemoryStream data = new MemoryStream(_data);
            MemoryStream compressedData = new MemoryStream();

            data.Seek(0, SeekOrigin.Begin);

            for (int i = 0; i < blockCount; i++)
            {
                byte[] buffer = new byte[0x8000];
                byte[] packedData = new byte[0x10000];
                byte[] properties = new byte[5];

                int uncompressedBlockSize = data.Read(buffer, 0, 0x8000);
                int compressedBlockSize = CompressBlock(buffer, uncompressedBlockSize, packedData, packedData.Length, properties);
                bool compressed = compressedBlockSize < 0x7800;
                
                blocksData[i].sourceOffset = compressedData.GetPosition();
                blocksData[i].uncompressedSize = uncompressedBlockSize;

                if (compressed)
                {
                    compressedData.Write(BitConverter.GetBytes((u16)compressedBlockSize));
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

                compressedData.Align(_sectorSize);
            }

            _data = compressedData.ToArray();
            _blocksData = blocksData;
            _compressionType = CompressionType.LZMA;

            return _data;
        }

        /// <summary>
        /// Called upon saving an igArchive.
        /// Compute the file's block indices and add them to the igArchive's global block table.
        /// </summary>
        /// <param name="blockTables">igArchive's block tables</param>
        public void BuildBlockTable(IgArchive.BlockTables blockTables)
        {
            if (!IsCompressed()) {
                _blockIndex = -1;
                return;
            }

            BlockSize blockSize = GetBlockSize();
            dynamic blockTable = GetBlockTable(blockTables, blockSize);
            uint flag = blockSize == BlockSize.Small ? 0x80u : blockSize == BlockSize.Medium ? 0x8000u : 0x80000000u;

            BuildBlockTable(blockTable, flag);
        }

        private int GetBlockCount()
        {
            return (_uncompressedSize + 0x7FFF) >> 0xF;
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
            if (_uncompressedSize <= (int)BlockSize.Small * _sectorSize)
                return BlockSize.Small;
            else if (_uncompressedSize <= (int)BlockSize.Medium * _sectorSize)
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
        private BlockData[] ReadBlockTable(byte[] igArchiveData, IgArchive.BlockTables blockTables, IgArchive.FileInfo fileInfo)
        {
            if (!IsCompressed())
                return [];

            int blockCount = GetBlockCount();
            BlockSize blockSize = GetBlockSize();

            dynamic blockTable = GetBlockTable(blockTables, blockSize);

            int mask = (int)blockSize;
            int shift = blockSize == BlockSize.Small ? 0x7 : blockSize == BlockSize.Medium ? 0xF : 0x1F;
            int blockStartIndex = fileInfo.blockIndex & 0xFFFFFFF;

            BlockData[] blocksData = new BlockData[blockCount];

            for (int i = 0; i < blockCount; i++)
            {
                int block = blockTable[blockStartIndex + i];
                int blockOffset = (block & mask) * _sectorSize;
                bool blockCompressed = (block >> shift) == 1;
                
                CompressionType compressionType = blockCompressed ? _compressionType : CompressionType.Uncompressed;

                int uncompressedBlockSize = (_uncompressedSize < (i + 1) * 0x8000) ? (_uncompressedSize & 0x7FFF) : 0x8000;

                int compressedBlockSize = uncompressedBlockSize;

                if (compressionType == CompressionType.LZMA)
                {
                    // Read compressed size from LZMA header
                    compressedBlockSize = 7 + BitConverter.ToUInt16(igArchiveData, fileInfo.offset + blockOffset);
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

        private void UncompressBlock(CompressionType compressionType, int sourceOffset, int destinationOffset, int uncompressedSize, MemoryStream source, MemoryStream destination)
        {
            switch (compressionType)
            {
                case CompressionType.Uncompressed:
                    destination.Write(_data, sourceOffset, uncompressedSize);
                    break;

                case CompressionType.LZMA:
                    byte[] compressedSizeBytes = new byte[2];
                    source.Seek(sourceOffset, SeekOrigin.Begin);
                    source.Read(compressedSizeBytes, 0, 2);

                    int compressedSize = BitConverter.ToUInt16(compressedSizeBytes, 0);
                    
                    byte[] properties = new byte[5];
                    source.Seek(sourceOffset + 2, SeekOrigin.Begin);
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

            return destinationStream.GetPosition();
        }

        private void BuildBlockTable<T>(List<T> blockTable, uint flag) where T : struct
        {
            _blockIndex = ((int)_compressionType << 0x1C) | blockTable.Count;

            uint blockIndex = 0;
            foreach (BlockData block in _blocksData)
            {
                uint element = block.compressionType == CompressionType.LZMA ? flag : 0x0;
                element |= blockIndex;

                blockTable.Add((T)Convert.ChangeType(element, typeof(T)));
                blockIndex += ((uint)block.compressedSize + 0x7FF) >> 0xB;
            }

            blockTable.Add((T)Convert.ChangeType(blockIndex, typeof(T)));
        }
    }
}