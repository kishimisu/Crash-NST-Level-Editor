namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class igGuiVscSendEventNode : igVscSendMessageNode
    {
        [FieldAttr(80)] public igVscBoolAccessor? _sendToChildren;
    }
}
