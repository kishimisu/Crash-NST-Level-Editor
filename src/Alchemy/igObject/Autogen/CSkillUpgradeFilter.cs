namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CSkillUpgradeFilter : CBaseUpgradeFilter
    {
        public enum ESkillUpgradeFilterType : uint
        {
            eSUFT_UpgradeRequiredAsActive = 0,
            eSUFT_UpgradeRequiredAsInactive = 1,
        }

        [FieldAttr(16)] public ESkillUpgradeFilterType _skillUpgradeFilterType;
        [FieldAttr(24)] public igHandleMetaField _skillUpgrade = new();
    }
}
