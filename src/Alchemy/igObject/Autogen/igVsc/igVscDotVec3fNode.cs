namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscDotVec3fNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec3fAccessor? _vectorA;
        [FieldAttr(24)] public igVscVec3fAccessor? _vectorB;
        [FieldAttr(32)] public igVscFloatAccessor? _result;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
