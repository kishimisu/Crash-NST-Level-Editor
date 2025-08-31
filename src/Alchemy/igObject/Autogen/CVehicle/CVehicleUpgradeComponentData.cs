namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CVehicleUpgradeComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CVehicleUpgradePath? _shieldUpgrades;
        [FieldAttr(32)] public CVehicleUpgradePath? _weaponUpgrades;
    }
}
