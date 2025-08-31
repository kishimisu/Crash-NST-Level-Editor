namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CSkillUpgrade : CUpgrade
    {
        [FieldAttr(24)] public string? _skillName = null;
        [FieldAttr(32)] public int _cost;
        [FieldAttr(40)] public string? _lockedUpgradeDescription = null;
        [FieldAttr(48)] public CCharacterAttributeList? _upgradeAttributeBoost;
        [FieldAttr(56)] public igHandleMetaField _prerequisiteUpgrade = new();
        [FieldAttr(64)] public igHandleMetaField _previewImage = new();
        [FieldAttr(72)] public bool _unlockInDemo;
        [FieldAttr(76)] public EGameYear _year = EGameYear.eGY_Count;
        [FieldAttr(80)] public int _toyAbilityFlagBit = -1;
    }
}
