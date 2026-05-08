namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 4, metaType: typeof(CVscComponentData))]
    public class BossPinstripe_StageHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(nst: 48, ctr: 40)] public int _Int;
    }
}
