namespace Alchemy
{
    // VSC object extracted from: Hazard_Forced_Chase_Behavior_c.igz

    [ObjectAttr(136, metaType: typeof(CVscComponentData))]
    public class Hazard_Forced_Chase_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public bool _DestroyAtEnd;
        [FieldAttr(41)] public bool _HurtOnIdle;
        [FieldAttr(48)] public igHandleMetaField _OptionalTrigger = new();
        [FieldAttr(56)] public igHandleMetaField _SplineSnapAttachBehavior = new();
        [FieldAttr(64)] public igHandleMetaField _SplineRotationMover = new();
        [FieldAttr(72)] public igHandleMetaField _SplineVelocityMover = new();
        [FieldAttr(80)] public string? _IdleStart = null;
        [FieldAttr(88)] public string? _IdleEnd = null;
        [FieldAttr(96)] public string? _Chase = null;
        [FieldAttr(104)] public float _Float_0x68;
        [FieldAttr(108)] public float _Float_0x6c;
        [FieldAttr(112)] public float _Float_0x70;
        [FieldAttr(116)] public bool _Bool;
        [FieldAttr(120)] public float _Float_0x78;
        [FieldAttr(128)] public igHandleMetaField _Entity = new();
    }
}
