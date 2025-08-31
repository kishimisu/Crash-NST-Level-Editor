namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CHavokConstraintData : igObject
    {
        [FieldAttr(16)] public CBoltPoint? _parentBolt;
        [FieldAttr(24)] public CBoltPoint? _childBolt;
    }
}
