namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igAnimatedMorphWeights : igObject
    {
        [FieldAttr(16)] public igVectorMetaField<float> _data = new();
        [FieldAttr(40)] public igVectorMetaField<float> _times = new();
        [FieldAttr(64)] public int _targetCount;
        [FieldAttr(68)] public float _duration = -1.0f;
        [FieldAttr(72)] public float _keyframeTimeOffset;
        [FieldAttr(76)] public EIG_UTILS_PLAY_MODE _playMode;
    }
}
