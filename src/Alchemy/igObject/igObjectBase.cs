namespace Alchemy
{
    /// <summary>
    /// Flags for igObject.GetChildren
    /// </summary>
    [Flags]
    public enum ChildrenSearchParams
    {
        Default = 0, // Search igObjectRefMetaFields
        OnlyRefCounted = 1 << 0, // Only include objects that are ref counted
        IncludeHandles = 1 << 1, // Include igHandleMetaFields
    }
    
    /// <summary>
    /// Flags for igObject.Clone
    /// </summary>
    [Flags]
    public enum CloneMode
    {
        Shallow = 1 << 0, // Only clone the top-level object
        Deep = 1 << 1, // Clone all objects recursively
        SkipComponents = 1 << 2, // Reuse components that have multiple parents instead of cloning them
        SkipEntities = 1 << 3, // Skip cloning entities
        ShallowAndChildren = 1 << 4, // Clone the top-level object and all of its children
    }

    public class CloneProperties
    {
        public IgzFile? src = null;
        public IgzFile? dst = null;
        public CloneMode mode = CloneMode.Deep;
        public Dictionary<igObject, igObject> clones = [];
        public HashSet<igObject>? forceClone = null;

        public CloneProperties(IgzFile? src = null, IgzFile? dst = null, CloneMode mode = CloneMode.Deep, Dictionary<igObject, igObject>? clones = null, HashSet<igObject>? forceClone = null)
        {
            this.src = src;
            this.dst = dst;
            this.mode = mode;
            this.clones = clones ?? [];
            this.forceClone = forceClone;
        }
    }
    
    /// <summary>
    /// Base class for all Alchemy objects (corresponds to __internalObjectBase)
    /// </summary>
    public abstract class igObjectBase
    {
        public IReadOnlyList<CachedFieldAttr> GetFields() => AttributeUtils.GetAttributes(GetType()).GetFields();

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
            IReadOnlyList<CachedFieldAttr> fields = GetFields();
            List<igObject> children = [];

            if (searchParams.HasFlag(ChildrenSearchParams.OnlyRefCounted))
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
        public List<igObject> GetChildrenRecursive(ChildrenSearchParams searchParams = ChildrenSearchParams.Default, HashSet<igObject>? visited = null)
        {
            visited ??= new HashSet<igObject>();

            foreach (igObject child in GetChildren(searchParams))
            {
                if (visited.Add(child))
                {
                    child.GetChildrenRecursive(searchParams, visited);
                }
            }

            return visited.ToList();
        }

        /// <summary>
        /// Recursively find all children of this object, including handles
        /// </summary>
        public List<igObject> GetChildrenRecursive(IgzFile igz, ChildrenSearchParams searchParams = ChildrenSearchParams.Default, HashSet<igObject>? visited = null)
        {
            if (visited == null) visited = new HashSet<igObject>();

            List<igObject> children = [];

            foreach (igObject child in GetChildren(igz, searchParams))
            {
                if (visited.Contains(child)) continue;
                visited.Add(child);

                children.Add(child);
                children.AddRange(child.GetChildrenRecursive(igz, searchParams, visited));
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
                else if (value is igObject metaObject && metaObject.Reference != null)
                {
                    references.Add(metaObject.Reference);
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
        /// Remove all references to a child object (igObject/igHandleMetaField)
        /// </summary>
        public virtual void RemoveChild(igObject child)
        {
            foreach (CachedFieldAttr field in GetFields())
            {
                object? value = field.GetValue(this);
                if (value == null) continue;

                if (value == child)
                {
                    field.SetValue(this, null);
                }
                else if (value is igMetaField metaField)
                {
                    metaField.RemoveChild(child);
                }
            }
        }

        /// <summary>
        /// Create a clone of this object
        /// </summary>
        public virtual igObjectBase Clone(CloneProperties props)
        {            
            igObjectBase clone = (igObjectBase)MemberwiseClone();

            foreach (CachedFieldAttr field in GetFields())
            {
                object? value = field.GetValue(this);

                if (value == null) continue;
                if (value is igObjectBase obj) value = obj.Clone(props);

                field.SetValue(clone, value);
            }

            return clone;
        }

        /// <summary>
        /// Get all strings defined in this object (todo: include memories & lists)
        /// </summary>
        public List<string> GetStrings()
        {
            List<string> strings = [];

            foreach (CachedFieldAttr field in GetFields())
            {
                object? value = field.GetValue(this);
                if (value == null) continue;

                if (value is string str) strings.Add(str);
                else if (value is igObject obj && obj.Reference != null) strings.Add(obj.Reference.namespaceName);
            }

            strings.AddRange(GetHandles().Select(h => h.namespaceName));

            return strings;
        }

        /// <summary>
        /// Copy all fields from this object to another object
        /// </summary>
        public virtual void CopyTo(igObjectBase target)
        {
            HashSet<string> targetFields = target.GetFields().Select(f => f.GetName()).ToHashSet();

            foreach (CachedFieldAttr field in GetFields())
            {
                if (!targetFields.Contains(field.GetName())) continue;
                
                object? value = field.GetValue(this);
                field.SetValue(target, value);
            }
        }
    }
}