namespace Alchemy
{
    // VSC object extracted from: Hazard_Triceratops_SplineController.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class Hazard_Triceratops_SplineControllerData : CVscComponentData
    {
        public enum ENewEnum18_id_vwdp7w07
        {
            Pause = 0,
            Stop = 1,
            Start = 2,
        }

        [FieldAttr(40)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(48)] public ENewEnum18_id_vwdp7w07 _NewEnum18_id_vwdp7w07;
        [FieldAttr(56)] public igHandleMetaField _Waypoint = new();
        [FieldAttr(64)] public igHandleMetaField _Query_Filter = new();
    }
}
