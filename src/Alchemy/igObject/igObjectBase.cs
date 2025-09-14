namespace Alchemy
{
    /// <summary>
    /// Search flags for GetChildren
    /// </summary>
    [Flags]
    public enum ChildrenSearchParams
    {
        Default = 0, // Search igObjectRefMetaFields
        OnlyRefCounted = 1, // Only include objects that are ref counted
        IncludeHandles = 2 // Include igHandleMetaFields
    }
    
    /// <summary>
    /// Base class for all Alchemy objects (corresponds to __internalObjectBase)
    /// </summary>
    public abstract class igObjectBase
    {
        protected MemoryPool _memoryPool = MemoryPool.Default;

        public virtual string? GetObjectName() => null;
        public MemoryPool GetMemoryPool() => _memoryPool;
        public void SetMemoryPool(MemoryPool memoryPool) => _memoryPool = memoryPool;

        protected List<CachedFieldAttr> GetFields() => AttributeUtils.GetAttributes(GetType()).GetFields();

        /// <summary>
        /// Parse each field of this igObject from an IGZ file stream
        /// </summary>
        public virtual void Parse(IgzReader reader)
        {
            int startOffset = (int)reader.BaseStream.Position;

            foreach (CachedFieldAttr field in GetFields())
            {
                int fieldOffset = startOffset + field.GetOffset();
                
                reader.Seek(fieldOffset);

                // Special case for array types
                if (field.IsArray())
                {
                    reader.ReadArray(this, field);
                    continue;
                }

                object? value = reader.ReadValue(field.GetFieldType());
                
                field.SetValue(this, value);
            }
        }

        /// <summary>
        /// Write each field of this igObject to an IGZ file stream
        /// </summary>
        public virtual void Write(IgzWriter writer)
        {
            int startOffset = writer.GetPosition();

            foreach (CachedFieldAttr field in GetFields())
            {
                int fieldOffset = startOffset + field.GetOffset();
                
                object? value = field.GetValue(this);

                writer.SetRefCounted(field.RefCounted());
                writer.Write(value, fieldOffset);
            }
        }

        /// <summary>
        /// Get all objects referenced by this object.
        /// Does not include handles.
        /// </summary>
        public virtual List<igObject> GetChildren(ChildrenSearchParams searchParams = ChildrenSearchParams.Default)
        {
            List<CachedFieldAttr> fields = GetFields();
            List<igObject> children = [];

            if ((searchParams & ChildrenSearchParams.OnlyRefCounted) != 0)
            {
                fields = fields.Where(field => field.RefCounted()).ToList();
            }

            foreach (CachedFieldAttr field in fields)
            {
                object? value = field.GetValue(this);

                children.AddRange(GetFieldChildren(value, searchParams));
            }

            return children;
        }

        /// <summary>
        /// Recursively find all children of this object
        /// </summary>
        public List<igObject> GetChildrenRecursive(ChildrenSearchParams searchParams = ChildrenSearchParams.Default)
        {
            List<igObject> children = [];

            foreach (igObject child in GetChildren(searchParams))
            {
                children.Add(child);
                children.AddRange(child.GetChildrenRecursive(searchParams));
            }

            return children;
        }

        /// <summary>
        /// Get all objects referenced by this object.
        /// Can also include objects that are referenced through handles in the same IGZ file
        /// </summary>
        /// <param name="igz">The IGZ file containing this object</param>
        public virtual List<igObject> GetChildren(IgzFile igz, ChildrenSearchParams searchParams)
        {
            List<igObject> handles = GetHandles()
                .Select(handle => igz.FindObject(handle))
                .OfType<igObject>()
                .ToList();

            return GetChildren(searchParams).Concat(handles).ToList();
        }

        /// <summary>
        /// Get all objects referenced by a field
        /// </summary>
        protected static List<igObject> GetFieldChildren(object? element, ChildrenSearchParams searchParams)
        {
            if (element == null) return [];
            
            // igObjectRefMetaField
            if (element is igObject obj)
            {
                if (!obj.IsExternal())
                {
                    return [ obj ];
                }
            }
            // Other igMetaFields
            else if (element is igMetaField metaField)
            {
                return metaField.GetChildren(searchParams);
            }
            // Arrays
            else if (element.GetType().IsArray)
            {
                Type? elementType = element.GetType().GetElementType();

                if (elementType == null || !elementType.IsSubclassOf(typeof(igObjectBase))) return [];

                Array array = (Array)element;
                List<igObject> children = [];

                for (int i = 0; i < array.Length; i++)
                {
                    object? value = array.GetValue(i);
                    children.AddRange(GetFieldChildren(value, searchParams));
                }

                return children;
            }

            return [];
        }

        /// <summary>
        /// Get all handles defined in this object
        /// </summary>
        /// <returns>List of NamedReference handles</returns>
        public virtual List<NamedReference> GetHandles()
        {
            List<NamedReference> references = [];

            foreach (CachedFieldAttr field in GetFields())
            {
                object? value = field.GetValue(this);
                if (value == null) continue;

                if (value is igMetaField metaField)
                {
                    references.AddRange(metaField.GetHandles());
                }
                else if (field.IsArray())
                {
                    Type? elementType = field.GetElementType();

                    if (elementType == null || !elementType.IsSubclassOf(typeof(igMetaField))) return [];

                    Array array = (Array)field.GetValue(this)!;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array.GetValue(i) is igMetaField metaFieldElm)
                        {
                            references.AddRange(metaFieldElm.GetHandles());
                        }
                    }
                }
            }

            return references;
        }

        /// <summary>
        /// Create a clone of this object
        /// </summary>
        /// <param name="deep">Whether to clone all child objects as well</param>
        public virtual igObjectBase Clone(string? suffix = null, bool deep = false)
        {
            igObjectBase clone = (igObjectBase)MemberwiseClone();

            foreach (CachedFieldAttr field in GetFields())
            {
                object? value = field.GetValue(this);

                if (value == null) continue;
                if (value is igMetaField metaField) value = metaField.Clone(suffix, deep);
                if (deep && value is igObjectBase igObj) value = igObj.Clone(suffix, deep);

                field.SetValue(clone, value);
            }

            clone._memoryPool = _memoryPool;

            return clone;
        }

        /// <summary>
        /// Copy all fields from this object to another
        /// </summary>
        public virtual void Copy(igObjectBase target)
        {
            foreach (CachedFieldAttr field in GetFields())
            {
                object? value = field.GetValue(this);
                field.SetValue(target, value);
            }
        }
    }
}