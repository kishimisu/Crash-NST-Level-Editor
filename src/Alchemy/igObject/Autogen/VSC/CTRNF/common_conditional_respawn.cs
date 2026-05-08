namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 4, metaType: typeof(CVscComponentData))]
    public class common_conditional_respawn : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Player_Start_Entity_Handle_List = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity = new();
    }
}
