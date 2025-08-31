namespace Alchemy
{
    // VSC object extracted from: common_InputTransformTrigger.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class common_SplineInputTransformTriggerData : CVscComponentData
    {
        public enum ENewEnum8_id_ntdpr081
        {
            Stop = 0,
            StartSpline = 1,
            StartCircular = 2,
        }

        [FieldAttr(40)] public ENewEnum8_id_ntdpr081 _NewEnum8_id_ntdpr081;
        [FieldAttr(48)] public igHandleMetaField _Entity = new();
        [FieldAttr(56)] public bool _Bool_0x38;
        [FieldAttr(60)] public igVec2fMetaField _Vec_2F = new();
        [FieldAttr(68)] public float _Float;
        [FieldAttr(72)] public bool _Bool_0x48;
    }
}
