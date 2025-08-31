namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscMultiplyVec3fScalarNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec3fAccessor? _a;
        [FieldAttr(24)] public igVscFloatAccessor? _b;
        [FieldAttr(32)] public igVscVec3fAccessor? _return;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
