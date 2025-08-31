namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CRotationLocalToWorldNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscObjectAccessor? _target;
        [FieldAttr(24)] public igVscVec3fAccessor? _rotation;
        [FieldAttr(32)] public igVscVec3fAccessor? _result;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
