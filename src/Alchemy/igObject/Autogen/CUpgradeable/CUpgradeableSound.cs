namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CUpgradeableSound : CUpgradeableValue
    {
        [FieldAttr(16)] public CSoundDotNetHandle? _defaultValue;
        [FieldAttr(24)] public CUpgradeableSoundTable? _upgradedValues;
    }
}
