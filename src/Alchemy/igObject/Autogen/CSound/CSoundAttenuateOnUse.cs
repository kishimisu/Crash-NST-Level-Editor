namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CSoundAttenuateOnUse : igObject
    {
        [FieldAttr(16)] public float _staticIntroTime = 2.0f;
        [FieldAttr(20)] public float _attenuateTime = 2.0f;
        [FieldAttr(24)] public float _resetTime = 6.0f;
        [FieldAttr(28)] public float _targetVolume = 0.5f;
        [FieldAttr(32)] public igTimeMetaField _startTime = new();
        [FieldAttr(36)] public igTimeMetaField _nextResetTime = new();
    }
}
