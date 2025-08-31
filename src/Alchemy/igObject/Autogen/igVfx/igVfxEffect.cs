namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igVfxEffect : igVfxPrimitiveDataList
    {
        public enum EInvalidBoltBehavior : uint
        {
            kSoftKill = 0,
            kHardKill = 1,
            kContinue = 2,
        }

        public enum ECameraVisibility : uint
        {
            kAllCameras = 0,
            kPlayerSpecific = 1,
        }

        public enum EPriorityClass : uint
        {
            kLowPriority = 0,
            kMediumPriority = 1,
            kHighPriority = 2,
        }

        [ObjectAttr(4)]
        public class EffectFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 2)] public igVfxEffect.EInvalidBoltBehavior _invalidBoltBehavior;
            [FieldAttr(2, size: 1)] public bool _playOutLoopOnSoftKill;
            [FieldAttr(3, size: 1)] public bool _keepBoltScale = false;
            [FieldAttr(4, size: 1)] public bool _keepBoltVisibility = false;
            [FieldAttr(5, size: 1)] public bool _softCull;
            [FieldAttr(6, size: 1)] public bool _pauseAfterSoftCull = false;
            [FieldAttr(7, size: 2)] public igVfxEffect.ECameraVisibility _cameraVisibility;
            [FieldAttr(9, size: 1)] public bool _forceLateUpdate;
            [FieldAttr(10, size: 1)] public bool _useLevelCameraCullDistance = false;
            [FieldAttr(11, size: 2)] public igVfxEffect.EPriorityClass _priority = igVfxEffect.EPriorityClass.kLowPriority;
        }

        [FieldAttr(40)] public igTimeMetaField _loopStart = new();
        [FieldAttr(44)] public igTimeMetaField _loopEnd = new();
        [FieldAttr(48)] public EffectFlags _effectFlags = new();
        [FieldAttr(52)] public float _cameraCullDistance = -1.0f;
        [FieldAttr(56)] public float _effectViewBounds = 1000.0f;
        [FieldAttr(60)] public float _hardCullPauseDelay;
        [FieldAttr(64)] public float _windupTime;
        [FieldAttr(68)] public float _windupTick;
        [FieldAttr(72)] public igVfxManager.ESpawnGroup _spawnGroup;
        [FieldAttr(76)] public uint _seed;
    }
}
