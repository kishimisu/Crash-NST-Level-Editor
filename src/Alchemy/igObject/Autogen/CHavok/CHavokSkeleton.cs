namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CHavokSkeleton : igObject
    {
        [FieldAttr(16)] public igSkeleton2? _alchemySkeleton;
        [FieldAttr(24)] public igRawRefMetaField _havokSkeleton = new();
        [FieldAttr(32)] public igIntIntHashTable? _boneIndexMap;
        [FieldAttr(40)] public int _loadCount;
    }
}
