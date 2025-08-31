namespace Alchemy
{
    [ObjectAttr(120, 8)]
    public class CCEDockToFirstCombatTargetActor : CCombatNodeExecuteIntervalEvent
    {
        [FieldAttr(88)] public string? _dockingGeneratorName = null;
        [FieldAttr(96)] public CCEAcquireCombatTargets? _acquireTargetsEvent;
        [FieldAttr(104)] public float _separationDistance;
        [FieldAttr(108)] public float _maxGroundTraceDistance = 250.0f;
        [FieldAttr(112)] public bool _allowAerialDocking;
        [FieldAttr(113)] public bool _allowRotation = true;
    }
}
