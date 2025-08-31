namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscMultiplyScalarVec2fNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscFloatAccessor? _a;
        [FieldAttr(24)] public igVscVec2fAccessor? _b;
        [FieldAttr(32)] public igVscVec2fAccessor? _return;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
