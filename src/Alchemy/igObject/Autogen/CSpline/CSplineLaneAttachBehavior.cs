namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CSplineLaneAttachBehavior : CSplineAttachBehavior
    {
        [FieldAttr(24, false)] public CEntity? _entityOnSpline;
        [FieldAttr(32)] public float _localXPosition;
    }
}
