namespace Alchemy
{
    // VSC object extracted from: Factory_Hazard_Barrel_Behavior_c.igz

    [ObjectAttr(128, metaType: typeof(CVscComponentData))]
    public class Factory_Hazard_Barrel_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public bool _Bouncing;
        [FieldAttr(48)] public igHandleMetaField _SplineOffsetAttachBehavior = new();
        [FieldAttr(56)] public string? _RollAnimation_0x38 = null;
        [FieldAttr(64)] public igHandleMetaField _Spline_Velocity_Mover = new();
        [FieldAttr(72)] public string? _RollAnimation_0x48 = null;
        [FieldAttr(80)] public igHandleMetaField _Spline_Event_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Spline_Event_0x58 = new();
        [FieldAttr(96)] public igHandleMetaField _Vfx_Effect_0x60 = new();
        [FieldAttr(104)] public igHandleMetaField _Vfx_Effect_0x68 = new();
        [FieldAttr(112)] public igHandleMetaField _Vfx_Effect_0x70 = new();
        [FieldAttr(120)] public igHandleMetaField _Vfx_Effect_0x78 = new();
    }
}
