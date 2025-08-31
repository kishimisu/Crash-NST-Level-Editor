namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class CSplineLinearConvergeAttachBehavior : CSplineAttachBehavior
    {
        [FieldAttr(24)] public float _convergeRatio = 0.3f;
        [FieldAttr(28)] public bool _convergeX = true;
        [FieldAttr(29)] public bool _convergeY = true;
        [FieldAttr(30)] public bool _convergeZ = true;
        [FieldAttr(31)] public bool _convergeFromWorldPosition = true;
        [FieldAttr(32)] public bool _convergeCompleted;
        [FieldAttr(36)] public igVec3fMetaField _startPositionOrOffset = new();
    }
}
