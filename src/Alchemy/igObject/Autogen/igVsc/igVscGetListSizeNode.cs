namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscGetListSizeNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscObjectAccessor? _list;
        [FieldAttr(24)] public igVscIntAccessor? _size;
        [FieldAttr(32, false)] public igVscActionNode? _out;
    }
}
