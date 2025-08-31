namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CAnimationTimelinesComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public string? _animationEventsFile = null;
    }
}
