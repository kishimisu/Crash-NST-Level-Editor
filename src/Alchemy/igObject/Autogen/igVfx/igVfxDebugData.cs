namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igVfxDebugData : igObject
    {
        [FieldAttr(16)] public bool _spawnInvisiblePrimitives;
        [FieldAttr(17)] public bool _usePriorities = true;
        [FieldAttr(18)] public bool _hardKill = true;
        [FieldAttr(19)] public bool _drawDebugFrames;
        [FieldAttr(20)] public uint _filmstripRepeat;
        [FieldAttr(24)] public igVfxBolt.ECullType _forceCull;
        [FieldAttr(28)] public uint _debugVisualizationLevel;
        [FieldAttr(32)] public string? _debugBoltBoneName = "";
        [FieldAttr(40)] public string? _debugBolt2BoneName = "";
        [FieldAttr(48)] public igVec3fMetaField _debugBoltOffset = new();
        [FieldAttr(60)] public bool _debugBolt1UseManipulator;
        [FieldAttr(61)] public bool _debugBolt2UseManipulator;
        [FieldAttr(62)] public bool _debugBoltsHideManipulators;
        [FieldAttr(64)] public u16 _spawnLayers = 65535;
        [FieldAttr(66)] public bool _showBoltsOnSelection;
        [FieldAttr(67)] public bool _boltSelectionMode;
    }
}
