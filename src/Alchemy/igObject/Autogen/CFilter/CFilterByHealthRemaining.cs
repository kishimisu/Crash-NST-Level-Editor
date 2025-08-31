namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CFilterByHealthRemaining : CFilterMethod
    {
        public enum EComparisonType : uint
        {
            eCT_LessThanEqual = 0,
            eCT_GreaterThanEqual = 1,
        }

        [FieldAttr(24)] public EComparisonType _comparisonType;
        [FieldAttr(28)] public int _healthPercentageThreshold = 50;
    }
}
