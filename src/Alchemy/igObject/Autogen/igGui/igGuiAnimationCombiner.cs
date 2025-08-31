namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igGuiAnimationCombiner : igObject
    {
        [FieldAttr(16)] public igGuiEventAnimationEnd? _animationEndEvent;
        [FieldAttr(24)] public igVectorMetaField<igGuiAnimationPlayState> _states = new();
        [FieldAttr(48)] public bool _isUpdating;
    }
}
