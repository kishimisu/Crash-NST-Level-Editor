namespace Alchemy
{
    // VSC object extracted from: Common_Enemy_RotateToPlayer_Behavior_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class Common_Enemy_RotateToPlayer_BehaviorData : CVscComponentData
    {
        public enum ERotationAxis
        {
            XAxis = 0,
            YAxis = 1,
            ZAxis = 2,
        }

        [FieldAttr(40)] public ERotationAxis _RotationAxis;
        [FieldAttr(44)] public float _RotateTime;
        [FieldAttr(48)] public float _ClampRotation;
        [FieldAttr(52)] public float _RotationOffset;
        [FieldAttr(56)] public bool _Bool_0x38;
        [FieldAttr(57)] public bool _Bool_0x39;
        [FieldAttr(58)] public bool _Bool_0x3a;
        [FieldAttr(59)] public bool _Bool_0x3b;
    }
}
