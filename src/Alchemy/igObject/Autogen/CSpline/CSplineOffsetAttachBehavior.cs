namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CSplineOffsetAttachBehavior : CSplineAttachBehavior
    {
        [FieldAttr(24)] public igVec3fMetaField _positionOffset = new();
    }
}
