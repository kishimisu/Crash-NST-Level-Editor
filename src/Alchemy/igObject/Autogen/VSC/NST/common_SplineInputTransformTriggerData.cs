namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class common_SplineInputTransformTriggerData : CVscComponentData
    {
        public enum ENewEnum8_id_ntdpr081
        {
            Stop = 0,
            StartSpline = 1,
            StartCircular = 2,
        }

        [FieldAttr(nst: 40, ctr: 32)] public ENewEnum8_id_ntdpr081 _NewEnum8_id_ntdpr081;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 56, ctr: 48)] public bool _Bool_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public igVec2fMetaField _Vec_2F = new();
        [FieldAttr(nst: 68, ctr: 60)] public float _Float;
        [FieldAttr(nst: 72, ctr: 64)] public bool _Bool_0x48;
    }
}
