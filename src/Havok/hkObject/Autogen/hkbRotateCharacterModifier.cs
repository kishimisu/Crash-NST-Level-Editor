using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(128)]
    public class hkbRotateCharacterModifier : hkbModifier
    {
        public override uint Hash => 0x8127360f;

        [FieldAttr(88)] public float _degreesPerSecond; // TYPE_REAL
        [FieldAttr(92)] public float _speedMultiplier; // TYPE_REAL
        [FieldAttr(96)] public Vector4 _axisOfRotation; // TYPE_VECTOR4
        [FieldAttr(112)] public float _angle; // TYPE_REAL, flags: SERIALIZE_IGNORED
    }
}