namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscMessageDelegator : igVscDelegator
    {
        [FieldAttr(24, false)] public igMetaObjectInstance? _messageMetaObject;
        [FieldAttr(32)] public igVscObjectAccessor? _target;
        [FieldAttr(40)] public bool _isPrivateMessage;
    }
}
