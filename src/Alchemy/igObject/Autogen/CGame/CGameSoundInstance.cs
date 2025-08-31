namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CGameSoundInstance : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _soundInstance = new();
        [FieldAttr(24)] public igVscDelegateMetaField _playDelegate = new();
        [FieldAttr(40)] public igVscDelegateMetaField _stopDelegate = new();
        [FieldAttr(56)] public bool _queued;
        [FieldAttr(57)] public bool _toRemove;
        [FieldAttr(60)] public float _pendingPitch = -1.0f;
        [FieldAttr(64)] public float _pendingPitchBlendDuration;
        [FieldAttr(72)] public COnGameSoundInstancePlayEventList? _onPlayEventList;
    }
}
