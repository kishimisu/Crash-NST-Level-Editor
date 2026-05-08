namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_C2_Hub_BossPortalData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public int _Int;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity_Handle_List = new();
        [FieldAttr(nst: 56, ctr: 48)] public bool _Bool;
    }
}
