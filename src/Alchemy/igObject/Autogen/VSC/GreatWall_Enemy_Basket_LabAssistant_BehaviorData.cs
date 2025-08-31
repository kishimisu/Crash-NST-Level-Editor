namespace Alchemy
{
    // VSC object extracted from: GreatWall_Enemy_Basket_LabAssistant_Behavior.igz

    [ObjectAttr(96, metaType: typeof(CVscComponentData))]
    public class GreatWall_Enemy_Basket_LabAssistant_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public string? _String_0x28 = null;
        [FieldAttr(48)] public string? _String_0x30 = null;
        [FieldAttr(56)] public igHandleMetaField _Spline_Velocity_Mover = new();
        [FieldAttr(64)] public igHandleMetaField _Spline_Attach_Behavior = new();
        [FieldAttr(72)] public igHandleMetaField _Spline_Rotation_Mover = new();
        [FieldAttr(80)] public float _Float;
        [FieldAttr(88)] public igHandleMetaField _Entity = new();
    }
}
