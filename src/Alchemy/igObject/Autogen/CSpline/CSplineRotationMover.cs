namespace Alchemy
{
    [ObjectAttr(128, 16)]
    public class CSplineRotationMover : igObject
    {
        [FieldAttr(16)] public EMoverBehavior _rotationType;
        [FieldAttr(20)] public float _convergeRatio;
        [FieldAttr(24)] public bool _convergeCompleted;
        [FieldAttr(32)] public igMatrix44fMetaField _transform = new();
        [FieldAttr(96)] public igQuaternionfMetaField _startOrientation = new();
        [FieldAttr(112)] public igVec3fMetaField _startAngles = new();
    }
}
