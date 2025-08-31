namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CSkillsUpgradeComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CSkillUpgradeList? _initialAbilities;
        [FieldAttr(32)] public CSkillsUpgradePathList? _upgrades;
        [FieldAttr(40)] public int _debugOptionalUpgradePath;
        [FieldAttr(44)] public bool _ignorePlayerChecks;
    }
}
