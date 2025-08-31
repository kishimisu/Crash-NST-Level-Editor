namespace Alchemy
{
    [ObjectAttr(128, 4)]
    public class CReticleTargeterDifficultyData : igObject
    {
        [FieldAttr(16)] public float _easyPrimaryReticleScale = 1.0f;
        [FieldAttr(20)] public igVec2fMetaField _easyBoxAcquireTargetingExtents = new();
        [FieldAttr(28)] public igVec2fMetaField _easyBoxDropTargetingExtents = new();
        [FieldAttr(36)] public float _easyCircleAcquireTargetingRadius = 120.0f;
        [FieldAttr(40)] public float _easyCircleDropTargetingRadius = 240.0f;
        [FieldAttr(44)] public float _mediumPrimaryReticleScale = 1.0f;
        [FieldAttr(48)] public igVec2fMetaField _mediumBoxAcquireTargetingExtents = new();
        [FieldAttr(56)] public igVec2fMetaField _mediumBoxDropTargetingExtents = new();
        [FieldAttr(64)] public float _mediumCircleAcquireTargetingRadius = 120.0f;
        [FieldAttr(68)] public float _mediumCircleDropTargetingRadius = 240.0f;
        [FieldAttr(72)] public float _hardPrimaryReticleScale = 1.0f;
        [FieldAttr(76)] public igVec2fMetaField _hardBoxAcquireTargetingExtents = new();
        [FieldAttr(84)] public igVec2fMetaField _hardBoxDropTargetingExtents = new();
        [FieldAttr(92)] public float _hardCircleAcquireTargetingRadius = 120.0f;
        [FieldAttr(96)] public float _hardCircleDropTargetingRadius = 240.0f;
        [FieldAttr(100)] public float _nightmarePrimaryReticleScale = 1.0f;
        [FieldAttr(104)] public igVec2fMetaField _nightmareBoxAcquireTargetingExtents = new();
        [FieldAttr(112)] public igVec2fMetaField _nightmareBoxDropTargetingExtents = new();
        [FieldAttr(120)] public float _nightmareCircleAcquireTargetingRadius = 120.0f;
        [FieldAttr(124)] public float _nightmareCircleDropTargetingRadius = 240.0f;
    }
}
