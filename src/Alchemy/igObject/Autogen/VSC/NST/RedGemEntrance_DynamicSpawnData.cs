namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class RedGemEntrance_DynamicSpawnData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity_0x38 = new();
    }
}
