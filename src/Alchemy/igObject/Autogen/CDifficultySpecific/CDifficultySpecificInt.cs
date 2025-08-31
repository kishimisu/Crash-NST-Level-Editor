namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CDifficultySpecificInt : CDifficultySpecificValue
    {
        [FieldAttr(16)] public int _easyValue;
        [FieldAttr(20)] public int _mediumValue;
        [FieldAttr(24)] public int _hardValue;
        [FieldAttr(28)] public int _nightmareValue;
    }
}
