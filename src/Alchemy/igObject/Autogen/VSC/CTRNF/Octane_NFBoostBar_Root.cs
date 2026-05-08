namespace Alchemy
{
    [ObjectAttr(nst: 136, ctr: 128, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_NFBoostBar_Root : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public EOctaneBoostBarType _E_Octane_Boost_Bar_Type;
        [FieldAttr(nst: 52, ctr: 44)] public float _Float_0x2c;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Gui_Animation_Tag_0x30 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Gui_Animation_Tag_0x38 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igObject? _InternalStore__timer = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Gui_Placeable_0x48 = new();
        [FieldAttr(nst: 88, ctr: 80)] public float _Float_0x50;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Gui_Placeable_0x58 = new();
        [FieldAttr(nst: 104, ctr: 96)] public int _Int;
        [FieldAttr(nst: 108, ctr: 100)] public float _Float_0x64;
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 128, ctr: 120)] public bool _Bool;
    }
}
