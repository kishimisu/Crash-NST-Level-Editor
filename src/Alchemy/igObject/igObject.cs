namespace Alchemy
{
    [ObjectAttr(16, 4)]
    public class igObject : igObjectBase
    {
        [FieldAttr(0)] public u64 __objectType;
        [FieldAttr(8)] public u64 __referenceCount;

        private string? _objectName;
        private NamedReference? _reference; // External object (RNEX/REXT)

        public override string? GetObjectName() => _objectName;
        public NamedReference? GetReference() => _reference;
        public void SetObjectName(string? name) => _objectName = name;
        public void SetReference(NamedReference? reference) => _reference = reference;

        /// <summary>
        /// Check if this object is an external reference without actual data
        /// </summary>
        /// <returns>False if it's a regular objects (ROFS), True if it contains a NamedReference (RNEX/REXT)</returns>
        public bool IsExternal() => _reference != null;

        /// <summary>
        /// Create a NamedReference from this object with the given namespace
        /// </summary>
        public NamedReference ToNamedReference(string namespaceName, bool isEXID = false) => new NamedReference(namespaceName, _objectName ?? "", isEXID);

        /// <summary>
        /// Dump this object to the IGZ stream
        /// </summary>
        public override void Write(IgzWriter writer)
        {
            if (writer.IsObjectWritten(this)) 
                return;

            CachedObjectAttr attribs = AttributeUtils.GetAttributes(GetType());
            int size = attribs.GetSize();
            int alignment = attribs.GetAlignment();

            writer.SetMemory(_memoryPool);

            // Compute aligned object offset
            int offset = writer.GetSize();
            offset += (alignment - (offset % alignment)) % alignment;

            // Reserve space for this object as it can start writing other objects before finishing writing this one
            writer.ReserveBytes(offset + size);
            writer.SetObjectWritten(this, offset);

            // Dump the object fields
            writer.Seek(offset);
            base.Write(writer);
        }

        /// <summary>
        /// Write an igObjectRefMetaField pointing to this object.
        /// The object will be written to the IGZ stream if it hasn't already been written
        /// </summary>
        public void WriteAsObjectRef(IgzWriter writer, int offset)
        {
            MemoryPool baseMemory = writer.GetCurrentMemoryPool();

            u64 value = 0;

            // External object ref (RNEX/REXT)
            if (_reference != null)
            {
                if (_reference.isEXID)
                {
                    value = (u64)writer.AddEXID(_reference);
                    writer.AddREXT(offset);
                }
                else
                {
                    value = (u64)writer.AddObjectReference(_reference);
                    writer.AddRNEX(offset);
                }

                if (writer.RefCounted())
                {
                    value |= 1ul << 63;
                }
            }
            // Regular object ref
            else
            {
                // Add to ROFS fixup
                writer.AddROFS(offset);

                // Dump this object (if it hasn't already been written)
                this.Write(writer);

                // Encode the object's offset
                int objectOffset = writer.GetObjectOffset(this);
                value = (u64)writer.EncodeOffset(objectOffset, GetMemoryPool());
            }

            // Write the ObjectRef's value
            writer.SetMemory(baseMemory);
            writer.Write(value, offset);
        }

        public override igObjectBase Clone(bool deep = false)
        {
            igObject clone = (igObject)base.Clone(deep);

            if (_objectName != null) {
                clone._objectName = _objectName + "_Clone";
            }

            return clone;
        }
    }
}