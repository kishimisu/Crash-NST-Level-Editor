namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscCppCompoundActionNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscPlaceable? _compoundNode;
        [FieldAttr(24, false)] public igMetaFunction? _metaFunction;
    }
}
