namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CUpgradeableInt : CUpgradeableValue
    {
        [FieldAttr(16)] public int _defaultValue;
        [FieldAttr(24)] public CUpgradeableIntTable? _upgradedValues;
    }
}
