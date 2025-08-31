namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CAttackRegionShape : igObject
    {
        [FieldAttr(16)] public CShape? _shape;
        [FieldAttr(24)] public CBoltPoint? _boltPoint;
        [FieldAttr(32)] public igVec3fMetaField _offset = new();
        [FieldAttr(44)] public int _maximumQueryResults = -1;
    }
}
