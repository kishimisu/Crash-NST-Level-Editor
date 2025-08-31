namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CAmbientAudioComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public igHandleMetaField _sound = new();
        [FieldAttr(32)] public igHandleMetaField _dopplerData = new();
        [FieldAttr(40)] public float _minRepeatDelay = 5.0f;
        [FieldAttr(44)] public float _maxRepeatDelay = 10.0f;
        [FieldAttr(48)] public bool _soundPlayingMatchesHiddenState;
        [FieldAttr(49)] public bool _startActive = true;
    }
}
