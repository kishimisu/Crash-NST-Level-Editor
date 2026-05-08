namespace Alchemy
{
    [ObjectAttr(nst: 144, ctr: 136, align: 4, metaType: typeof(CVscComponentData))]
    public class common_BankAndRotateOnSplineData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float_0x28;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x40;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 80, ctr: 72)] public string? _String = null;
        [FieldAttr(nst: 88, ctr: 80)] public float _Float_0x58;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Spline_Velocity_Mover = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Spline_Attach_Behavior = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Spline_Rotation_Mover = new();
        [FieldAttr(nst: 120, ctr: 112)] public bool _Bool;
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Entity_0x80 = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Debug_Update_Channel = new();
    }
}
