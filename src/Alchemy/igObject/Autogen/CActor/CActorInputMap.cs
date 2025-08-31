namespace Alchemy
{
    [ObjectAttr(64, 4)]
    public class CActorInputMap : igObject
    {
        [FieldAttr(16)] public bool _overrideMagnitude = true;
        [FieldAttr(20)] public float _deadZone = 0.25f;
        [FieldAttr(24)] public float _walkBlend = 0.34999999f;
        [FieldAttr(28)] public float _walkCap = 0.64999998f;
        [FieldAttr(32)] public float _runBlend = 0.75f;
        [FieldAttr(36)] public float _walkSpeed = 0.5f;
        [FieldAttr(40)] public float _runSpeed = 1.0f;
        [FieldAttr(44)] public bool _overrideAngle = true;
        [FieldAttr(48)] public float _movementSegmentBlend = 0.25f;
        [FieldAttr(52)] public float _cardinalPrimacy = 0.6f;
        [FieldAttr(56)] public float _secondaryPrimacy = 0.85f;
        [FieldAttr(60)] public bool _combineLeftStickDPad = true;
    }
}
