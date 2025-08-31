namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igGuiActionSetFocus : igGuiAction
    {
        [FieldAttr(48, false)] public igGuiPlaceable? _placeable;
        [FieldAttr(56)] public igGuiInput.EController _control;
    }
}
