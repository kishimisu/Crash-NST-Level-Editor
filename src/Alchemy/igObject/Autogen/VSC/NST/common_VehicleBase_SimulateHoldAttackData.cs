namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_VehicleBase_SimulateHoldAttackData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Activators = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _ShortHold;
        [FieldAttr(nst: 52, ctr: 44)] public float _LongHold;
        [FieldAttr(nst: 56, ctr: 48)] public string? _FireOutEvent = null;
    }
}
