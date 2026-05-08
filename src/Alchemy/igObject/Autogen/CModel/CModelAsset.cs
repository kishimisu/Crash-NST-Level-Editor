namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 48, align: 8)]
    public class CModelAsset : CAsset
    {
        [FieldAttr(nst: 24, ctr: 24)] public CModelAnimationDatabase? _modelAnimations;
        [FieldAttr(nst: 32, ctr: 32)] public igModelData? _root;
        [FieldAttr(nst: 40, ctr: 40)] public u64 _techniqueMask;
    }
}
