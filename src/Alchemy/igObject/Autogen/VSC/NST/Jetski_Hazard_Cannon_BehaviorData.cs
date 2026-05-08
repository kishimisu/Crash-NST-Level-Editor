namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class Jetski_Hazard_Cannon_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Spline_Velocity_Mover = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Float;
        [FieldAttr(nst: 64, ctr: 56)] public string? _String_0x40 = null;
        [FieldAttr(nst: 72, ctr: 64)] public string? _String_0x48 = null;
        [FieldAttr(nst: 80, ctr: 72)] public string? _String_0x50 = null;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Bolt_Point = new();
    }
}
