namespace Alchemy
{
    [ObjectAttr(nst: 136, ctr: 128, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_Racer_HUD_WrongWay : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public bool _Bool;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Gui_Animation_Tag_0x30 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Sound_0x38 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Sound_0x40 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igObject? _InternalStore__timer = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Gui_Animation_Tag_0x50 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Gui_Animation_Tag_0x58 = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Entity_0x60 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Entity_0x68 = new();
        [FieldAttr(nst: 120, ctr: 112)] public EDriverFaction _E_Driver_Faction;
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Sound_0x78 = new();
    }
}
