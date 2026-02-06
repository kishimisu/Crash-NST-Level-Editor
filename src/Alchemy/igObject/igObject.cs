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

        private static readonly HashSet<Type> _forceCloneComponents =
        [
            typeof(common_Spawner_TemplateData),
            typeof(Multiple_Spawner_Template_c),
            typeof(Animated_Multiple_Spawner_Template_Behavior),
            typeof(CSplineComponentData),
            typeof(CSplineLaneMoverComponentData),
            typeof(CMovementControllerComponentData),
            typeof(Platform_Simple_PingpongData),
            typeof(Jungle_Hazard_Ostrich_BehaviorData),
        ];

        public override igObjectBase Clone(CloneProperties props)
        {
            // (Shallow copy) Skip if not root object
            if (!props.mode.HasFlag(CloneMode.Deep) && !props.mode.HasFlag(CloneMode.ShallowAndChildren) && props.clones.Count > 0 && this is not igComponentList) return this;

            // Skip entities
            if (props.mode.HasFlag(CloneMode.SkipEntities) && this is igEntity && props.clones.Count > 0) return this;

            // Skip empty objects
            if (GetType() == typeof(igMetaObject) || GetType() == typeof(igObject)) return this;

            // Skip already cloned objects
            if (props.clones.ContainsKey(this)) return props.clones[this];

            // Skip entity data & components
            if (props.clones.Count > 0 && props.mode.HasFlag(CloneMode.SkipComponents) && (
                (this is igEntityData && props.forceClone == null) ||
                (this is igComponentData && !_forceCloneComponents.Contains(GetType()) && props.forceClone?.Contains(this) == false)
            )) {
                return this;
            }

            // (Shallow + children) switch to Shallow mode for the children
            if (props.mode.HasFlag(CloneMode.ShallowAndChildren) && props.clones.Count > 0) props.mode = CloneMode.Shallow;

            props.clones[this] = this; // Temporary assignment to prevent infinite recursion

            // Clone this object
            igObject clone = (igObject)base.Clone(props);
            clone.MemoryPool = MemoryPool;
            props.clones[this] = clone;

            return clone;
        }

        public override string ToString() => $"{GetType().Name}{(ObjectName != null ? $": {ObjectName}" : "")}{(Reference == null ? "" : $" ({Reference})")}";
    }
}