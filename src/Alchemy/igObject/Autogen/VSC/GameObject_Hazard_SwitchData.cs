namespace Alchemy
{
    // VSC object extracted from: GameObject_Egypt_Hazard_Switch.igz

    [ObjectAttr(128, metaType: typeof(CVscComponentData))]
    public class GameObject_Hazard_SwitchData : CVscComponentData
    {
        [FieldAttr(40)] public bool _Bool_0x28;
        [FieldAttr(41)] public bool _Bool_0x29;
        [FieldAttr(48)] public string? _String = null;
        [FieldAttr(56)] public igHandleMetaField _Sound = new();
        [FieldAttr(64)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(72)] public bool _Bool_0x48;
        [FieldAttr(76)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(88)] public float _Float_0x58;
        [FieldAttr(96)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(104)] public float _Float_0x68;
        [FieldAttr(108)] public bool _Bool_0x6c;
        [FieldAttr(112)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
        [FieldAttr(120)] public igHandleMetaField _Fx_Material_Redirect_Table = new();
    }
}
