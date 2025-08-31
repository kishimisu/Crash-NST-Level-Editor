namespace Alchemy
{
    [ObjectAttr(144, 8)]
    public class CChannelGroup : igObject
    {
        [ObjectAttr(4)]
        public class ComputeLoudness : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _computeLoudnessOnDurango;
            [FieldAttr(1, size: 1)] public bool _computeLoudnessOnPS4;
            [FieldAttr(2, size: 1)] public bool _computeLoudnessOnWindows;
        }

        [FieldAttr(16)] public string? _name = "NOT_SET";
        [FieldAttr(24)] public u8 _defaultVolume = 255;
        [FieldAttr(25)] public u8 _defaultPitch = 127;
        [FieldAttr(32)] public CChannelGroupList? _grpList;
        [FieldAttr(40)] public CDspList? _dspList;
        [FieldAttr(48)] public bool _mute;
        [FieldAttr(49)] public bool _solo;
        [FieldAttr(52)] public ComputeLoudness _computeLoudness = new();
        [FieldAttr(56)] public igRawRefMetaField _channelGroup = new();
        [FieldAttr(64)] public igRawRefMetaField _loudnessDsp = new();
        [FieldAttr(72)] public float[] _volumeArray = new float[7];
        [FieldAttr(100)] public float[] _pitchArray = new float[7];
        [FieldAttr(128)] public float _computedLoudness;
        [FieldAttr(136)] public igHandleMetaField _parent = new();
    }
}
