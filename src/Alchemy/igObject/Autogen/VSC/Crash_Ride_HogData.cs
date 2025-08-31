namespace Alchemy
{
    // VSC object extracted from: Crash_Ride_Hog_c.igz

    [ObjectAttr(128, metaType: typeof(CVscComponentData))]
    public class Crash_Ride_HogData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _HogRiderBolt = new();
        [FieldAttr(48)] public float _MinDeathVelocity;
        [FieldAttr(52)] public float _AmountToAdd;
        [FieldAttr(56)] public string? _RideLCRBlendWeight = null;
        [FieldAttr(64)] public string? _RideLandEvent = null;
        [FieldAttr(72)] public igHandleMetaField _Behavior_State_Group = new();
        [FieldAttr(80)] public float _MaxDeathVelocity;
        [FieldAttr(88)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(96)] public float _Float;
        [FieldAttr(104)] public igHandleMetaField _Zone_Info_0x68 = new();
        [FieldAttr(112)] public igHandleMetaField _Zone_Info_0x70 = new();
        [FieldAttr(120)] public igHandleMetaField _Zone_Info_0x78 = new();
    }
}
