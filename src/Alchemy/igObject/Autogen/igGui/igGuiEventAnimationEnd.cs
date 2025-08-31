namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igGuiEventAnimationEnd : igGuiEventAnimation
    {
        [FieldAttr(32, false)] public igGuiPlaceable? _placeable;
        [FieldAttr(40, false)] public igGuiPlaceable? _signalObject;
    }
}
