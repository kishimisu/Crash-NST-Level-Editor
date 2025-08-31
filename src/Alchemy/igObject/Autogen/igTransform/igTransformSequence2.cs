namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class igTransformSequence2 : igTransformSource2Keyframed
    {
        [FieldAttr(24)] public igIntList? _timeList;
        [FieldAttr(32)] public igVec3fList? _translationList;
        [FieldAttr(40)] public igQuaternionfList? _quaternionList;
        [FieldAttr(48)] public igVec3fList? _scaleList;
        [FieldAttr(56)] public igVec3fList? _shearList;
        [FieldAttr(64)] public igVec3fMetaField _centerOfRotation = new();
        [FieldAttr(76)] public int _timeOffset;
        [FieldAttr(80)] public int _duration = -1;
        [FieldAttr(84)] public EIG_UTILS_PLAY_MODE _playMode;
        [FieldAttr(88)] public u8[] _interpolation = new u8[5];
        [FieldAttr(93)] public u8 _supportedTransforms;
        [FieldAttr(96)] public int _lastTime;
    }
}
