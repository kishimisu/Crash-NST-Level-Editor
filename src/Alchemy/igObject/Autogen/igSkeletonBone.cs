namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igSkeletonBone : igNamedObject
    {
        [FieldAttr(24)] public int _parentIndex;
        [FieldAttr(28)] public int _blendMatrixIndex = -1;
        [FieldAttr(32)] public igVec3fMetaField _translation = new();
    }
}
