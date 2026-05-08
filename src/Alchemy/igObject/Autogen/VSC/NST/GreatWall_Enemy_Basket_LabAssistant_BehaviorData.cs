namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class GreatWall_Enemy_Basket_LabAssistant_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _String_0x28 = null;
        [FieldAttr(nst: 48, ctr: 40)] public string? _String_0x30 = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Spline_Velocity_Mover = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Spline_Attach_Behavior = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Spline_Rotation_Mover = new();
        [FieldAttr(nst: 80, ctr: 72)] public float _Float;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Entity = new();
    }
}
