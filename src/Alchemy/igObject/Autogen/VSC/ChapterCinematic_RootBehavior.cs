namespace Alchemy
{
    // VSC object extracted from: ChapterCinematic_RootBehavior_c.igz

    [ObjectAttr(80, metaType: typeof(igGuiVscBehavior))]
    public class ChapterCinematic_RootBehavior : igGuiVscBehavior
    {
        [FieldAttr(40)] public igHandleMetaField _IntroOutroAnimation = new();
        [FieldAttr(48)] public igHandleMetaField _ChapterNamePlaceable = new();
        [FieldAttr(56)] public igHandleMetaField _GuiPlaceableVariable_variable = new();
        [FieldAttr(64)] public string? _ChapterName = null;
        [FieldAttr(72)] public string? _CheckpointName = null;
    }
}
