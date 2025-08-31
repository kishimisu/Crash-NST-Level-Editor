namespace Alchemy
{
    // VSC object extracted from: common_TimeTrial_Freeze_Clock.igz

    [ObjectAttr(80, metaType: typeof(igGuiVscBehavior))]
    public class common_TimeTrial_Freeze_Clock : igGuiVscBehavior
    {
        [FieldAttr(40)] public bool _Bool;
        [FieldAttr(48)] public igHandleMetaField _Gui_Animation_Tag_0x30 = new();
        [FieldAttr(56)] public igHandleMetaField _Gui_Animation_Tag_0x38 = new();
        [FieldAttr(64)] public igHandleMetaField _Sound_0x40 = new();
        [FieldAttr(72)] public igHandleMetaField _Sound_0x48 = new();
    }
}
