namespace Alchemy
{
    [ObjectAttr(296, 8)]
    public class CGuiBehaviorCrashSaveSlotOption : CGuiBehaviorSaveSlotOption
    {
        [FieldAttr(184, false)] public igGuiAnimationTag? _emptyAnimation;
        [FieldAttr(192, false)] public igGuiPlaceable? _percentPlaceable;
        [FieldAttr(200, false)] public igGuiPlaceable? _levelNamePlaceable;
        [FieldAttr(208, false)] public igGuiPlaceable? _levelImagePlaceable;
        [FieldAttr(216, false)] public igGuiPlaceable? _lifeCountPlaceable;
        [FieldAttr(224, false)] public igGuiPlaceable? _gemCountPlaceable;
        [FieldAttr(232, false)] public igGuiPlaceable? _keyCountPlaceable;
        [FieldAttr(240, false)] public igGuiPlaceable? _crystalCountPlaceable;
        [FieldAttr(248, false)] public igGuiPlaceable? _relicCountPlaceable;
        [FieldAttr(256, false)] public igGuiPlaceable? _invalidSaveTextPlaceable;
        [FieldAttr(264)] public string? _emptySaveText = "EMPTY";
        [FieldAttr(272)] public string? _corruptSaveText = "CORRUPT SAVE";
        [FieldAttr(280)] public string? _invalidOwnerSaveText = "ACCESS DENIED";
        [FieldAttr(288)] public igHandleMetaField _defaultLevelImage = new();
    }
}
