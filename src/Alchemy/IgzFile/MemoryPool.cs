namespace Alchemy
{
    /// <summary>
    /// Class representing a memory pool (a chunk of memory in an IGZ file with a name and alignment)
    /// </summary>
    public class MemoryPool
    {
        public string name = "Default";
        public int identifier = 0;
        public int alignment = 0;

        public MemoryPool() { }
        public MemoryPool(string name, int identifier, int alignment)
        {
            this.name = name;
            this.identifier = identifier;
            this.alignment = alignment;
        }

        public static readonly MemoryPool Default = new MemoryPool
        {
            name = "Default",
            identifier = 0,
            alignment = 0 
        };

        public ChunkInfo ToChunkInfo(int offset, int size)
        {
            return new ChunkInfo()
            {
                offset = offset,
                size = size,
                alignment = alignment,
                identifier = identifier
            };
        }

        public override string ToString() => $"[MemoryPool] Name: {name}, Offset: {identifier}, Alignment: {alignment}";
        public bool Equals(MemoryPool other) => name == other.name && identifier == other.identifier && alignment == other.alignment;
    }

    /// <summary>
    /// Class representing a chunk descriptor in an IGZ file.
    /// Contains the offset and size for a memory pool.
    /// </summary>
    public class ChunkInfo : MemoryPool
    {
        public i32 offset;
        public i32 size;

        public static readonly ChunkInfo Fixups = new ChunkInfo 
        { 
            offset = 2048, 
            size = 0, 
            alignment = 2048, 
            identifier = 0 
        };

        public static ChunkInfo Parse(BinaryReader reader)
        {
            ChunkInfo chunkInfo  = new ChunkInfo();
            chunkInfo.identifier = reader.ReadInt32();
            chunkInfo.offset     = reader.ReadInt32();
            chunkInfo.size       = reader.ReadInt32();
            chunkInfo.alignment  = reader.ReadInt32();
            return chunkInfo;
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(identifier);
            writer.Write(offset);
            writer.Write(size);
            writer.Write(alignment);
        }

        public override string ToString() => $"[ChunkInfo] Offset: {offset}, Size: {size}, Alignment: {alignment} (MemPoolOffset: {identifier})";
    }
}