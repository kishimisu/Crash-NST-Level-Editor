namespace Alchemy
{
    [ObjectAttr(8)]
    public class igRawRefMetaField : igRefMetaField
    {
        [FieldAttr(0)] public u64 _address = 0;

        public override void Parse(IgzReader reader) => _address = reader.ReadUInt64();

        public override void Write(IgzWriter writer)
        {
            if (_address == 0) return;
            
            int offset = writer.GetPosition();
            writer.AddROFS(offset);
            writer.Write(_address, offset);
        }
    }
}