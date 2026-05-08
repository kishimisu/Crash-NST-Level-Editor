namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 4, metaType: typeof(CVscComponentData))]
    public class Crash_Cove_Flying_FishData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Sound = new();
    }
}
