using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(64)]
    public class hknpStaticCompoundShapeData : hkReferencedObject
    {
        public override uint Hash => 0x4fd87fd9;

        [FieldAttr(16)] public hkMemory<hkcdStaticTreeCodec3Axis6> _nodes; // TYPE_ARRAY, ctype: hkcdStaticTreeCodec3Axis6, subtype: TYPE_STRUCT
        [FieldAttr(32)] public Vector4 _min; // TYPE_VECTOR4, (Inlined from type: hkAabb)
        [FieldAttr(48)] public Vector4 _max; // TYPE_VECTOR4, (Inlined from type: hkAabb)
    }
}