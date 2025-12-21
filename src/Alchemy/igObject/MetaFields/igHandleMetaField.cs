namespace Alchemy
{
    [ObjectAttr(8)]
    public class igHandleMetaField : igRefMetaField
    {
        [FieldAttr(0)] public u64 _handle;

        public NamedReference? Reference { get; set; }

        public override List<NamedReference> GetHandles() => Reference != null ? [ Reference ] : [];

        public override void Parse(IgzReader reader)
        {
            bool inRHND = reader.IsFixupActive("RHND", (int)reader.BaseStream.Position);

            if (!inRHND) return;

            _handle = reader.ReadUInt64();

            bool isHandle = (_handle & 0x80000000) != 0;
            int handleIndex = (int)_handle & 0x3FFFFFFF;

            Reference = reader.GetObjectReference(handleIndex, isHandle).Clone();
        }

        public override void Write(IgzWriter writer)
        {
            if (Reference == null || Reference.IsNullOrEmpty())
            {
                _handle = 0;
                return;
            }

            int offset = writer.GetPosition();
            writer.AddRHND(offset);

            if (!Reference.isEXID)
            {
                _handle = (u64)(writer.AddHandleReference(Reference) | 0x80000000);
            }
            else
            {
                _handle = (u64)writer.AddEXID(Reference);
            }

            writer.Write(_handle, offset);
        }

        public override igObjectBase Clone(IgzFile? igz = null, IgzFile? dst = null, CloneMode mode = CloneMode.Shallow, Dictionary<igObject, igObject>? clones = null)
        {
            igHandleMetaField clone = (igHandleMetaField)base.Clone(igz, dst, mode, clones);

            clone.Reference = Reference?.Clone();

            return clone;
        }

        public override void CopyTo(igObjectBase target)
        {
            if (target is igHandleMetaField handleMetaField)
            {
                handleMetaField.Reference = Reference?.Clone();
            }
        }

        public override void RemoveChild(igObject child)
        {
            if (Reference != null && Reference.objectName == child.ObjectName)
            {
                Reference = null;
            }
        }
    }
}
