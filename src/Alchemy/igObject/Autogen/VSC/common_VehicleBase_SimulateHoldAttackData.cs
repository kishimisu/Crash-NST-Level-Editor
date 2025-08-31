namespace Alchemy
{
    // VSC object extracted from: common_VehicleBase_SimulateHoldAttack_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class common_VehicleBase_SimulateHoldAttackData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Activators = new();
        [FieldAttr(48)] public float _ShortHold;
        [FieldAttr(52)] public float _LongHold;
        [FieldAttr(56)] public string? _FireOutEvent = null;
    }
}
