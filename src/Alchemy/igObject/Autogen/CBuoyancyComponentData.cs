namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CBuoyancyComponentData : CEntityComponentData
    {
        public enum EMode : uint
        {
            eM_Dynamic = 0,
            eM_Character = 1,
        }

        [FieldAttr(24)] public float _buoyancy = 1.0f;
        [FieldAttr(28)] public float _horizontalDrag = 1.0f;
        [FieldAttr(32)] public float _verticalDrag = 1.0f;
        [FieldAttr(36)] public float _restingRatio = 0.1f;
        [FieldAttr(40)] public float _enterWaterVelocityFactor = 0.8f;
        [FieldAttr(44)] public float _exitWaterVelocityFactor = 0.8f;
        [FieldAttr(48)] public float _minVelocityMagnitudeForRipple = 100.0f;
        [FieldAttr(52)] public float _minSubmergedDeltaForRipple = 0.01f;
        [FieldAttr(56)] public bool _rippleEnabled = true;
        [FieldAttr(60)] public float _rippleRadius = 5.0f;
        [FieldAttr(64)] public float _rippleIntensity = 0.5f;
        [FieldAttr(68)] public float _raycastOffsetAbove = 1000.0f;
        [FieldAttr(72)] public float _raycastOffsetBelow = 1000.0f;
        [FieldAttr(80)] public igHandleMetaField _targetWaterSurfaceMaterial = new();
        [FieldAttr(88)] public EMode _mode;
    }
}
