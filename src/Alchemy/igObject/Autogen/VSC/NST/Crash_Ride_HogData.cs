namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class Crash_Ride_HogData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _HogRiderBolt = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _MinDeathVelocity;
        [FieldAttr(nst: 52, ctr: 44)] public float _AmountToAdd;
        [FieldAttr(nst: 56, ctr: 48)] public string? _RideLCRBlendWeight = null;
        [FieldAttr(nst: 64, ctr: 56)] public string? _RideLandEvent = null;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Behavior_State_Group = new();
        [FieldAttr(nst: 80, ctr: 72)] public float _MaxDeathVelocity;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(nst: 96, ctr: 88)] public float _Float;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Zone_Info_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Zone_Info_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Zone_Info_0x78 = new();
    }
}
