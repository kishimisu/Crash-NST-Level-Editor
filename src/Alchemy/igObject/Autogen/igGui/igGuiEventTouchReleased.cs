namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igGuiEventTouchReleased : igGuiEventTouch
    {
        [FieldAttr(40, false)] public igGuiPlaceable? _releasedPlaceable;
    }
}
