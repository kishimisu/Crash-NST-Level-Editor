namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igGuiAnimationBinding : igObject
    {
        [FieldAttr(16, false)] public igGuiPlaceable? _placeable;
        [FieldAttr(24, false)] public igGuiAnimation? _animation;
        [FieldAttr(32)] public igVectorMetaField<igGuiTrackBinding> _trackBindings = new();
    }
}
