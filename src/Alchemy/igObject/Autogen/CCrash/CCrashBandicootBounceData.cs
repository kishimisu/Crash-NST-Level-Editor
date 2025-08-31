namespace Alchemy
{
    [ObjectAttr(64, 4)]
    public class CCrashBandicootBounceData : igObject
    {
        [FieldAttr(16)] public float _jumpHeight;
        [FieldAttr(20)] public float _jumpRiseTime;
        [FieldAttr(24)] public float _fallTime;
        [FieldAttr(28)] public float _jumpHeightWhenJumpIsHeld;
        [FieldAttr(32)] public float _jumpRiseTimeWhenJumpIsHeld;
        [FieldAttr(36)] public float _jumpFallTimeWhenJumpWasHeld;
        [FieldAttr(40)] public float _jumpRiseTimeWhenJumpIsReleased;
        [FieldAttr(44)] public float _xyMovementSpeed = 380.0f;
        [FieldAttr(48)] public float _xyMovementDamping = 0.25f;
        [FieldAttr(52)] public float _airMovementInputThrottle = 3.5f;
        [FieldAttr(56)] public bool _forceBounce;
    }
}
