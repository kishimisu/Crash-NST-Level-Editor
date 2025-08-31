namespace Alchemy
{
    // VSC object extracted from: common_Objective_Count_Manager.igz

    [ObjectAttr(88, metaType: typeof(CVscComponentData))]
    public class common_Objective_Count_ManagerData : CVscComponentData
    {
        [FieldAttr(40)] public string? _String = null;
        [FieldAttr(48)] public float _Float;
        [FieldAttr(52)] public bool _Bool;
        [FieldAttr(56)] public igHandleMetaField _Gui_Project = new();
        [FieldAttr(64)] public igHandleMetaField _Game_Int_Variable_0x40 = new();
        [FieldAttr(72)] public igHandleMetaField _Game_Int_Variable_0x48 = new();
        [FieldAttr(80)] public igHandleMetaField _PlayerDied = new();
    }
}
