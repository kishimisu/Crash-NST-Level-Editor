namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CUpgradeableModel : CUpgradeableValue
    {
        [FieldAttr(16)] public CModelPath? _defaultValue;
        [FieldAttr(24)] public CUpgradeableModelTable? _upgradedValues;
    }
}
