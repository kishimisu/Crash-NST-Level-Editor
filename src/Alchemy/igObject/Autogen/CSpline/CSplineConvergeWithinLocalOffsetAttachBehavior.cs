namespace Alchemy
{
    [ObjectAttr(72, 4)]
    public class CSplineConvergeWithinLocalOffsetAttachBehavior : CSplineAttachBehavior
    {
        [FieldAttr(24)] public float _convergeRatio = 0.3f;
        [FieldAttr(28)] public bool _convergeX = true;
        [FieldAttr(32)] public float _convergeOffsetX = 100.0f;
        [FieldAttr(36)] public bool _convergeY = true;
        [FieldAttr(40)] public float _convergeOffsetY = 100.0f;
        [FieldAttr(44)] public bool _convergeZ = true;
        [FieldAttr(48)] public float _convergeOffsetZ = 100.0f;
        [FieldAttr(52)] public bool _convergeCompleted;
        [FieldAttr(56)] public igVec3fMetaField _startAxesOffset = new();
    }
}
