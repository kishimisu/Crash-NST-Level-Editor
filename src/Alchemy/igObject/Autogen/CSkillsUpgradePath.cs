namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CSkillsUpgradePath : igNamedObject
    {
        [FieldAttr(24)] public string? _description = "[Description Missing]";
        [FieldAttr(32)] public CSkillUpgradeList? _skills;
    }
}
