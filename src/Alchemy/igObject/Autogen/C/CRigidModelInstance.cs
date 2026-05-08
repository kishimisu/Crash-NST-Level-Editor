namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 112, align: 8)]
    public class CRigidModelInstance : CModelInstance
    {
        [FieldAttr(nst: 72, ctr: 72, refCount: false)] public CModelAsset? _modelAsset;
        [FieldAttr(nst: 80, ctr: 80)] public CRigidAnimCtrl? mRigidAnimCtrl;
        [FieldAttr(nst: 88, ctr: 88)] public CScopedScheduledFunction? _cycleComplete;
        [FieldAttr(ctr: 96)] public string? _modelClass;
        [FieldAttr(ctr: 104)] public string? _modelClassForFading;
    }
}
