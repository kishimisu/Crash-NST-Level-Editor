namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscArcCosNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscFloatAccessor? _cosine;
        [FieldAttr(24)] public igVscFloatAccessor? _angle;
        [FieldAttr(32, false)] public igVscActionNode? _out;
    }
}
