namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CCombatSoundData : igObject
    {
        [FieldAttr(16)] public bool _playAttackSoundOnVictim = true;
        [FieldAttr(24)] public string? _attackSound = null;
        [FieldAttr(32)] public string? _victimSound = "COM_Impact_Victim_Basic";
        [FieldAttr(40)] public igHandleMetaField _attackSoundHandle = new();
        [FieldAttr(48)] public igHandleMetaField _victimSoundHandle = new();
        [FieldAttr(56)] public CUpgradeableSound? _attackSoundUpgradeable;
        [FieldAttr(64)] public CUpgradeableSound? _victimSoundUpgradeable;
    }
}
