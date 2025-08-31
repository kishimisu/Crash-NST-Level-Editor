namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CSplineLooseConstantVelocityMover : CSplineVelocityMover
    {
        [FieldAttr(40)] public float _velocity = 100.0f;
        [FieldAttr(44)] public float _tolerance;
        [FieldAttr(48, false)] public CEntity? _entityOnSpline;
    }
}
