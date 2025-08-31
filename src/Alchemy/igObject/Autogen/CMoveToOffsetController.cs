namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CMoveToOffsetController : CBaseMovementController
    {
        [FieldAttr(56)] public igVec3fMetaField _targetOffset = new();
        [FieldAttr(68)] public EigEaseType _easeType = EigEaseType.kEaseTypeQuadratic;
        [FieldAttr(72)] public float _totalDuration;
        [FieldAttr(76)] public float _easeInDuration;
        [FieldAttr(80)] public float _easeOutDuration;
        [FieldAttr(84)] public float _currentDuration;
    }
}
