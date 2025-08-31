namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CPointOfInterestComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public EPointOfInterest _type;
        [FieldAttr(28)] public float _range = 500.0f;
        [FieldAttr(32)] public float _minimumRange = -1.0f;
        [FieldAttr(36)] public int _priority = 1;
        [FieldAttr(40)] public float _lookAtDelay = 0.5f;
        [FieldAttr(44)] public float _lookAtDisableOnTargetLostDelay = 1.0f;
        [FieldAttr(48)] public string? _requiredState = null;
        [FieldAttr(56)] public igVec3fMetaField _offset = new();
        [FieldAttr(68)] public bool _startDisabled;
        [FieldAttr(72)] public CEntityMessage? _awareMessage;
        [FieldAttr(80)] public float _chanceToRespond = 1.0f;
        [FieldAttr(84)] public float _responseCooldown;
    }
}
