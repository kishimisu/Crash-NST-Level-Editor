namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class common_LevelEndScene_CrateHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public EigEaseType _DropEaseType;
        [FieldAttr(nst: 44, ctr: 36)] public float _DropTime;
        [FieldAttr(nst: 48, ctr: 40)] public float _DropEaseRatioIn;
        [FieldAttr(nst: 52, ctr: 44)] public float _DropEaseRatioOut;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _SfxCrateDestroyData = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _VfxCrateDestroyData = new();
    }
}
