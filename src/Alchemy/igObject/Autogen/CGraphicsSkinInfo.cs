namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CGraphicsSkinInfo : igInfo
    {
        [FieldAttr(40)] public igSkeleton2? _skeleton;
        [FieldAttr(48)] public igModelData? _skin;
        [FieldAttr(56)] public igStringIntHashTable? _boltPointIndexArray;
        [FieldAttr(64)] public CHavokSkeleton? _havokSkeleton;
        [FieldAttr(72)] public igVec3fMetaField _boundsMin = new();
        [FieldAttr(84)] public igVec3fMetaField _boundsMax = new();
    }
}
