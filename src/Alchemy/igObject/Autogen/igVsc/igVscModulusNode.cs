namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscModulusNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscFloatAccessor? _input;
        [FieldAttr(24)] public igVscFloatAccessor? _modulus;
        [FieldAttr(32)] public igVscFloatAccessor? _result;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
