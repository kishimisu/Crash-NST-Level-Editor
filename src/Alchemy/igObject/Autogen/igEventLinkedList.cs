namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igEventLinkedList : igObject
    {
        [FieldAttr(16)] public igRawRefMetaField _head = new();
        [FieldAttr(24)] public igRawRefMetaField _nextPtr = new();
    }
}
