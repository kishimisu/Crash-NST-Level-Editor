namespace Alchemy
{
    [ObjectAttr(192, 8)]
    public class CGuiBehaviorButtonRemappingOption : CGuiBehavior
    {
        [FieldAttr(144, false)] public igGuiPlaceable? _textPlaceableLabel;
        [FieldAttr(152, false)] public igGuiPlaceable? _textPlaceablePrimaryMapping;
        [FieldAttr(160, false)] public igGuiPlaceable? _textPlaceableSecondaryMapping;
        [FieldAttr(168, false)] public igGuiAnimationTag? _mappingSelectAnimation;
        [FieldAttr(176, false)] public igGuiAnimationTag? _mappingDeselectAnimation;
        [FieldAttr(184)] public EXBUTTON _xButtonMapping = EXBUTTON.MAX;
        [FieldAttr(188)] public int _activeMappingIndex;
    }
}
