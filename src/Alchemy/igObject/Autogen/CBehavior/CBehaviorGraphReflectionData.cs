namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CBehaviorGraphReflectionData : igObject
    {
        [FieldAttr(16)] public bool _runtimeDataFilledIn;
        [FieldAttr(24)] public CCharacterClipMap? _clips;
        [FieldAttr(32)] public CBehaviorStateMachineList? _stateMachines;
        [FieldAttr(40)] public igUnsignedIntIntHashTable? _eventMap;
        [FieldAttr(48)] public igUnsignedIntIntHashTable? _variableMap;
        [FieldAttr(56)] public CBehaviorActivatorNodeMap? _activatorNodeMap;
        [FieldAttr(64)] public CBehaviorLayerGenerator? _layerGenerator;
        [FieldAttr(72)] public CBehaviorDockingGenerator? _dockingGenerator;
        [FieldAttr(80)] public float _runClipExtractedMotionSpeed;
    }
}
