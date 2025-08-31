namespace Alchemy
{
    // VSC object extracted from: Enemy_Pause_Patrol_Player_Check_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
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

        [FieldAttr(40)] public bool _DisableMotionRelativePos;
        [FieldAttr(41)] public bool _DisableMotionOnDistance;
        [FieldAttr(44)] public ELocalOffsetStopCondition _LocalOffsetStopCondition;
        [FieldAttr(48)] public float _MinRange;
        [FieldAttr(52)] public float _MaxRange;
        [FieldAttr(56)] public float _CompareValue;
    }
}
