namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_UpgradeRequiredComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_UpgradeRequiredComponent_
    {
        [FieldAttr(40)] public CBaseUpgradeFilter? SkillUpgradeList;
        [FieldAttr(48)] public bool UseCreator;
        [FieldAttr(56)] public CEntityComponentData? ComponentToAttach;
        [FieldAttr(64)] public bool AttachToDummy = true;
    }
}
