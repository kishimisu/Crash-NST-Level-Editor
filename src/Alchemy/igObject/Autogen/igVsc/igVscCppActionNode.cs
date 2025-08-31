namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igVscCppActionNode : igVscActionNode
    {
        [FieldAttr(16)] public igVectorMetaField<igVscAccessor> _accessors = new();
        [FieldAttr(40, false)] public igVscActionNode? _out;
        [FieldAttr(48)] public igVscActionNodeList? _outNodes;
        [FieldAttr(56, false)] public igMetaFunction? _metaFunction;
    }
}
