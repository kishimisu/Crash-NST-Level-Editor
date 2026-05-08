namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class L214_RoadToRuin_Log_RumbleData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Rumble_Data_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Rumble_Data_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public float _Float_0x3c;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Sound = new();
    }
}
