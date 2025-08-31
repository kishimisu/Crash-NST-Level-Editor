namespace Alchemy
{
    [ObjectAttr(176, 8, metaType: typeof(Object))]
    public class Scripts_BoltOnData : Object
    {
        [FieldAttr(32)] public string? BoltOnModelString = null;
        [FieldAttr(40)] public CBoltPoint? BoltPoint;
        [FieldAttr(48)] public EBoltonModels BoltonModels = EBoltonModels.EBOLTON_NONE;
        [FieldAttr(52)] public bool NeedPreviousUpgrades;
        [FieldAttr(53)] public bool IsBoltOnUpgrade = true;
        [FieldAttr(56)] public string? BoltOnModelUpgradeString = null;
        [FieldAttr(64)] public igHandleMetaField SkillUpgade = new();
        [FieldAttr(72)] public bool IsBoltOnSecondUpgrade = true;
        [FieldAttr(80)] public string? BoltOnModelSecondUpgradeString = null;
        [FieldAttr(88)] public igHandleMetaField SkillSecondUpgade = new();
        [FieldAttr(96)] public bool IsBoltOnThirdUpgrade = true;
        [FieldAttr(104)] public string? BoltOnModelThirdUpgradeString = null;
        [FieldAttr(112)] public igHandleMetaField SkillThirdUpgrade = new();
        [FieldAttr(120)] public bool useGrouping;
        [FieldAttr(128)] public List_1? BoltOnGroupModelStrings;
        [FieldAttr(136)] public bool AddEmptySlotAutomatically = true;
        [FieldAttr(144)] public CEntityMessage? BoltMessage;
        [FieldAttr(152)] public CEntityMessage? UnboltMessage;
        [FieldAttr(160)] public CVfxEffectDotNetHandle? BoltVfx;
        [FieldAttr(168)] public bool HardKillVfx;
    }
}
