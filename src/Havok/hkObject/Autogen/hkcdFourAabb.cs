using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(96)]
    public class hkcdFourAabb : hkObject
    {
        public override uint Hash => 0xad9bb6f1;

        [FieldAttr(0)] public Vector4 _lx; // TYPE_VECTOR4
        [FieldAttr(16)] public Vector4 _hx; // TYPE_VECTOR4
        [FieldAttr(32)] public Vector4 _ly; // TYPE_VECTOR4
        [FieldAttr(48)] public Vector4 _hy; // TYPE_VECTOR4
        [FieldAttr(64)] public Vector4 _lz; // TYPE_VECTOR4
        [FieldAttr(80)] public Vector4 _hz; // TYPE_VECTOR4
    }
}