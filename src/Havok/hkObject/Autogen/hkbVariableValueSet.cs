using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(64)]
    public class hkbVariableValueSet : hkReferencedObject
    {
        public override uint Hash => 0xeb5f7e25;

        [FieldAttr(16)] public hkMemory<hkbVariableValue> _wordVariableValues; // TYPE_ARRAY, ctype: hkbVariableValue, subtype: TYPE_STRUCT
        [FieldAttr(32)] public hkMemory<Vector4> _quadVariableValues; // TYPE_ARRAY, subtype: TYPE_VECTOR4
        [FieldAttr(48)] public hkMemoryPtr<hkReferencedObject> _variantVariableValues; // TYPE_ARRAY, ctype: hkReferencedObject, subtype: TYPE_POINTER
    }
}