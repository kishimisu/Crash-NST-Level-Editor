namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CVfxDrawSoundOperator : igVfxDrawOperator
    {
        [FieldAttr(32)] public igHandleMetaField _attackSound = new();
        [FieldAttr(40)] public igHandleMetaField _sustainSound = new();
        [FieldAttr(48)] public igHandleMetaField _releaseSound = new();
        [FieldAttr(56)] public string? _attackSoundName = null;
        [FieldAttr(64)] public string? _sustainSoundName = null;
        [FieldAttr(72)] public string? _releaseSoundName = null;
        [FieldAttr(80)] public bool _stopOneShotsOnEnd;
        [FieldAttr(84)] public float _updateFrequency = 1.0f;
        [FieldAttr(88)] public u32 /* igStructMetaField */ _primitiveData;
    }
}
