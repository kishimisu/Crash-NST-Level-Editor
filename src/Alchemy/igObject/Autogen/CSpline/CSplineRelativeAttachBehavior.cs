namespace Alchemy
{
    [ObjectAttr(96, 16)]
    public class CSplineRelativeAttachBehavior : CSplineAttachBehavior
    {
        [FieldAttr(32)] public igMatrix44fMetaField _startingTransform = new();
    }
}
