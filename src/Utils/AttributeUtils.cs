using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Alchemy
{
    public static class AttributeUtils
    {
        private static Dictionary<Type, CachedObjectAttr> _fieldInfoCache = [];

        /// <summary>
        /// Get the size of an igObject
        /// </summary>
        public static int GetObjectSize(Type type) => GetAttributes(type).GetSize();
        
        /// <summary>
        /// Get the size of a field for a given type
        /// </summary>
        /// <param name="type">The field type</param>
        /// <returns>The field size in bytes</returns>
        public static int GetFieldSize(Type type)
        {
            if (type == typeof(bool))
            {
                return 1;
            }
            if (type == typeof(string))
            {
                return 8; // String pointer
            }
            if (type.IsPrimitive)
            {
                return Marshal.SizeOf(type); // Scalar
            }
            if (type.IsAssignableTo(typeof(Alchemy.igObject)) || type.IsAssignableTo(typeof(Havok.hkReferencedObject)))
            {
                return 8; // Object pointer
            }
            if (type.IsAssignableTo(typeof(Alchemy.igMetaField)) || type.IsAssignableTo(typeof(Havok.hkObject)))
            {
                return GetObjectSize(type); // Struct
            }
            if (type == typeof(System.Numerics.Vector4) || type == typeof(System.Numerics.Quaternion) ||
                type == typeof(System.Numerics.Matrix4x4) || type == typeof(Matrix3x4))
            {
                return Marshal.SizeOf(type);
            }

            throw new Exception($"Failed to get field size for type {type}");
        }

        /// <summary>
        /// Get the base MetaObject type associated to an igObject
        /// </summary>
        /// <param name="obj">The object to check</param>
        /// <returns>The base MetaObject type, or null if it's not a dynamic object</returns>
        public static Type? GetBaseMetaObjectType(Alchemy.igObject obj) => GetAttributes(obj.GetType()).GetBaseMetaObjectType();

        /// <summary>
        /// Get the attributes corresponding to an object type.
        /// Caches the results for faster access.
        /// </summary>
        /// <param name="type">The type of the object</param>
        /// <returns>The cached object attributes</returns>
        public static CachedObjectAttr GetAttributes(Type type)
        {
            if (_fieldInfoCache.TryGetValue(type, out CachedObjectAttr? objectAttr) && objectAttr != null)
            {
                return objectAttr;
            }

            return AddCachedObject(type);
        }

        /// <summary>
        /// Cache the attributes for a given object type
        /// </summary>
        private static CachedObjectAttr AddCachedObject(Type type)
        {
            List<CachedFieldAttr> fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance)
                .Select(field => new CachedFieldAttr(field))
                .ToList();

            ReorderFields(fields, type);

            _fieldInfoCache[type] = new CachedObjectAttr(type, fields);

            return _fieldInfoCache[type];
        }

        /// <summary>
        /// Reorder fields to guarantee that they're written in the correct order
        /// </summary>
        private static void ReorderFields(List<CachedFieldAttr> fields, Type type)
        {
            // Sort fields by offset
            fields.Sort((a, b) => a.GetOffset() - b.GetOffset());

            // Reorder fields for some specific types in order to match with the original dump layout.
            // Not neccessary, but guarantees that rebuilding game files will lead to the same result as the original versions.
            if (type == typeof(Alchemy.DotNetDataMetaField))
            {
                CachedFieldAttr elmRef = fields[0];
                fields.Remove(elmRef);
                fields.Insert(1, elmRef);
            }
            else if (type.IsAssignableTo(typeof(Alchemy.igMetaFieldInstance)))
            {
                CachedFieldAttr _attributes = fields.First(f => f.GetName() == "_attributes");
                CachedFieldAttr _default = fields.First(f => f.GetName() == "_default");
                int defaultIndex = fields.IndexOf(_default);
                fields.Remove(_attributes);
                fields.Insert(defaultIndex, _attributes);
            }
            else if (type.IsAssignableTo(typeof(Alchemy.igEntity)))
            {
                CachedFieldAttr data = fields.First(f => f.GetFieldType().IsAssignableTo(typeof(Alchemy.igEntityData)));
                fields.Remove(data);
                fields.Insert(0, data);

                if (type.IsAssignableTo(typeof(Alchemy.CActor)))
                {
                    CachedFieldAttr _actorInput = fields.First(f => f.GetName() == "_actorInput");
                    CachedFieldAttr _combatTargets = fields.First(f => f.GetName() == "_combatTargets")!;
                    CachedFieldAttr _collectiblesFilters = fields.First(f => f.GetName() == "_collectiblesFilters")!;
                    int actorInputIndex = fields.IndexOf(_actorInput);

                    fields.Remove(_combatTargets);
                    fields.Remove(_collectiblesFilters);
                    fields.Insert(actorInputIndex - 1, _combatTargets);
                    fields.Insert(actorInputIndex, _collectiblesFilters);
                }
            }
        }

        public static readonly Dictionary<Type, Func<BinaryReader, object>> ReadMethods = new()
        {
            [typeof(bool)]   = r => r.ReadBoolean(),
            [typeof(sbyte)]  = r => r.ReadSByte(),
            [typeof(byte)]   = r => r.ReadByte(),
            [typeof(short)]  = r => r.ReadInt16(),
            [typeof(ushort)] = r => r.ReadUInt16(),
            [typeof(int)]    = r => r.ReadInt32(),
            [typeof(uint)]   = r => r.ReadUInt32(),
            [typeof(long)]   = r => r.ReadInt64(),
            [typeof(ulong)]  = r => r.ReadUInt64(),
            [typeof(float)]  = r => r.ReadSingle(),
            [typeof(Half)]   = r => r.ReadHalf(),

            [typeof(System.Numerics.Vector4)] = r => new System.Numerics.Vector4(
                r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle()),

            [typeof(System.Numerics.Quaternion)] = r => new System.Numerics.Quaternion(
                r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle()),

            [typeof(System.Numerics.Matrix4x4)] = r => new System.Numerics.Matrix4x4(
                r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle(),
                r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle(),
                r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle(),
                r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle()),

            [typeof(Matrix3x4)] = r => new Matrix3x4(
                r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle(),
                r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle(),
                r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle())
        };

        public static readonly Dictionary<Type, Action<BinaryWriter, object>> WriteMethods = new()
        {
            [typeof(bool)]   = (w, v) => w.Write((bool)v),
            [typeof(sbyte)]  = (w, v) => w.Write((sbyte)v),
            [typeof(byte)]   = (w, v) => w.Write((byte)v),
            [typeof(short)]  = (w, v) => w.Write((short)v),
            [typeof(ushort)] = (w, v) => w.Write((ushort)v),
            [typeof(int)]    = (w, v) => w.Write((int)v),
            [typeof(uint)]   = (w, v) => w.Write((uint)v),
            [typeof(long)]   = (w, v) => w.Write((long)v),
            [typeof(ulong)]  = (w, v) => w.Write((ulong)v),
            [typeof(float)]  = (w, v) => w.Write((float)v),
            [typeof(Half)]   = (w, v) => w.Write((Half)v),

            [typeof(System.Numerics.Vector4)] = (w, v) => {
                var vec = (System.Numerics.Vector4)v;
                w.Write(vec.X); w.Write(vec.Y); w.Write(vec.Z); w.Write(vec.W);
            },
            [typeof(System.Numerics.Quaternion)] = (w, v) => {
                var q = (System.Numerics.Quaternion)v;
                w.Write(q.X); w.Write(q.Y); w.Write(q.Z); w.Write(q.W);
            },
            [typeof(System.Numerics.Matrix4x4)] = (w, v) => {
                var m = (System.Numerics.Matrix4x4)v;
                w.Write(m.M11); w.Write(m.M12); w.Write(m.M13); w.Write(m.M14);
                w.Write(m.M21); w.Write(m.M22); w.Write(m.M23); w.Write(m.M24);
                w.Write(m.M31); w.Write(m.M32); w.Write(m.M33); w.Write(m.M34);
                w.Write(m.M41); w.Write(m.M42); w.Write(m.M43); w.Write(m.M44);
            },
            [typeof(Matrix3x4)] = (w, v) => {
                var m = (Matrix3x4)v;
                w.Write(m.M11); w.Write(m.M12); w.Write(m.M13); w.Write(m.M14);
                w.Write(m.M21); w.Write(m.M22); w.Write(m.M23); w.Write(m.M24);
                w.Write(m.M31); w.Write(m.M32); w.Write(m.M33); w.Write(m.M34);
            }
        };
    }

    public struct Matrix3x4
    {
        public float M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34;

        public Matrix3x4(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34)
        {
            M11 = m11; M12 = m12; M13 = m13; M14 = m14;
            M21 = m21; M22 = m22; M23 = m23; M24 = m24;
            M31 = m31; M32 = m32; M33 = m33; M34 = m34;
        }
    }
}