using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(48)]
    public class hkbFootIkControlsModifierLeg : hkObject
    {
        public override uint Hash => 0xb68b350a;

        [FieldAttr(0)] public Vector4 _groundPosition; // TYPE_VECTOR4
        [FieldAttr(16)] public hkbEventProperty _ungroundedEvent; // TYPE_STRUCT, ctype: hkbEventProperty
        [FieldAttr(32)] public float _verticalError; // TYPE_REAL
        [FieldAttr(36)] public bool _hitSomething; // TYPE_BOOL
        [FieldAttr(37)] public bool _isPlantedMS; // TYPE_BOOL
        [FieldAttr(38)] public bool _enabled; // TYPE_BOOL
    }
}