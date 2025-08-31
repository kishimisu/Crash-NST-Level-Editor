namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class CVoiceOverLocalizedLineInstance : igObject
    {
        [FieldAttr(16)] public CLocalizedLine? _localizedLine;
        [FieldAttr(24)] public igVscDelegateMetaField _started = new();
        [FieldAttr(40)] public igVscDelegateMetaField _finished = new();
        [FieldAttr(56)] public igVscDelegateMetaField _aborted = new();
        [FieldAttr(72)] public CGameSoundInstance? _gameSoundInstance;
        [FieldAttr(80)] public igHandleMetaField _subtitlesProject = new();
        [FieldAttr(88)] public CScopedScheduledFunction? _textDelay;
        [FieldAttr(96)] public COnFinishedEventList? _onFinishedEventList;
    }
}
