namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CSplineVelocityMover : igObject
    {
        [FieldAttr(16)] public float _convergeRatio;
        [FieldAttr(20)] public bool _convergeCompleted;
        [FieldAttr(24)] public float _startVelocity;
        [FieldAttr(28)] public float _currentBaseVelocity;
        [FieldAttr(32)] public float _linearMultiplier = 1.0f;
        [FieldAttr(36)] public float _linearAddition;
    }
}
