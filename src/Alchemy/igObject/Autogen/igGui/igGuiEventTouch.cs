namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igGuiEventTouch : igGuiEvent
    {
        [FieldAttr(24, false)] public igGuiPlaceable? _placeable;
        [FieldAttr(32)] public igGuiInput.EController _control;
        [FieldAttr(36)] public igGuiInput.ESignal _signal;
    }
}
