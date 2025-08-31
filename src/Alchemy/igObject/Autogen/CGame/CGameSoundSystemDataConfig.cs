namespace Alchemy
{
    [ObjectAttr(232, 8)]
    public class CGameSoundSystemDataConfig : CSoundSystemDataConfig
    {
        [FieldAttr(152)] public float _binkVolumeDurango = 1.0f;
        [FieldAttr(156)] public float _binkVolumePs4 = 1.0f;
        [FieldAttr(160)] public float _binkVolumeWiiU = 1.0f;
        [FieldAttr(164)] public float _binkVolumeWindows = 1.0f;
        [FieldAttr(168)] public CAudioBinkSettingsList? _audioBinkSettingsList;
        [FieldAttr(176)] public float _traversalTrack1Volume = 1.0f;
        [FieldAttr(180)] public float _traversalAccelerationSmoothing = 97.0f;
        [FieldAttr(184)] public float _traversalDecelerationSmoothing = 99.59999847f;
        [FieldAttr(188)] public float _traversalZeroVolumeSpeed = 100.0f;
        [FieldAttr(192)] public float _traversalFullVolumeSpeed = 200.0f;
        [FieldAttr(196)] public float traversalMaxSpeed = 210.0f;
        [FieldAttr(200)] public float _windGustThreshold = 0.3f;
        [FieldAttr(208)] public igStringRefList? _queuePrefixes;
        [FieldAttr(216)] public float _splitscreenAudioAttenuationFactor = 0.5f;
        [FieldAttr(224)] public CGameSoundClassList? _soundClassList;
    }
}
