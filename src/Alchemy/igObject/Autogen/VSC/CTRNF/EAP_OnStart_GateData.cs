namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class EAP_OnStart_GateData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 48, ctr: 40)] public igVec3fMetaField _Vec_3F = new();
    }
}
