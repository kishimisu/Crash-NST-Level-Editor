namespace Alchemy
{
    [ObjectAttr(56, 8, metaObject: true)]
    public class igVscMacroCallNode : igVscActionNode
    {
        [FieldAttr(16, false)] public igVscActionNode? _instancedNode;
        [FieldAttr(24)] public igObjectList? _instancedNodes;
        [FieldAttr(32, false)] public igVscActionNode? _out;
        [FieldAttr(40)] public igRawRefMetaField _dynamicFieldMemory = new();
        [FieldAttr(48, false)] public igMetaObject? _meta = (null);
    }
}
