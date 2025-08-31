namespace Alchemy
{
    // VSC object extracted from: HavokBehavior_Enemy_Death.igz

    [ObjectAttr(160, metaType: typeof(CVscComponentData))]
    public class HavokBehavior_Enemy_Death_Standard_Enemy_DeathData : CVscComponentData
    {
        [FieldAttr(40)] public bool _LaunchDeathOnly;
        [FieldAttr(48)] public string? _DeathDefault = null;
        [FieldAttr(56)] public string? _DeathJump = null;
        [FieldAttr(64)] public string? _DeathSpin = null;
        [FieldAttr(72)] public Standard_Enemy_Death_c_Standard_Enemy_DeathData.ENewEnum3_id_4cdoc9cv _NewEnum3_id_4cdoc9cv;
        [FieldAttr(76)] public bool _Bool_0x4c;
        [FieldAttr(80)] public igHandleMetaField _Havok_Linear_Cast_Query_Parameters = new();
        [FieldAttr(88)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(96)] public string? _Standard_Enemy_DeathDatas = null;
        [FieldAttr(104)] public bool _Bool_0x68;
        [FieldAttr(112)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(120)] public igHandleMetaField _Entity = new();
        [FieldAttr(128)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(136)] public bool _Bool_0x88;
        [FieldAttr(144)] public igHandleMetaField _Query_Filter_0x90 = new();
        [FieldAttr(152)] public igHandleMetaField _Query_Filter_0x98 = new();
    }
}
