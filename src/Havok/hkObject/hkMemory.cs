using Alchemy;

namespace Havok
{
    public abstract class hkMemoryBase : hkObject { }
    
    public abstract class hkMemoryBase<T> : hkMemoryBase
    {
        protected List<T> _elements = [];

        public T this[int index] => _elements[index];
        public int Count => _elements.Count;
        public List<T> GetElements() => _elements;
        public void Add(T element) => _elements.Add(element);
        public void AddRange(List<T> elements) => _elements.AddRange(elements);
        public void Clear() => _elements.Clear();
        public int IndexOf(T element) => _elements.IndexOf(element);
        public void Remove(T element) => _elements.Remove(element);

        protected void ParseElements(HavokFile hkx, BinaryReader reader, int offset, int count)
        {
            int elementSize = AttributeUtils.GetFieldSize(typeof(T));

            for (int i = 0; i < count; i++)
            {
                reader.Seek(offset + i * elementSize);

                T element = (T)ReadValue(hkx, reader, typeof(T))!;
                _elements.Add(element);
            }
        }

        protected void WriteElements(HavokDataSection section, BinaryWriter writer, int offset)
        {
            int elementSize = AttributeUtils.GetFieldSize(typeof(T));

            for (int i = 0; i < _elements.Count; i++)
            {
                writer.Seek(offset + i * elementSize, SeekOrigin.Begin);

                WriteValue(section, writer, _elements[i], true);
            }
        }

        protected int GetDataOffset(HavokDataSection section, BinaryWriter writer)
        {
            if (_elements.Count == 0) return 0;

            int elementSize = AttributeUtils.GetFieldSize(typeof(T));
            int size = _elements.Count * elementSize;

            int dataOffset = section.ReserveBytes(size);

            // Add local fixup for hkMemory<> and hkMemoryPtr<> types
            if (GetType().GetGenericTypeDefinition() != typeof(hkList<>))
            {
                section.AddLocalFixup(writer.GetPosition(), dataOffset);
            }

            return dataOffset;
        }

        public override List<hkObject> GetChildren()
        {
            if (!typeof(T).IsAssignableTo(typeof(hkObject))) return [];

            return _elements.Where(x => x != null).Cast<hkObject>().ToList();
        }
    }

    public class hkMemory<T> : hkMemoryBase<T>
    {
        public override void Parse(HavokFile hkx, BinaryReader reader)
        {
            uint dataOffset = (uint)reader.ReadUInt64();
            uint elementCount = reader.ReadUInt32();
            uint signature = reader.ReadUInt32();

            if ((signature & 0x80000000) == 0) throw new Exception($"Error while parsing {GetType()}: the current offset doesn't point to a memory field");

            ParseElements(hkx, reader, (int)dataOffset, (int)elementCount);
        }

        public override void Write(HavokDataSection section, BinaryWriter writer)
        {
            int dataOffset = GetDataOffset(section, writer);

            writer.Write((u64)0x0);
            writer.Write((u32)_elements.Count);
            writer.Write((u32)_elements.Count | 0x80000000);

            section.AlignNextString = false;

            WriteElements(section, writer, dataOffset);

            section.AlignNextString = true;
        }
    }

    public class hkMemoryPtr<T> : hkMemory<T> where T : hkReferencedObject { }

    public class hkList<T> : hkMemoryBase<T>
    {
        public override void Parse(HavokFile hkx, BinaryReader reader)
        {
            int startOffset = (int)reader.BaseStream.Position;

            int elementCount = reader.ReadUInt16();
            int dataOffset = reader.ReadUInt16() + startOffset;

            ParseElements(hkx, reader, dataOffset, elementCount);
        }

        public override void Write(HavokDataSection section, BinaryWriter writer)
        {
            int position = writer.GetPosition();

            int dataOffset = GetDataOffset(section, writer);
            
            writer.Write((u16)_elements.Count);
            writer.Write((u16)(dataOffset - position));

            WriteElements(section, writer, dataOffset);
        }
    }
}