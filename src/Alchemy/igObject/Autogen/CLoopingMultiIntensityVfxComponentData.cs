namespace Alchemy
{
    [ObjectAttr(120, 8)]
    public class CLoopingMultiIntensityVfxComponentData : CLoopingVfxComponentData
    {
        [FieldAttr(80)] public igHandleMetaField _effect_1 = new();
        [FieldAttr(88)] public igHandleMetaField _multiIntensityVfxEffect = new();
        [FieldAttr(96)] public VfxIntensityLayersList? _intensityLayers;
        [FieldAttr(104)] public igHandleMetaField _managerComponentEntity = new();
        [FieldAttr(112)] public CMultiIntensityVfxManagerComponentData? _managerComponentData;
    }
}
