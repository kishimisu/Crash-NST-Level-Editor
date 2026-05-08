namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class common_JetSki_Hazard_Floating_Mine_MoverData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Spline_Attach_Behavior = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Spline_Velocity_Mover = new();
        [FieldAttr(nst: 56, ctr: 48)] public ESplineEndBehavior _E_Spline_End_Behavior;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Component_Data = new();
    }
}
