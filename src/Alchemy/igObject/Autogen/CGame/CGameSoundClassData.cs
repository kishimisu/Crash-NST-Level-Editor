namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CGameSoundClassData : igObject
    {
        [FieldAttr(16)] public string? _name = null;
        [FieldAttr(24)] public EGameSoundClassPlayBehavior _higherPriorityPlayingBehavior;
        [FieldAttr(28)] public EGameSoundClassPlayBehavior _samePriorityPlayingBehavior;
        [FieldAttr(32)] public EGameSoundClassPlayBehavior _cooldownPlayingBehavior;
        [FieldAttr(36)] public int _maxQueue = 2;
        [FieldAttr(40)] public float _cooldown;
        [FieldAttr(44)] public float _timeout = -1.0f;
        [FieldAttr(48)] public float _initialFadeVolume = 0.31f;
        [FieldAttr(52)] public float _initialFadeDuration = 0.125f;
        [FieldAttr(56)] public float _fadeOutDuration = 0.25f;
        [FieldAttr(60)] public bool _hardStopLowerPriorityStreamsOnPlayAttempt;
    }
}
