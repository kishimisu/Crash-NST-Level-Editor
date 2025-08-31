namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class CSplineConstantVelocityMover : CSplineVelocityMover
    {
        [FieldAttr(40)] public float _velocity = 100.0f;
    }
}
