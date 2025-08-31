namespace Alchemy
{
    // VSC object extracted from: common_AirVehicleState.igz

    [ObjectAttr(104, metaType: typeof(CVscComponentData))]
    public class common_AirVehicleStateData : CVscComponentData
    {
        [FieldAttr(40)] public string? _String = null;
        [FieldAttr(48)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(56)] public igHandleMetaField _Total = new();
        [FieldAttr(64)] public igHandleMetaField _Count = new();
        [FieldAttr(72)] public igHandleMetaField _Camera_Base = new();
        [FieldAttr(80)] public igHandleMetaField _Entity_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(96)] public igHandleMetaField _Entity_0x60 = new();
    }
}
