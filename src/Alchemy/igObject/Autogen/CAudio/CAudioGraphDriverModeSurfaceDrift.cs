namespace Alchemy
{
    [ObjectAttr(144, 8)]
    public class CAudioGraphDriverModeSurfaceDrift : CAudioGraphDriverModeStickBased
    {
        [FieldAttr(80)] public igHandleMetaField _driftLoopingSound = new();
        [FieldAttr(88)] public igHandleMetaField _driftActivateSound = new();
        [FieldAttr(96)] public igHandleMetaField _driftDeactivateSound = new();
        [FieldAttr(104)] public float _driftLoopingSoundMinVolume = 0.3f;
        [FieldAttr(108)] public float _driftLoopingSoundVolumeChangePerSecond = 2.0f;
        [FieldAttr(112)] public bool _onlyPlaySoundsOnGround = true;
        [FieldAttr(120)] public igHandleMetaField _playingDriftLoopingSound = new();
        [FieldAttr(128)] public float _driftLoopingSoundInitialVolume;
        [FieldAttr(132)] public float _driftLoopingSoundTargetVolume;
        [FieldAttr(136)] public float _driftLoopingSoundCurrentVolume;
    }
}
