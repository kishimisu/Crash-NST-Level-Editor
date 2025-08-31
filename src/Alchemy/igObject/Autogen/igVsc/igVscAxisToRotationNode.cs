namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igVscAxisToRotationNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec3fAccessor? _forward;
        [FieldAttr(24)] public igVscVec3fAccessor? _left;
        [FieldAttr(32)] public igVscVec3fAccessor? _up;
        [FieldAttr(40)] public igVscIntAccessor? _primaryAxis;
        [FieldAttr(48)] public igVscIntAccessor? _secondaryAxis;
        [FieldAttr(56)] public igVscVec3fAccessor? _result;
        [FieldAttr(64, false)] public igVscActionNode? _out;
    }
}
