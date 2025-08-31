namespace Alchemy
{
    [ObjectAttr(24, 8)]
    public class CMultipleSkillUpgradeFilter : CBaseUpgradeFilter
    {
        [FieldAttr(16)] public CSkillUpgradeFilterList? _skillUpgradeFilters;
    }
}
