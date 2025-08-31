namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CNetworkAnimationStateEntryTable : igObject
    {
        [FieldAttr(16)] public igStringRefList? _prerequisiteStates;
        [FieldAttr(24)] public string? _mainStateEntryEvent = null;
        [FieldAttr(32)] public string? _mainStateExitEvent = null;
        [FieldAttr(40)] public string? _componentSetStateMethod = null;
        [FieldAttr(48)] public string? _componentGetStateMethod = null;
        [FieldAttr(56)] public igStringRefList? _subStates;
        [FieldAttr(64, false)] public igMetaObject? _componentTypeSetState;
        [FieldAttr(72, false)] public igMetaFunction? _componentSetStateFunction;
        [FieldAttr(80, false)] public igMetaObject? _componentTypeGetState;
        [FieldAttr(88, false)] public igMetaFunction? _componentGetStateFunction;
    }
}
