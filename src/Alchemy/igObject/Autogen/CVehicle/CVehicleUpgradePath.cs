namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CVehicleUpgradePath : igNamedObject
    {
        [FieldAttr(24)] public CVehicleUpgradeList? _upgrades;
    }
}
