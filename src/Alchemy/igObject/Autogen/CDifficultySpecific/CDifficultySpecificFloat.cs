namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CDifficultySpecificFloat : CDifficultySpecificValue
    {
        [FieldAttr(16)] public float _easyValue;
        [FieldAttr(20)] public float _mediumValue;
        [FieldAttr(24)] public float _hardValue;
        [FieldAttr(28)] public float _nightmareValue;
    }
}
