namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Crate_Switch_ReusableData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _ChangeDelay;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _OulinedCrates = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _igEntity_List = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Sound = new();
    }
}
