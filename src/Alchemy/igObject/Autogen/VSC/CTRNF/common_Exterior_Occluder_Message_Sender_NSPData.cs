namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 40, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Exterior_Occluder_Message_Sender_NSPData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity = new();
    }
}
