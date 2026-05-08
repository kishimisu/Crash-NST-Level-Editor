namespace Alchemy
{
    [ObjectAttr(nst: 136, ctr: 128, align: 4, metaType: typeof(CVscComponentData))]
    public class BlasterTech_BunnyHopControlData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _EnterBehaviorGroup = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _EnterThumpBehaviorGroup = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _ExitBehaviorGroup = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _SpeedBoost = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _DustCloudEntityData = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _BunnyEntityData = new();
        [FieldAttr(nst: 88, ctr: 80)] public float _AmountToAdd;
        [FieldAttr(nst: 92, ctr: 84)] public float _WindUpDuration;
        [FieldAttr(nst: 96, ctr: 88)] public float _DashDuration;
        [FieldAttr(nst: 100, ctr: 92)] public float _MaxSpeed;
        [FieldAttr(nst: 104, ctr: 96)] public int _BunnySpawnCount;
        [FieldAttr(nst: 112, ctr: 104)] public string? _GotoDashBehaviorEvent = null;
        [FieldAttr(nst: 120, ctr: 112)] public string? _TertiaryFadeOut = null;
        [FieldAttr(nst: 128, ctr: 120)] public string? _GotoThumpEndBehaviorEvent = null;
    }
}
