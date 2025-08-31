namespace Alchemy
{
    // VSC object extracted from: C3_Egypt_Hazard_SlidingBlock_Behavior.igz

    [ObjectAttr(104, metaType: typeof(CVscComponentData))]
    public class C3_Egypt_Hazard_SlidingBlock_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public float _Float;
        [FieldAttr(48)] public igHandleMetaField _Vfx_Effect_0x30 = new();
        [FieldAttr(56)] public igHandleMetaField _Spline_Velocity_Mover = new();
        [FieldAttr(64)] public string? _CrashDeath = null;
        [FieldAttr(72)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(80)] public igHandleMetaField _Vfx_Effect_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Vfx_Effect_0x58 = new();
        [FieldAttr(96)] public igHandleMetaField _Sound = new();
    }
}
