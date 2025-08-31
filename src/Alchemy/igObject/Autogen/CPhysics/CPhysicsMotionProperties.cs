namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CPhysicsMotionProperties : igNamedObject
    {
        public enum EStabilizationType : uint
        {
            eST_Off = 0,
            eST_Low = 1,
            eST_Medium = 2,
            eST_High = 3,
            eST_Aggressive = 4,
        }

        [FieldAttr(24)] public float _gravityFactor = 1.0f;
        [FieldAttr(28)] public float _timeFactor = 1.0f;
        [FieldAttr(32)] public float _maxLinearSpeed = 200.0f;
        [FieldAttr(36)] public float _maxAngularSpeed = 100.0f;
        [FieldAttr(40)] public float _linearDamping;
        [FieldAttr(44)] public float _angularDamping;
        [FieldAttr(48)] public EStabilizationType _stabilizationType;
        [FieldAttr(52)] public bool _isMutable;
        [FieldAttr(53)] public bool _finalizeCalled;
        [FieldAttr(54)] public u32 /* igStructMetaField */ _dynamicMotionPropertiesId;
        [FieldAttr(56)] public u32 /* igStructMetaField */ _keyframedMotionPropertiesId;
    }
}
