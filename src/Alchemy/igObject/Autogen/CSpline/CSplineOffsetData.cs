namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class CSplineOffsetData : igObject
    {
        [FieldAttr(16)] public float _minTargetOffset = 400.0f;
        [FieldAttr(20)] public float _maxTargetOffset = 400.0f;
        [FieldAttr(24)] public float _maxCameraOffset = 400.0f;
        [FieldAttr(28)] public float _damping = 0.15f;
        [FieldAttr(32)] public igVec3fMetaField _relativeDirection = new();
    }
}
