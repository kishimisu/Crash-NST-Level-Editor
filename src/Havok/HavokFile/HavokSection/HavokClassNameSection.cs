using Alchemy;

namespace Havok
{
    public class HavokClassNameSection : HavokSection
    {
        public HavokClassNameSection() : base("__classnames__") { }

        private Dictionary<string, int> _classNameOffsets = [];

        public int GetClassOffset(hkObject obj) => _classNameOffsets[obj.GetType().Name];

        public void WriteClassNames(BinaryWriter writer, List<hkObject> objects)
        {
            List<(string name, uint hash)> requiredClassNames = new() {
                ("hkClass", 0x33d42383),
                ("hkClassMember", 0xb0efa719),
                ("hkClassEnum", 0x8a3609cf),
                ("hkClassEnumItem", 0xce6f8a6c),
            };

            List<(string name, uint hash)> newClassNames = objects
                .DistinctBy(x => x.GetType())
                .Select(x => (x.GetType().Name, x.Hash))
                .ToList();

            _dataOffset = writer.GetPosition();

            foreach ((string className, uint hash) in requiredClassNames.Concat(newClassNames))
            {
                _classNameOffsets[className] = writer.GetPosition() - _dataOffset + 5;

                writer.Write(hash);
                writer.Write((byte)0x09);
                writer.WriteNullTerminatedString(className);
            }

            FillToAlign(writer, 0xFF, 16);

            int bufferSize = writer.GetPosition() - _dataOffset;

            UpdateHeader(bufferSize);
        }
    }
}