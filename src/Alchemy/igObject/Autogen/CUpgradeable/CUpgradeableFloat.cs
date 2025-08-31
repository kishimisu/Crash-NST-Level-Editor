namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CUpgradeableFloat : CUpgradeableValue
    {
        [FieldAttr(16)] public float _defaultValue;
        [FieldAttr(24)] public CUpgradeableFloatTable? _upgradedValues;
    }
}
