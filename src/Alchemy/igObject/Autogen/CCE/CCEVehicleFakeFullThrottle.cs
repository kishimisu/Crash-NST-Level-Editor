namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CCEVehicleFakeFullThrottle : CCombatNodeEvent
    {
        public enum EThrottleEventType : uint
        {
            eTET_Start = 0,
            eTET_Stop = 1,
        }

        [FieldAttr(80)] public EThrottleEventType _eventType;
        [FieldAttr(84)] public float _enableTimerDuration = -1.0f;
        [FieldAttr(88)] public bool _enableTimerCanPause = true;
    }
}
