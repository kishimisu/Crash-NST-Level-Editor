namespace Alchemy
{
    [ObjectAttr(96, 4)]
    public class CCollectibleSystemData : igObject
    {
        [FieldAttr(16)] public float _xpScalarEasy = 1.0f;
        [FieldAttr(20)] public float _xpScalarMedium = 1.0f;
        [FieldAttr(24)] public float _xpScalarHard = 1.1f;
        [FieldAttr(28)] public float _xpScalarNightmare = 1.2f;
        [FieldAttr(32)] public float _vehicleXpScalarEasy = 1.0f;
        [FieldAttr(36)] public float _vehicleXpScalarMedium = 1.0f;
        [FieldAttr(40)] public float _vehicleXpScalarHard = 1.1f;
        [FieldAttr(44)] public float _vehicleXpScalarNightmare = 1.2f;
        [FieldAttr(48)] public float _moneyScalarEasy = 1.0f;
        [FieldAttr(52)] public float _moneyScalarMedium = 1.0f;
        [FieldAttr(56)] public float _moneyScalarHard = 1.1f;
        [FieldAttr(60)] public float _moneyScalarNightmare = 1.2f;
        [FieldAttr(64)] public float _stardustScalarEasy = 1.0f;
        [FieldAttr(68)] public float _stardustScalarMedium = 1.0f;
        [FieldAttr(72)] public float _stardustScalarHard = 1.1f;
        [FieldAttr(76)] public float _stardustScalarNightmare = 1.2f;
        [FieldAttr(80)] public float _unownedSoulGemWeight = 0.85f;
        [FieldAttr(84)] public float _upgradedSoulGemWeight = 0.85f;
        [FieldAttr(88)] public float _normalSoulGemWeight = 0.15f;
        [FieldAttr(92)] public uint _unownedSoulGemInterval = 259200;
    }
}
