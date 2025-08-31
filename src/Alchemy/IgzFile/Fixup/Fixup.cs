namespace Alchemy
{
    /// <summary>
    /// Interface for a fixup
    /// </summary>
    public interface IFixup
    {
        public string GetName();
        public int GetCount();
        public int GetSize();
        public bool IsEmpty() => GetCount() == 0;
        public void Write(BinaryWriter writer);
    }

    /// <summary>
    /// Base class for all fixups
    /// </summary>
    public abstract class Fixup<T> : List<T>, IFixup
    {
        protected string _name;
        protected int _itemCount;
        protected int _fixupSize;
        protected int _headerSize = 16;

        public string GetName() => _name;
        public int GetSize() => _fixupSize;
        public int GetCount() => Count;
        public bool IsEmpty() => Count == 0;

        public Fixup(List<T> items) : base(items) {}

        protected Fixup(string name, int headerSize = 16) : base() 
        { 
            _name = name; 
            _headerSize = headerSize; 
        }

        protected abstract void Parse(BinaryReader reader);
        protected abstract void WriteItems(BinaryWriter writer);

        /// <summary>
        /// Parse a fixup from a memory stream
        /// </summary>
        /// <param name="reader">The BinaryReader to read from</param>
        /// <param name="name">The fixup name</param>
        /// <param name="fixupStartOffset">The offset to the start of the fixup</param>
        protected Fixup(BinaryReader reader, string name, int fixupStartOffset)
        {
            _name = name;
            _itemCount = reader.ReadInt32();
            _fixupSize = reader.ReadInt32();
            _headerSize = reader.ReadInt32();

            reader.Seek(fixupStartOffset + _headerSize);

            Parse(reader);
        }

        /// <summary>
        /// Write a fixup to a memory stream
        /// </summary>
        /// <param name="writer">The BinaryWriter to write to</param>
        public void Write(BinaryWriter writer)
        {
            if (Count == 0) return;

            int startPosition = writer.GetPosition();
            
            writer.Seek(_headerSize, SeekOrigin.Current);
            
            // Write data
            WriteItems(writer);
            writer.Align(4);

            _itemCount = Count;
            _fixupSize = writer.GetPosition() - startPosition;

            // Write header
            writer.Seek(startPosition, SeekOrigin.Begin);
            writer.WriteChars(_name);
            writer.Write(_itemCount);
            writer.Write(_fixupSize);
            writer.Write(_headerSize);

            writer.Seek(startPosition + _fixupSize, SeekOrigin.Begin);
        }
    }

    public class TDEP_Fixup : Fixup<TDEP_Fixup.TDEP_Item>
    {
        public struct TDEP_Item
        {
            public string name;
            public string path;
            public override readonly string ToString() => $"{path}::{name}";
        }

        public TDEP_Fixup() : base("TDEP") {}
        public TDEP_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}

        protected override void Parse(BinaryReader reader)
        {
            for (int i = 0; i < _itemCount; i++)
            {
                string name = reader.ReadNullTerminatedString();
                string path = reader.ReadNullTerminatedString();

                TDEP_Item item = new TDEP_Item() { name = name, path = path };

                Add(item);
            }
        }

        protected override void WriteItems(BinaryWriter writer)
        {
            foreach (TDEP_Item item in this)
            {
                writer.WriteNullTerminatedString(item.name);
                writer.WriteNullTerminatedString(item.path);
            }

            writer.BaseStream.Position += 4 - (writer.BaseStream.Position % 4);
        }
    }

    public class TSTR_Fixup : Fixup<string>
    {
        public TSTR_Fixup(string name = "TSTR") : base(name) {}
        public TSTR_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}
        protected TSTR_Fixup(List<string> items) : base(items) { _name = "TSTR"; }

        public int AddUnique(string item)
        {
            int index = IndexOf(item);

            if (index == -1)
            {
                index = Count;
                Add(item);
            }

            return index;
        }

        protected override void Parse(BinaryReader reader)
        {
            for (int i = 0; i < _itemCount; i++)
            {
                string name = reader.ReadNullTerminatedString();

                Add(name);

                if (reader.PeekChar() == '\0') 
                    reader.ReadChar();
            }
        }

        protected override void WriteItems(BinaryWriter writer)
        {
            foreach (string item in this)
            {
                writer.WriteNullTerminatedString(item);
                writer.Align(2);
            }
        }
    }

    public class TMET_Fixup : TSTR_Fixup
    {
        public TMET_Fixup() : base("TMET") {}
        public TMET_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}
    }

    public class MTSZ_Fixup : Fixup<int>
    {
        public MTSZ_Fixup(string name = "MTSZ") : base(name) {}
        public MTSZ_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) { }

        protected override void Parse(BinaryReader reader)
        {
            for (int i = 0; i < _itemCount; i++)
            {
                int size = reader.ReadInt32();
                Add(size);
            }
        }

        protected override void WriteItems(BinaryWriter writer)
        {
            foreach (int item in this)
            {
                writer.Write(item);
            }
        }
    }

    public class ONAM_Fixup : MTSZ_Fixup
    {
        public ONAM_Fixup() : base("ONAM") {}
        public ONAM_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}
    }

    public class NSPC_Fixup : MTSZ_Fixup
    {
        public NSPC_Fixup() : base("NSPC") {}
        public NSPC_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}
    }

    public class EXNM_Fixup : Fixup<HashedReference>
    {
        public EXNM_Fixup(string name = "EXNM") : base(name) {}
        public EXNM_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}

        protected override void Parse(BinaryReader reader)
        {
            for (int i = 0; i < _itemCount; i++)
            {
                uint objectHash = reader.ReadUInt32();
                uint fileHash = reader.ReadUInt32();

                HashedReference item = new HashedReference() { objectHash = objectHash, fileHash = fileHash };

                Add(item);
            }
        }

        protected override void WriteItems(BinaryWriter writer)
        {
            int startPosition = writer.GetPosition() - _headerSize;
            writer.Align(8);

            _headerSize = writer.GetPosition() - startPosition;

            foreach (HashedReference item in this)
            {
                writer.Write(item.objectHash);
                writer.Write(item.fileHash);
            }
        }
    }

    public class EXID_Fixup : EXNM_Fixup
    {
        public EXID_Fixup() : base("EXID") {}
        public EXID_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}
    }
}