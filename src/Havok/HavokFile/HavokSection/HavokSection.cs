using Alchemy;

namespace Havok
{
    public class HavokSection
    {
        public static int Size = 64;

        public Dictionary<int, string> virtualFixups = [];

        protected string _name;
        protected int _dataOffset;
        protected int _localFixupOffset;
        protected int _globalFixupOffset;
        protected int _virtualFixupOffset;
        protected int _exportsOffset;
        protected int _importsOffset;
        protected int _bufferSize;
        
        public HavokSection(string name) => _name = name;

        public HavokSection(BinaryReader reader)
        {
            ParseHeader(reader);
        }

        public void ParseHeader(BinaryReader reader)
        {
            // Read header
            long startOffset = reader.BaseStream.Position;
            string sectionTag = reader.ReadNullTerminatedString();

            // Read offsets
            reader.Seek(startOffset + 20);
            _dataOffset = reader.ReadInt32();

            _localFixupOffset   = reader.ReadInt32();
            _globalFixupOffset  = reader.ReadInt32();
            _virtualFixupOffset = reader.ReadInt32();
            _exportsOffset      = reader.ReadInt32();
            _importsOffset      = reader.ReadInt32();
            _bufferSize         = reader.ReadInt32();
        }

        protected void UpdateHeader(int localFixupOffset, int globalFixupOffset = -1, int virtualFixupOffset = -1, int bufferSize = -1)
        {
            if (globalFixupOffset == -1) globalFixupOffset = localFixupOffset;
            if (virtualFixupOffset == -1) virtualFixupOffset = globalFixupOffset;
            if (bufferSize == -1) bufferSize = virtualFixupOffset;
            
            _localFixupOffset = localFixupOffset;
            _globalFixupOffset = globalFixupOffset;
            _virtualFixupOffset = virtualFixupOffset;
            
            _bufferSize = bufferSize;
            _exportsOffset = bufferSize;
            _importsOffset = bufferSize;
        }

        public void WriteHeader(BinaryWriter writer)
        {
            int startOffset = writer.GetPosition();

            // Section name
            writer.WriteNullTerminatedString(_name);
            writer.Seek(startOffset + 19, SeekOrigin.Begin);
            writer.Write((byte)0xFF);

            // Data offset
            writer.Write(_dataOffset);

            if (_bufferSize > 0) 
            {
                // Fixup offsets
                writer.Write(_localFixupOffset);
                writer.Write(_globalFixupOffset);
                writer.Write(_virtualFixupOffset);
                writer.Write(_exportsOffset);
                writer.Write(_importsOffset);
                writer.Write(_bufferSize);
            }

            // Footer
            writer.Seek(startOffset + 48, SeekOrigin.Begin);
            writer.Write(0xFFFFFFFFFFFFFFFF);
            writer.Write(0xFFFFFFFFFFFFFFFF);
        }

        public void Fixup(BinaryReader reader, BinaryWriter writer, List<HavokSection> sections)
        {
            const int LOCAL_FIXUP_SIZE   = 2 * 4;
            const int GLOBAL_FIXUP_SIZE  = 3 * 4;
            const int VIRTUAL_FIXUP_SIZE = 3 * 4;

            // Calculate fixup count
            int virtualEOF = (_exportsOffset == -1 ? _importsOffset : _exportsOffset);
            int localFixupCount = (int)(_globalFixupOffset - _localFixupOffset) / LOCAL_FIXUP_SIZE;
            int globalFixupCount = (int)(_virtualFixupOffset - _globalFixupOffset) / GLOBAL_FIXUP_SIZE;
            int virtualFixupCount = (int)(virtualEOF - _virtualFixupOffset) / VIRTUAL_FIXUP_SIZE;

            // Parse & apply local fixups
            for (int i = 0; i < localFixupCount; i++)
            {
                reader.Seek(_dataOffset + _localFixupOffset + i * LOCAL_FIXUP_SIZE);

                int pointer = reader.ReadInt32();
                int destination = reader.ReadInt32();
                if (pointer == -1) break;

                writer.Seek(_dataOffset + pointer, SeekOrigin.Begin);
                writer.Write(_dataOffset + destination);
            }

            // Parse & apply global fixups
            for (int i = 0; i < globalFixupCount; i++)
            {
                reader.Seek(_dataOffset + _globalFixupOffset + i * GLOBAL_FIXUP_SIZE);

                int pointer = reader.ReadInt32();
                int sectionId = reader.ReadInt32();
                int destination = reader.ReadInt32();
                if (pointer == -1) break;

                writer.Seek(_dataOffset + pointer, SeekOrigin.Begin);
                writer.Write(sections[sectionId]._dataOffset + destination);
            }

            // Parse virtual fixups
            for (int i = 0; i < virtualFixupCount; i++)
            {
                reader.Seek(_dataOffset + _virtualFixupOffset + i * VIRTUAL_FIXUP_SIZE);

                int pointer = reader.ReadInt32();
                int sectionId = reader.ReadInt32();
                int classNameOffset  = reader.ReadInt32();
                if (pointer == -1) break;

                reader.Seek(sections[sectionId]._dataOffset + classNameOffset);
                string className = reader.ReadNullTerminatedString();
                virtualFixups.Add(_dataOffset + pointer, className);
            }
        }

        protected void FillToAlign(BinaryWriter writer, byte fillValue = 0xFF, int alignment = 16)
        {
            while (writer.GetPosition() % alignment != 0) { writer.Write(fillValue); }
        }
    }
}