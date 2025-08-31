namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CCEStartJumpDropSlamMovement : CCombatNodeEvent
    {
        [FieldAttr(80)] public float _initialFallSpeed = 350.0f;
        [FieldAttr(84)] public float _gravityMultiplier = 1.0f;
        [FieldAttr(88)] public float _maxFallSpeedMultiplier = 1.0f;
    }
}
