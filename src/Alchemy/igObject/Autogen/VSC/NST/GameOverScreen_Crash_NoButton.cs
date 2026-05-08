namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class GameOverScreen_Crash_NoButton : igGuiVscBehavior
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Zone_Info = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _LoadMapFadeOut = new();
    }
}
