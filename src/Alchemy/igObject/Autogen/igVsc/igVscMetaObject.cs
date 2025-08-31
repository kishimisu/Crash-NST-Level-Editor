namespace Alchemy
{
    [ObjectAttr(200, 8)]
    public class igVscMetaObject : igDynamicMetaObject
    {
        [FieldAttr(152, false)] public igVscMethodList? _exposedMethods;
        [FieldAttr(160, false)] public igVscDelegatorList? _delegators;
        [FieldAttr(168)] public igRawRefMetaField _delegatesEnabledCallback = new();
        [FieldAttr(176, false)] public igMetaObjectInstance? _dataMeta;
        [FieldAttr(184)] public igVscDelegatorList? _privateMessageDelegatorList;
        [FieldAttr(192)] public bool _registeredPrivateMessages;
    }
}
