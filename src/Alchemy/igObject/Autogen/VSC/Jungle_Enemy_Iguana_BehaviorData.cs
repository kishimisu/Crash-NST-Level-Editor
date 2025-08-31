namespace Alchemy
{
    // VSC object extracted from: Jungle_Enemy_Iguana_Behavior.igz

    [ObjectAttr(128, metaType: typeof(CVscComponentData))]
    public class Jungle_Enemy_Iguana_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _SplineVelocityMover = new();
        [FieldAttr(48)] public igHandleMetaField _SplineRotationMover = new();
        [FieldAttr(56)] public igHandleMetaField _Spline_Attach_Behavior = new();
        [FieldAttr(64)] public igHandleMetaField _Spline_Event_0x40 = new();
        [FieldAttr(72)] public string? _String_0x48 = null;
        [FieldAttr(80)] public float _Float_0x50;
        [FieldAttr(84)] public float _Float_0x54;
        [FieldAttr(88)] public string? _String_0x58 = null;
        [FieldAttr(96)] public float _Float_0x60;
        [FieldAttr(100)] public float _Float_0x64;
        [FieldAttr(104)] public string? _String_0x68 = null;
        [FieldAttr(112)] public float _Float_0x70;
        [FieldAttr(116)] public float _Float_0x74;
        [FieldAttr(120)] public igHandleMetaField _Spline_Event_0x78 = new();
    }
}
