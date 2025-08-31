namespace Alchemy
{
    // VSC object extracted from: common_WaterSimulationChange.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class common_WaterSimulationChangeData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Water_Simulation_Settings_0x28 = new();
        [FieldAttr(48)] public igHandleMetaField _Water_Simulation_Settings_0x30 = new();
        [FieldAttr(56)] public bool _Bool;
    }
}
