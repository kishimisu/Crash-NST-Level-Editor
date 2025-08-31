namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class CModSoundData : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _mod = new();
        [FieldAttr(24)] public int _priority;
        [FieldAttr(32)] public igHandleMetaField _rightTriggerPressedSound = new();
        [FieldAttr(40)] public igHandleMetaField _rightTriggerHeldLoopingSound = new();
        [FieldAttr(48)] public igHandleMetaField _rightTriggerReleasedSound = new();
        [FieldAttr(56)] public igHandleMetaField _rightTriggerNotHeldLoopingSound = new();
        [FieldAttr(64)] public igHandleMetaField _gearShiftOverrideSound = new();
        [FieldAttr(72)] public igHandleMetaField _driftActivatedOverrideSound = new();
        [FieldAttr(80)] public igHandleMetaField _driftActiveOverrideLoopingSound = new();
        [FieldAttr(88)] public igHandleMetaField _driftDeactivatedOverrideSound = new();
        [FieldAttr(96)] public igHandleMetaField _boostActivatedOverrideSound = new();
        [FieldAttr(104)] public igHandleMetaField _boostActiveOverrideLoopingSound = new();
        [FieldAttr(112)] public CAudioGraphHandleList? _enabledGraphs;
        [FieldAttr(120)] public CAudioGraphModuleOverrideList? _moduleOverrides;
    }
}
