namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CBehaviorActivatorNode : igNamedObject
    {
        [FieldAttr(24)] public igRawRefMetaField _havokStateMachine = new();
        [FieldAttr(32)] public int _stateId = -1;
        [FieldAttr(40, false)] public CBehaviorActivatorNode? _parent;
    }
}
