using Alchemy;
using Havok;
using ImGuiNET;

namespace NST
{
    /// <summary>
    /// Provides Type extensions for rendering object and field types
    /// </summary>
    public static class TypeExtensions
    {
        const uint COL_INTEGER = 0xff91ff95;
        const uint COL_BITFIELD = 0xff6bff70;
        const uint COL_OBJECT_REF = 0xffff7f76;
        const uint COL_MEMORY_REF = 0xffff5f56;
        const uint COL_HANDLE = 0xffff90a4;
        const uint COL_STRING = 0xffff90f4;
        const uint COL_VECTOR = 0xff29a0f0;
        const uint COL_BOOL = 0xfff24a9e;
        const uint COL_FLOAT = 0xfff0ff70;
        const uint COL_ENUM = 0xff33ffda;
        const uint COL_METAFIELD = 0xffa3fffd;

        static readonly Dictionary<Type, uint> TypeColors = new Dictionary<Type, uint>() 
        {
            { typeof(bool), COL_BOOL },
            { typeof(string), COL_STRING },
            { typeof(float), COL_FLOAT },
            { typeof(Half), COL_FLOAT },
            { typeof(i8), COL_INTEGER },
            { typeof(u8), COL_INTEGER },
            { typeof(i16), COL_INTEGER },
            { typeof(u16), COL_INTEGER },
            { typeof(i32), COL_INTEGER },
            { typeof(u32), COL_INTEGER },
            { typeof(i64), COL_INTEGER },
            { typeof(u64), COL_INTEGER },
            { typeof(Matrix3x4), COL_VECTOR },
            { typeof(System.Numerics.Vector4), COL_VECTOR },
            { typeof(System.Numerics.Quaternion), COL_VECTOR },
            { typeof(System.Numerics.Matrix4x4), COL_VECTOR },
            { typeof(Alchemy.igNameMetaField), COL_STRING },
            { typeof(Alchemy.ChunkFileInfoMetaField), COL_STRING },
            { typeof(Alchemy.igHandleMetaField), COL_HANDLE },
            { typeof(Alchemy.igRawRefMetaField), COL_MEMORY_REF },
            { typeof(Alchemy.igVec2fMetaField), COL_VECTOR },
            { typeof(Alchemy.igVec3fMetaField), COL_VECTOR },
            { typeof(Alchemy.igVec4fMetaField), COL_VECTOR },
            { typeof(Alchemy.igQuaternionfMetaField), COL_VECTOR },
            { typeof(Alchemy.igMatrix44fMetaField), COL_VECTOR },
        };
        
        /// <summary>
        /// Gets the display name for a given type.
        /// Prettifies generic types
        /// </summary>
        public static string GetDisplayName(this Type type)
        {
            if (type.IsGenericType)
            {
                string outerType = type.GetGenericTypeDefinition().Name[..^2];
                string innerType = type.GetGenericArguments()[0].GetDisplayName();

                if (type.GetGenericTypeDefinition() == typeof(Alchemy.igVectorMetaField<>))
                {
                    return $"igVector<{innerType}>";
                }

                return $"{outerType}<{innerType}>";
            }

            return type.Name;
        }

        /// <summary>
        /// Gets the render color for a field type
        /// </summary>
        public static uint GetRenderColor(this Type type)
        {
            if (type.IsGenericType)
            {
                Type genericType = type.GetGenericTypeDefinition();
                if (genericType == typeof(Alchemy.igMemoryRef<>) ||
                    genericType == typeof(Alchemy.igVectorMetaField<>) ||
                    genericType.IsAssignableTo(typeof(Havok.hkMemoryBase)))
                {
                    return COL_MEMORY_REF;
                }
            }
            if (type.IsAssignableTo(typeof(igObject)) || type.IsAssignableTo(typeof(hkObject)))
            {
                return COL_OBJECT_REF;
            }
            if (type.IsAssignableTo(typeof(igBitFieldMetaField)))
            {
                return COL_BITFIELD;    
            }
            if (TypeColors.TryGetValue(type, out uint color))
            {
                return color;
            }
            if (type.IsAssignableTo(typeof(igMetaField)))
            {
                return COL_METAFIELD;
            }
            if (type.IsArray && type.GetElementType() != null)
            {
                return type.GetElementType()!.GetRenderColor();
            }
            if (type.IsEnum)
            {
                return COL_ENUM;
            }

            return ImGui.GetColorU32(ImGuiCol.Text);
        }

        /// <summary>
        /// Compute a unique render color for an object type
        /// </summary>
        public static uint GetUniqueColor(this Type type)
        {
            string name = type.Name;
            uint hash = NamespaceUtils.ComputeHash(name);
            Random random = new Random((int)hash);
            int r = random.Next(100, 255);
            int g = random.Next(100, 255);
            int b = random.Next(100, 255);
            return 0xff000000 | (uint)((b << 16) | (g << 8) | r);
        }
    }
}