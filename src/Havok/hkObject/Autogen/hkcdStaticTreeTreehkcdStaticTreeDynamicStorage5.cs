using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(48)]
    public class hkcdStaticTreeTreehkcdStaticTreeDynamicStorage5 : hkcdStaticTreeDynamicStorage5
    {
        public override uint Hash => 0x1cfe2fb6;

        [FieldAttr(16)] public Vector4 _min; // TYPE_VECTOR4, (Inlined from type: hkAabb)
        [FieldAttr(32)] public Vector4 _max; // TYPE_VECTOR4, (Inlined from type: hkAabb)
    }
}