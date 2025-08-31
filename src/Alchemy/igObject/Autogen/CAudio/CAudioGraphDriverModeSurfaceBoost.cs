namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CAudioGraphDriverModeSurfaceBoost : CAudioGraphDriverModeTargetBased
    {
        [FieldAttr(72)] public igHandleMetaField _boostActivationSound = new();
        [FieldAttr(80)] public igHandleMetaField _boostLoopingSound = new();
        [FieldAttr(88)] public igHandleMetaField _playingBoostLoopingSound = new();
    }
}
