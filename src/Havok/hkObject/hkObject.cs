using Alchemy;

namespace Havok
{
    public abstract class hkObject
    {
        public virtual uint Hash => 0x0;

        public List<CachedFieldAttr> GetFields() => AttributeUtils.GetAttributes(GetType()).GetFields();

        public hkObject Clone() => (hkObject)MemberwiseClone();
        
        public virtual void Parse(HavokFile hkx, BinaryReader reader)
        {
            int startOffset = (int)reader.BaseStream.Position;

            foreach (CachedFieldAttr field in GetFields())
            {
                int fieldOffset = startOffset + field.GetOffset();
                
                reader.Seek(fieldOffset);

                object? value = ReadValue(hkx, reader, field.GetFieldType());

                field.SetValue(this, value);
            }
        }

        public virtual void Write(HavokDataSection section, BinaryWriter writer)
        {
            int startOffset = writer.GetPosition();

            foreach (CachedFieldAttr field in GetFields())
            {
                int fieldOffset = startOffset + field.GetOffset();
                
                object? value = field.GetValue(this);

                writer.Seek(fieldOffset, SeekOrigin.Begin);

                WriteValue(section, writer, value);
            }
        }

        protected void WriteValue(HavokDataSection section, BinaryWriter writer, object? value, bool isMemoryElement = false)
        {
            if (value == null) return;

            Type type = value.GetType();

            // Scalar types
            if (AttributeUtils.WriteMethods.TryGetValue(type, out var writeMethod))
            {
                writeMethod(writer, value);
            }

            // Enums
            else if (type.IsEnum)
            {
                Type underlyingType = Enum.GetUnderlyingType(type);
                WriteValue(section, writer, Convert.ChangeType(value, underlyingType));
            }

            // String pointers
            else if (value is string str)
            {
                int pos = writer.GetPosition();
                int ptr = (int)writer.BaseStream.Length;

                // All strings are aligned to 16 bytes
                // - Except for 1st string encountered when writing hkMemory<struct> elements
                // - Except for hkMemory<string>
                if (section.AlignNextString && !isMemoryElement && ptr%16 != 0) 
                {
                    ptr += 16 - (ptr%16);
                }
                else if (ptr%2 != 0) 
                {
                    ptr++;
                }

                section.AlignNextString = true;

                section.AddLocalFixup(pos, ptr);

                writer.Seek(ptr, SeekOrigin.Begin);
                writer.WriteNullTerminatedString(str);
            }

            // Object pointers
            else if (value is hkReferencedObject || value is hkRefCountedProperties)
            {
                hkObject hkRef = (hkObject)value;
                section.AddGlobalFixup(writer.GetPosition(), hkRef);
                section.AddObjectToQueue(hkRef);
            }

            // Structs
            else if (value is hkObject hkObj)
            {
                hkObj.Write(section, writer);
            }

            else throw new Exception("Write not implemented for type " + type + " (" + value + ")");
        }

        protected static object? ReadValue(HavokFile hkx, BinaryReader reader, Type type)
        {
            // Scalar types
            if (AttributeUtils.ReadMethods.TryGetValue(type, out var readMethod))
            {
                return readMethod(reader);
            }
            
            // Enums
            if (type.IsEnum)
            {
                return Enum.ToObject(type, reader.ReadInt32());
            }

            // String pointers
            if (type == typeof(string))
            {
                int ptr = reader.ReadInt32();
                if (ptr == 0) return null;

                reader.Seek(ptr);
                return reader.ReadNullTerminatedString();
            }

            // Object pointers
            if (type.IsAssignableTo(typeof(hkReferencedObject)) || type == typeof(hkRefCountedProperties))
            {
                int ptr = reader.ReadInt32();
                if (ptr == 0x0) return null;

                return hkx.GetObject(ptr);
            }

            // Structs
            if (type.IsSubclassOf(typeof(hkObject)))
            {
                hkObject obj = CreateEmptyInstance(type);
                obj.Parse(hkx, reader);
                return obj;
            }

            throw new NotSupportedException($"Type {type} is not supported.");
        }

        public virtual List<hkObject> GetChildren()
        {
            List<hkObject> children = [];

            foreach (CachedFieldAttr field in GetFields())
            {
                object? value = field.GetValue(this);

                if (value is hkMemoryBase mem)
                {
                    children.AddRange(mem.GetChildren());
                }
                else if (value is hkObject hkObj)
                {
                    children.Add(hkObj);
                }
            }

            return children;
        }

        public static hkObject CreateEmptyInstance(string className)
        {
            Type classType = Type.GetType("Havok." + className)
                            ?? throw new Exception($"Class {className} not found.");

            return CreateEmptyInstance(classType);
        }

        public static hkObject CreateEmptyInstance(Type classType)
        {
            object obj = Activator.CreateInstance(classType)
                            ?? throw new Exception($"Failed to create instance of type {classType}.");

            return obj as hkObject 
                            ?? throw new Exception($"Class {classType} is not a subclass of hkObject.");
        }
    }
}