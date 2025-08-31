namespace Alchemy
{
    [ObjectAttr(72, 4)]
    public class CSplineTimeBasedMover : CSplineVelocityMover
    {
        [FieldAttr(40)] public float _time = 1.0f;
        [FieldAttr(44)] public float _easeInTime;
        [FieldAttr(48)] public float _easeInVelocityScale = 0.5f;
        [FieldAttr(52)] public float _easeOutTime;
        [FieldAttr(56)] public float _easeOutVelocityScale = 0.5f;
        [FieldAttr(60)] public float _elapsedTime;
        [FieldAttr(64)] public bool _reversing;
    }
}
