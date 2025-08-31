namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CSoundGroup : igObject
    {
        [FieldAttr(16)] public string? _name = null;
        [FieldAttr(24)] public uint _maxPlaybacks;
        [FieldAttr(28)] public ESoundGroupPlaybackBehavior _behaviour = ESoundGroupPlaybackBehavior.eSGPB_Mute;
        [FieldAttr(32)] public float _fade = 0.75f;
        [FieldAttr(36)] public u8 _priority = 64;
        [FieldAttr(37)] public bool _mute;
        [FieldAttr(38)] public bool _solo;
        [FieldAttr(40)] public igRawRefMetaField _soundGroup = new();
    }
}
