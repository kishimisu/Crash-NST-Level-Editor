namespace Alchemy
{
    // VSC object extracted from: common_JetSki_Hazard_Floating_Mine_Mover.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class common_JetSki_Hazard_Floating_Mine_MoverData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Spline_Attach_Behavior = new();
        [FieldAttr(48)] public igHandleMetaField _Spline_Velocity_Mover = new();
        [FieldAttr(56)] public ESplineEndBehavior _E_Spline_End_Behavior;
        [FieldAttr(64)] public igHandleMetaField _Component_Data = new();
    }
}
