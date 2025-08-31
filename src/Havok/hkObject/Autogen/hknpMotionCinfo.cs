using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(112)]
    public class hknpMotionCinfo : hkObject
    {
        public override uint Hash => 0x693d1b16;

        [FieldAttr(0)] public u16 _motionPropertiesId; // TYPE_UINT16
        [FieldAttr(2)] public bool _enableDeactivation; // TYPE_BOOL
        [FieldAttr(4)] public float _inverseMass; // TYPE_REAL
        [FieldAttr(8)] public float _massFactor; // TYPE_REAL
        [FieldAttr(12)] public float _maxLinearAccelerationDistancePerStep; // TYPE_REAL
        [FieldAttr(16)] public float _maxRotationToPreventTunneling; // TYPE_REAL
        [FieldAttr(32)] public Vector4 _inverseInertiaLocal; // TYPE_VECTOR4
        [FieldAttr(48)] public Vector4 _centerOfMassWorld; // TYPE_VECTOR4
        [FieldAttr(64)] public Quaternion _orientation; // TYPE_QUATERNION
        [FieldAttr(80)] public Vector4 _linearVelocity; // TYPE_VECTOR4
        [FieldAttr(96)] public Vector4 _angularVelocity; // TYPE_VECTOR4
    }
}