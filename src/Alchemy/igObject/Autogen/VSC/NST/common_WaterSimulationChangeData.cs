namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_WaterSimulationChangeData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Water_Simulation_Settings_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Water_Simulation_Settings_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public bool _Bool;
    }
}
