namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Pause_Patrol_Player_CheckData : CVscComponentData
    {
        public enum ELocalOffsetStopCondition
        {
            StopWhenXNegative = 0,
            StopWhenXPositive = 1,
            StopWhenYNegative = 2,
            StopWhenYPositive = 3,
            StopWhenZNegative = 4,
            StopWhenZPositive = 5,
        }

        [FieldAttr(nst: 40, ctr: 32)] public bool _DisableMotionRelativePos;
        [FieldAttr(nst: 41, ctr: 33)] public bool _DisableMotionOnDistance;
        [FieldAttr(nst: 44, ctr: 36)] public ELocalOffsetStopCondition _LocalOffsetStopCondition;
        [FieldAttr(nst: 48, ctr: 40)] public float _MinRange;
        [FieldAttr(nst: 52, ctr: 44)] public float _MaxRange;
        [FieldAttr(nst: 56, ctr: 48)] public float _CompareValue;
    }
}
