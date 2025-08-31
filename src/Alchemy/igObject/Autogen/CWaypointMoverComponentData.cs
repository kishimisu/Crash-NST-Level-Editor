namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class CWaypointMoverComponentData : CEntityComponentData
    {
        public enum EWaypointMoverSelectionType : uint
        {
            eWMST_Default = 0,
            eWMST_Closest = 1,
        }

        public enum EWaypointMoverMoveMethod : uint
        {
            eWMMM_Pathfinding = 0,
            eWMMM_StraightLine = 1,
            eWMMM_Reliable = 2,
        }

        public enum EWaypointMoverLoopMode : uint
        {
            eWMLM_PlayOnce = 0,
            eWMLM_Loop = 1,
            eWMLM_PingPong = 2,
        }

        public enum EWaypointMoverMoveAnimation : uint
        {
            eWMMA_Run = 0,
            eWMMA_Walk = 1,
            eWMMA_Custom = 2,
        }

        [FieldAttr(24)] public CTraversalPath? _waypoints;
        [FieldAttr(32)] public EWaypointMoverSelectionType _waypointSelectionType;
        [FieldAttr(40)] public CTraversalPathList? _additionalWaypointLists;
        [FieldAttr(48)] public EWaypointMoverMoveMethod _moveMethod;
        [FieldAttr(52)] public EWaypointMoverLoopMode _loopMode;
        [FieldAttr(56)] public bool _startMovingOnEnable;
        [FieldAttr(57)] public bool _orientAtEnd;
        [FieldAttr(58)] public bool _dieAtEnd;
        [FieldAttr(59)] public bool _dieSilently = true;
        [FieldAttr(60)] public float _rotationTime = 1.0f;
        [FieldAttr(64)] public float _goalDistance = 40.0f;
        [FieldAttr(68)] public EWaypointMoverMoveAnimation _moveAnimation;
        [FieldAttr(72)] public float _customMoveSpeed = 1.0f;
        [FieldAttr(80)] public string? _behaviorStartEvent = null;
        [FieldAttr(88)] public string? _behaviorStopEvent = null;
        [FieldAttr(96)] public bool _enableAIOnDamage;
        [FieldAttr(97)] public bool _startMovingOnDamage;
    }
}
