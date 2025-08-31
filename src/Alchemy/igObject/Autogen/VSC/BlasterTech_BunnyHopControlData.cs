namespace Alchemy
{
    // VSC object extracted from: BlasterTech_BunnyHopControl_c.igz

    [ObjectAttr(136, metaType: typeof(CVscComponentData))]
    public class BlasterTech_BunnyHopControlData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _EnterBehaviorGroup = new();
        [FieldAttr(48)] public igHandleMetaField _EnterThumpBehaviorGroup = new();
        [FieldAttr(56)] public igHandleMetaField _ExitBehaviorGroup = new();
        [FieldAttr(64)] public igHandleMetaField _SpeedBoost = new();
        [FieldAttr(72)] public igHandleMetaField _DustCloudEntityData = new();
        [FieldAttr(80)] public igHandleMetaField _BunnyEntityData = new();
        [FieldAttr(88)] public float _AmountToAdd;
        [FieldAttr(92)] public float _WindUpDuration;
        [FieldAttr(96)] public float _DashDuration;
        [FieldAttr(100)] public float _MaxSpeed;
        [FieldAttr(104)] public int _BunnySpawnCount;
        [FieldAttr(112)] public string? _GotoDashBehaviorEvent = null;
        [FieldAttr(120)] public string? _TertiaryFadeOut = null;
        [FieldAttr(128)] public string? _GotoThumpEndBehaviorEvent = null;
    }
}
