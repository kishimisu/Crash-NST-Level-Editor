namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscCppCompoundNode : igVscPlaceable
    {
        [FieldAttr(16)] public igVectorMetaField<igVscAccessor> _accessors = new();
        [FieldAttr(40, false)] public igVscActionNode? _out;
        [FieldAttr(48)] public igVscActionNodeList? _outNodes;
    }
}
