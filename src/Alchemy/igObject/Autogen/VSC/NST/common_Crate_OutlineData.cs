namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Crate_OutlineData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _UsedEntityToSpawn = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _ReplacementEntity = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _SwapSound = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _SwapVFX = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Entity_Tag_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Entity_Tag_0x50 = new();
    }
}
