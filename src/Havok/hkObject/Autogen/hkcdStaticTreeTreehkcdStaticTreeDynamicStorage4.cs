using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(48)]
    public class hkcdStaticTreeTreehkcdStaticTreeDynamicStorage4 : hkcdStaticTreeDynamicStorage4
    {
        public override uint Hash => 0xe603f6aa;

        [FieldAttr(16)] public Vector4 _min; // TYPE_VECTOR4, (Inlined from type: hkAabb)
        [FieldAttr(32)] public Vector4 _max; // TYPE_VECTOR4, (Inlined from type: hkAabb)
    }
}