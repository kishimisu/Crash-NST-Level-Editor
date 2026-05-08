namespace Alchemy
{
    [ObjectAttr(nst: 160, ctr: 152, align: 4, metaType: typeof(CVscComponentData))]
    public class HavokBehavior_Enemy_Death : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _LaunchDeathOnly;
        [FieldAttr(nst: 48, ctr: 40)] public string? _DeathDefault = null;
        [FieldAttr(nst: 56, ctr: 48)] public string? _DeathJump = null;
        [FieldAttr(nst: 64, ctr: 56)] public string? _DeathSpin = null;
        [FieldAttr(nst: 72, ctr: 64)] public Standard_Enemy_Death_c_Standard_Enemy_DeathData.ENewEnum3_id_4cdoc9cv _NewEnum3_id_4cdoc9cv;
        [FieldAttr(nst: 76, ctr: 68)] public bool _Bool_0x4c;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Havok_Linear_Cast_Query_Parameters = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(nst: 96, ctr: 88)] public string? _Standard_Enemy_DeathDatas = null;
        [FieldAttr(nst: 104, ctr: 96)] public bool _Bool_0x68;
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(nst: 136, ctr: 128)] public bool _Bool_0x88;
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Query_Filter_0x90 = new();
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _Query_Filter_0x98 = new();
    }
}
