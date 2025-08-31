namespace Alchemy
{
    // VSC object extracted from: common_LevelEndScene_CrateHandler_c.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class common_LevelEndScene_CrateHandlerData : CVscComponentData
    {
        [FieldAttr(40)] public EigEaseType _DropEaseType;
        [FieldAttr(44)] public float _DropTime;
        [FieldAttr(48)] public float _DropEaseRatioIn;
        [FieldAttr(52)] public float _DropEaseRatioOut;
        [FieldAttr(56)] public igHandleMetaField _SfxCrateDestroyData = new();
        [FieldAttr(64)] public igHandleMetaField _VfxCrateDestroyData = new();
    }
}
