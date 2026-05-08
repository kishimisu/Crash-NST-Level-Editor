namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class ChapterCinematic_RootBehavior : igGuiVscBehavior
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _IntroOutroAnimation = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _ChapterNamePlaceable = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _GuiPlaceableVariable_variable = new();
        [FieldAttr(nst: 64, ctr: 56)] public string? _ChapterName = null;
        [FieldAttr(nst: 72, ctr: 64)] public string? _CheckpointName = null;
    }
}
