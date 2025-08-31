namespace Alchemy
{
    // VSC object extracted from: Jetski_Hazard_Cannon_Behavior.igz

    [ObjectAttr(104, metaType: typeof(CVscComponentData))]
    public class Jetski_Hazard_Cannon_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Entity = new();
        [FieldAttr(48)] public igHandleMetaField _Spline_Velocity_Mover = new();
        [FieldAttr(56)] public float _Float;
        [FieldAttr(64)] public string? _String_0x40 = null;
        [FieldAttr(72)] public string? _String_0x48 = null;
        [FieldAttr(80)] public string? _String_0x50 = null;
        [FieldAttr(88)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(96)] public igHandleMetaField _Bolt_Point = new();
    }
}
