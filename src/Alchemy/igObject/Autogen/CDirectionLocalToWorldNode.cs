namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CDirectionLocalToWorldNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscObjectAccessor? _target;
        [FieldAttr(24)] public igVscVec3fAccessor? _vector;
        [FieldAttr(32)] public igVscVec3fAccessor? _result;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
