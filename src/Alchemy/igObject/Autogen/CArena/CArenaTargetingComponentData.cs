namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CArenaTargetingComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CQueryFilter? _targetQuery;
        [FieldAttr(32)] public CQueryFilter? _noInputTargetQuery;
        [FieldAttr(40)] public CFilterByVision.EFacing _facing;
        [FieldAttr(44)] public float _maxAcceptableTargetAngle = 20.0f;
        [FieldAttr(48)] public float _subFilterAngleWeight = 8.0f;
        [FieldAttr(52)] public float _subFilterDistanceWeight = 1.0f;
        [FieldAttr(56)] public float _subFilterMaxDistance = 5000.0f;
        [FieldAttr(60)] public ECombatTargetList _targetList;
        [FieldAttr(64)] public float _targetDropTime = -1.0f;
        [FieldAttr(68)] public float _targetDropDistance = -1.0f;
        [FieldAttr(72)] public float _targetDropAngle;
        [FieldAttr(76)] public bool _targetDropWhenOffscreen = true;
        [FieldAttr(77)] public bool _prioritizeLockedActorOverNewNonActorTarget = true;
        [FieldAttr(80)] public float _noInputTargetingResetTime = 2.0f;
        [FieldAttr(84)] public bool _passengerTargeting;
        [FieldAttr(85)] public bool _gunnerAutoDetect = true;
    }
}
