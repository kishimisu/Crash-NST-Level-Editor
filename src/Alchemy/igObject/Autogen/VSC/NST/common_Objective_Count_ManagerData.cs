namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Objective_Count_ManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _String = null;
        [FieldAttr(nst: 48, ctr: 40)] public float _Float;
        [FieldAttr(nst: 52, ctr: 44)] public bool _Bool;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Gui_Project = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Game_Int_Variable_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Game_Int_Variable_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _PlayerDied = new();
    }
}
