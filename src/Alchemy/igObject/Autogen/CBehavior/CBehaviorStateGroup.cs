namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CBehaviorStateGroup : igObject
    {
        [FieldAttr(16)] public CBehaviorActivatorNodeHandleList? _activatorStates;
        [FieldAttr(24)] public CBehaviorActivatorNodeHandleList? _deactivatorStates;
    }
}
