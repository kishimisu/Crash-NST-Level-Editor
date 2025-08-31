namespace Alchemy
{
    [ObjectAttr(64, 4)]
    public class CMountControllerComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public float _jumpDecideTime = 0.1f;
        [FieldAttr(28)] public float _jumpPauseTime = 0.2667f;
        [FieldAttr(32)] public float _jumpInterpolateTime = 0.1f;
        [FieldAttr(36)] public float _jumpVelocity = 200.0f;
        [FieldAttr(40)] public float _baseBounceVelocity = 300.0f;
        [FieldAttr(44)] public float _heldBounceVelocity = 600.0f;
        [FieldAttr(48)] public float _additionalHangTimeFraction;
        [FieldAttr(52)] public bool _canPitJump = true;
        [FieldAttr(56)] public float _maxGroundDistance = 15.0f;
        [FieldAttr(60)] public float _traceDistance = 400.0f;
    }
}
