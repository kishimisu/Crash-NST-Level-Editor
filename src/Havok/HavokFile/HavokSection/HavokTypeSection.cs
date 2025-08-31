namespace Havok
{
    public class HavokTypeSection : HavokSection
    {
        public HavokTypeSection() : base("__types__") { }

        public void WriteTypes(BinaryWriter writer)
        {
            _dataOffset = (int)writer.BaseStream.Position;
            // Empty section
        }
    }
}