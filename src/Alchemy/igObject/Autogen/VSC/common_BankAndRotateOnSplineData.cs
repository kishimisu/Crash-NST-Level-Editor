namespace Alchemy
{
    // VSC object extracted from: common_BankAndRotateOnSpline.igz

    [ObjectAttr(144, metaType: typeof(CVscComponentData))]
    public class common_BankAndRotateOnSplineData : CVscComponentData
    {
        [FieldAttr(40)] public float _Float_0x28;
        [FieldAttr(48)] public igHandleMetaField _Entity_0x30 = new();
        [FieldAttr(56)] public igHandleMetaField _Entity_0x38 = new();
        [FieldAttr(64)] public float _Float_0x40;
        [FieldAttr(72)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(80)] public string? _String = null;
        [FieldAttr(88)] public float _Float_0x58;
        [FieldAttr(96)] public igHandleMetaField _Spline_Velocity_Mover = new();
        [FieldAttr(104)] public igHandleMetaField _Spline_Attach_Behavior = new();
        [FieldAttr(112)] public igHandleMetaField _Spline_Rotation_Mover = new();
        [FieldAttr(120)] public bool _Bool;
        [FieldAttr(128)] public igHandleMetaField _Entity_0x80 = new();
        [FieldAttr(136)] public igHandleMetaField _Debug_Update_Channel = new();
    }
}
