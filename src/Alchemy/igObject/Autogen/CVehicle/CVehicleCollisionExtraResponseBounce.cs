namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CVehicleCollisionExtraResponseBounce : CVehicleCollisionExtraResponseReorientBase
    {
        [FieldAttr(64)] public float _bounciness = 0.69999999f;
        [FieldAttr(68)] public float _minSpeedRatioToReflection = 0.1f;
        [FieldAttr(72)] public float _minBounceReflectionSpeedRatio = 0.1f;
        [FieldAttr(76)] public float _maxBounceReflectionSpeedRatio = 0.5f;
    }
}
