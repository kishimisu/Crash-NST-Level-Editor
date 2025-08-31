namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igVscSendMessageNode : igVscActionNode
    {
        [FieldAttr(16, false)] public igMetaObjectInstance? _messageMetaObject;
        [FieldAttr(24)] public igVscObjectAccessor? _target;
        [FieldAttr(32)] public igVscAccessorList? _accessors;
        [FieldAttr(40)] public igVectorMetaField<igMetaFieldInstance> _metaFields = new();
        [FieldAttr(64)] public bool _isPrivateMessage;
        [FieldAttr(72, false)] public igVscActionNode? _out;
    }
}
