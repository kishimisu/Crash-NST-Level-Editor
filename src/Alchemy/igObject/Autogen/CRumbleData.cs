namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CRumbleData : igObject
    {
        [FieldAttr(16)] public float _rumbleStrength = 0.2f;
        [FieldAttr(20)] public float _rumbleDuration = 0.5f;
        [FieldAttr(24)] public float _vibrationStrength;
        [FieldAttr(28)] public float _vibrationDuration = 0.5f;
    }
}
