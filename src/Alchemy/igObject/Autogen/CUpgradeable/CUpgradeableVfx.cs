namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CUpgradeableVfx : CUpgradeableValue
    {
        [FieldAttr(16)] public CUpgradeableVfxData? _defaultValue;
        [FieldAttr(24)] public CUpgradeableVfxTable? _upgradedValues;
    }
}
