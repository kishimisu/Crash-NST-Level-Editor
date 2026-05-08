namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class Common_Enemy_RotateToPlayer_BehaviorData : CVscComponentData
    {
        public enum ERotationAxis
        {
            XAxis = 0,
            YAxis = 1,
            ZAxis = 2,
        }

        [FieldAttr(nst: 40, ctr: 32)] public ERotationAxis _RotationAxis;
        [FieldAttr(nst: 44, ctr: 36)] public float _RotateTime;
        [FieldAttr(nst: 48, ctr: 40)] public float _ClampRotation;
        [FieldAttr(nst: 52, ctr: 44)] public float _RotationOffset;
        [FieldAttr(nst: 56, ctr: 48)] public bool _Bool_0x38;
        [FieldAttr(nst: 57, ctr: 49)] public bool _Bool_0x39;
        [FieldAttr(nst: 58, ctr: 50)] public bool _Bool_0x3a;
        [FieldAttr(nst: 59, ctr: 51)] public bool _Bool_0x3b;
    }
}
