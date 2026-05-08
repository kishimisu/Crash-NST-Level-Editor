namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_Triceratops_SplineControllerData : CVscComponentData
    {
        public enum ENewEnum18_id_vwdp7w07
        {
            Pause = 0,
            Stop = 1,
            Start = 2,
        }

        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(nst: 48, ctr: 40)] public ENewEnum18_id_vwdp7w07 _NewEnum18_id_vwdp7w07;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Waypoint = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Query_Filter = new();
    }
}
