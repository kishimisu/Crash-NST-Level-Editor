namespace Alchemy
{
    [ObjectAttr(8)]
    public class igHandleMetaField : igRefMetaField
    {
        [FieldAttr(0)] public u64 _handle;

        private NamedReference? _reference;

        public void SetReference(NamedReference? reference) => _reference = reference;
        public NamedReference? GetReference() => _reference;
        public string? GetNamespaceName() => _reference?.namespaceName;
        public string? GetReferencedObjectName() => _reference?.objectName;
        public bool HasData() => _reference != null;

        public override List<NamedReference> GetHandles() => _reference != null ? [ _reference ] : [];

        public override void Parse(IgzReader reader)
        {
            bool inRHND = reader.IsFixupActive("RHND", (int)reader.BaseStream.Position);

            if (!inRHND) return;

            _handle = reader.ReadUInt64();

            bool isHandle = (_handle & 0x80000000) != 0;
            int handleIndex = (int)_handle & 0x3FFFFFFF;

            _reference = reader.GetObjectReference(handleIndex, isHandle);
        }

        public override void Write(IgzWriter writer)
        {
            if (_reference == null || _reference.IsNullOrEmpty())
            {
                _handle = 0;
                return;
            }

            int offset = writer.GetPosition();
            writer.AddRHND(offset);

            if (!_reference.isEXID)
            {
                _handle = (u64)(writer.AddHandleReference(_reference) | 0x80000000);
            }
            else
            {
                _handle = (u64)writer.AddEXID(_reference);
            }

            writer.Write(_handle, offset);
        }
    }
}
