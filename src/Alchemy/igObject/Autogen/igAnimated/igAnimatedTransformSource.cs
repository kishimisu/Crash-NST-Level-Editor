namespace Alchemy
{
    [ObjectAttr(128, 16)]
    public class igAnimatedTransformSource : igObject
    {
        [FieldAttr(16)] public int _dataStride;
        [FieldAttr(32)] public igVectorMetaField<float> _data = new();
        [FieldAttr(56)] public igVectorMetaField<float> _times = new();
        [FieldAttr(80)] public float _duration = 259200.0f;
        [FieldAttr(84)] public float _keyframeTimeOffset;
        [FieldAttr(88)] public uint _componentChannels;
        [FieldAttr(92)] public u8[] _channelOffsets = new u8[3];
        [FieldAttr(95)] public u8[] _interpolationMethod = new u8[3];
        [FieldAttr(100)] public EIG_UTILS_PLAY_MODE _playMode;
        [FieldAttr(112)] public igVec4fMetaField _centerOfRotation = new();
    }
}
