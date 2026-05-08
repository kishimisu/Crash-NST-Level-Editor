namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_EndRaceRandomCamera_UnsafeAreaData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Camera_0x20 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Camera_0x28 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Camera_0x30 = new();
    }
}
