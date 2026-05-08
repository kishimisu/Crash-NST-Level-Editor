namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class C3_Egypt_Hazard_SlidingBlock_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Spline_Velocity_Mover = new();
        [FieldAttr(nst: 64, ctr: 56)] public string? _CrashDeath = null;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Vfx_Effect_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Vfx_Effect_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Sound = new();
    }
}
