namespace Alchemy
{
    [ObjectAttr(16, 4)]
    public class igObject : igObjectBase
    {
        [FieldAttr(0)] public u64 __objectType;
        [FieldAttr(8)] public u64 __referenceCount;

        public string? ObjectName { get; set; }

        public NamedReference? Reference { get; set; } // External object (RNEX/REXT)
        public MemoryPool MemoryPool { get; set; } = MemoryPool.Default;

        /// <summary>
        /// Check if this object is an external reference without actual data
        /// </summary>
        /// <returns>False if it's a regular objects (ROFS), True if it contains a NamedReference (RNEX/REXT)</returns>
        public bool IsExternal() => Reference != null;

        /// <summary>
        /// Create a NamedReference from this object with the given namespace
        /// </summary>
        public NamedReference ToNamedReference(string namespaceName, bool isEXID = false) => new NamedReference(namespaceName, ObjectName ?? "", isEXID);

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

            writer.SetMemory(MemoryPool);

            // Compute aligned object offset
            int offset = writer.GetSize();
            offset += (alignment - (offset % alignment)) % alignment;

            // Reserve space for this object as it can start writing other objects before finishing writing this one
            writer.ReserveBytes(offset + size);
            writer.SetObjectWritten(this, offset);

            // Update igRawRefMetaField address for dynamic MetaObjects
            if (attribs.GetBaseMetaObjectType() != null)
            {
                CachedFieldAttr _dynamicFieldMemory = attribs.GetField("_dynamicFieldMemory")!;
                CachedFieldAttr _meta = attribs.GetField("_meta")!;

                igRawRefMetaField rawRef = (igRawRefMetaField)_dynamicFieldMemory.GetValue(this)!;
                if (rawRef._address != 0)
                {
                    rawRef._address = (uint)(offset + AttributeUtils.GetAttributes(GetType().BaseType!).GetSize());
                }
            }

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
            if (Reference != null)
            {
                if (Reference.isEXID)
                {
                    value = (u64)writer.AddEXID(Reference);
                    writer.AddREXT(offset);
                }
                else
                {
                    value = (u64)writer.AddObjectReference(Reference);
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
                value = (u64)writer.EncodeOffset(objectOffset, MemoryPool);
            }

            // Write the ObjectRef's value
            writer.SetMemory(baseMemory);
            writer.Write(value, offset);
        }

        public override igObjectBase Clone(IgzFile? igz = null, IgzFile? dst = null, CloneMode mode = CloneMode.Deep, Dictionary<igObject, igObject>? clones = null)
        {
            clones ??= new Dictionary<igObject, igObject>();

            if (!mode.HasFlag(CloneMode.Deep) && clones.Count > 0) return this; // Shallow copy

            if (GetType() == typeof(igMetaObject) || GetType() == typeof(igObject)) return this; // Skip empty objects

            if (clones.ContainsKey(this)) return clones[this]; // Skip already cloned objects

            // Skip components with multiple references
            // TODO: cleanup & optimize
            if (igz != null && mode.HasFlag(CloneMode.SkipComponents) && (this is igComponentData || this is igEntityData) &&
                igz.Objects.Count(
                    e => e.GetType() != typeof(igObjectList) && e.GetChildren(igz, ChildrenSearchParams.IncludeHandles).Contains(this)
                ) > 1)
            {
                return this;
            }

            clones[this] = this; // Prevent infinite recursion

            // Clone this object
            igObject clone = (igObject)base.Clone(igz, dst, mode, clones);
            clone.MemoryPool = MemoryPool;

            clones[this] = clone;

            return clone;
        }

        public override string ToString() => $"{GetType().Name}{(ObjectName != null ? $": {ObjectName}" : "")} #{GetHashCode()}";
    }
}