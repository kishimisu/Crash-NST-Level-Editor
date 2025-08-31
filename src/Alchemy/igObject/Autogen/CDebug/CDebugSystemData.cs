namespace Alchemy
{
    [ObjectAttr(56, 4)]
    public class CDebugSystemData : igObject
    {
        [FieldAttr(16)] public int _basicAbility1UnlockLevel = 2;
        [FieldAttr(20)] public int _basicAbility2UnlockLevel = 4;
        [FieldAttr(24)] public int _basicAbility3UnlockLevel = 6;
        [FieldAttr(28)] public int _basicAbility4UnlockLevel = 8;
        [FieldAttr(32)] public int _optionalAbility1UnlockLevel = 10;
        [FieldAttr(36)] public int _optionalAbility2UnlockLevel = 12;
        [FieldAttr(40)] public int _optionalAbility3UnlockLevel = 14;
        [FieldAttr(44)] public int _soulGemAbilityUnlockLevel = 16;
        [FieldAttr(48)] public int _wowPowAbilityUnlockLevel = 18;
    }
}
