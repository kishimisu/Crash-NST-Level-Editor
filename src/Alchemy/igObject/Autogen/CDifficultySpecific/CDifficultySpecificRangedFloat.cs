namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class CDifficultySpecificRangedFloat : CDifficultySpecificValue
    {
        [FieldAttr(16)] public igRangedFloatMetaField _easyValue = new();
        [FieldAttr(24)] public igRangedFloatMetaField _mediumValue = new();
        [FieldAttr(32)] public igRangedFloatMetaField _hardValue = new();
        [FieldAttr(40)] public igRangedFloatMetaField _nightmareValue = new();
    }
}
