namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class T142_Dragon_Mines_Simulated_RippleData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float_0x20;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Water_Simulation_Settings = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x30;
    }
}
