namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_Progression_Rewards_Root : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public EOctaneAdventureType _E_Octane_Adventure_Type;
        [FieldAttr(nst: 52, ctr: 44)] public bool _Bool_0x2c;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Localized_String_0x38 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Localized_String_0x40 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Localized_String_0x48 = new();
        [FieldAttr(nst: 88, ctr: 80)] public bool _Bool_0x50;
        [FieldAttr(nst: 96, ctr: 88)] public igObject? _InternalStore_prioritySetHandler = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Priority_Dsp_Override_Set = new();
        [FieldAttr(nst: 112, ctr: 104)] public bool _Bool_0x68;
    }
}
