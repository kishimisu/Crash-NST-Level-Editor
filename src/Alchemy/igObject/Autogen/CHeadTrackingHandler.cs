namespace Alchemy
{
    [ObjectAttr(104, 8, metaType: typeof(CHeadTrackingHandler))]
    public class CHeadTrackingHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public CHeadTrackingTargetList? _targetPriorityList;
        [FieldAttr(88)] public float _lookAtAngleLimit = -1.0f;
        [FieldAttr(92)] public float _minimumLookAtDuration;
        [FieldAttr(96)] public bool _ignorePointOfInterestDistances;
        [FieldAttr(97)] public bool _ignoreAngleLimits;
        [FieldAttr(98)] public bool _disableProceduralAnimation;
    }
}
