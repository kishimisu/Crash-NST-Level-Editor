using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(128)]
    public class hkbMoveCharacterModifier : hkbModifier
    {
        public override uint Hash => 0x8a40ba00;

        [FieldAttr(96)] public Vector4 _offsetPerSecondMS; // TYPE_VECTOR4
        [FieldAttr(112)] public float _timeSinceLastModify; // TYPE_REAL, flags: SERIALIZE_IGNORED
    }
}