using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(48)]
    public class hkbProjectData : hkReferencedObject
    {
        public override uint Hash => 0x363c1159;

        [FieldAttr(16)] public Vector4 _worldUpWS; // TYPE_VECTOR4
        [FieldAttr(32)] public hkbProjectStringData _stringData; // TYPE_POINTER, ctype: hkbProjectStringData, subtype: TYPE_STRUCT
        [FieldAttr(40)] public EEventMode _defaultEventMode; // TYPE_ENUM, etype: EventMode, subtype: TYPE_INT8
    }
}