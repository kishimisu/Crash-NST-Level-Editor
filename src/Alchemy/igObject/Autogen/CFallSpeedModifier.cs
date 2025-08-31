namespace Alchemy
{
    [ObjectAttr(240, 8)]
    public class CFallSpeedModifier : igObject
    {
        [FieldAttr(16)] public bool _activated;
        [FieldAttr(20)] public float _timeActivated;
        [FieldAttr(24)] public float _startVelocity;
        [FieldAttr(28)] public float _minActivationVelocity = -50.0f;
        [FieldAttr(32)] public float _duration = 1.0f;
        [FieldAttr(40)] public string? _activatingState = null;
        [FieldAttr(48)] public igHandleMetaField _activatingStateVariable = new();
        [FieldAttr(56)] public int _activatingStateIntValue;
        [FieldAttr(60)] public float _maximumInputVelocity = -200.0f;
        [FieldAttr(64)] public int _priority;
        [FieldAttr(68)] public igVfxRangedCurveMetaField _velocityLifetimeCurve = new();
        [FieldAttr(152)] public igVfxRangedCurveMetaField _velocityActivationCurve = new();
        [FieldAttr(236)] public float _velocityActivationCurveMaxTime = 0.3f;
    }
}
