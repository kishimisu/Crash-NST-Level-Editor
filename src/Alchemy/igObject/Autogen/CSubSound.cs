namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CSubSound : igObject
    {
        [FieldAttr(16)] public string? _fileName = null;
        [FieldAttr(24)] public float _volume = 1.0f;
        [FieldAttr(28)] public u16 _sampleRate = 48000;
        [FieldAttr(30)] public i8 _quality = 40;
        [FieldAttr(31)] public bool _externalSource;
        [FieldAttr(32)] public uint _externalBufferSize;
        [FieldAttr(36)] public uint _externalDecodeBufferSamples;
        [FieldAttr(40)] public igSound? _igSound;
        [FieldAttr(48)] public igSound? _parentIgSound;
        [FieldAttr(56)] public u8 _ref;
        [FieldAttr(57)] public bool _dirty;
        [FieldAttr(58)] public bool _usesVisemes;
    }
}
