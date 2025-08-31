namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CVehicleUpgrade : CUpgrade
    {
        [FieldAttr(24)] public string? _upgradeName = null;
        [FieldAttr(32)] public int _cost;
        [FieldAttr(36)] public int _toyUpgradeFlagBit = -1;
    }
}
