namespace Alchemy
{
    [ObjectAttr(288, 16)]
    public class CPreRenderUpdatePassBase : igRenderPass
    {
        [FieldAttr(56)] public igShaderConstantBundleList? _bundlesToApply;
        [FieldAttr(64)] public igShaderConstantBundleList? _dynamicBundlesToApply;
        [FieldAttr(72)] public int _bundleWriteIndex;
        [FieldAttr(80)] public CRenderConstantBundles? _renderBundles;
        [FieldAttr(88)] public igSortKeyCommandDelegateObject? _passDelegate;
        [FieldAttr(96)] public CForwardLitRenderPassData? _globalLightingData;
        [FieldAttr(104)] public igRenderDirectionalLight? _sunLight;
        [FieldAttr(112)] public CSkyRenderPassData? _nearSkyLightingData;
        [FieldAttr(120)] public CSkyRenderPassData? _farSkyLightingData;
        [FieldAttr(128)] public CSkyboxRenderPassData? _skyboxData;
        [FieldAttr(136)] public igHandleMetaField _ambientAtmosphereEffect = new();
        [FieldAttr(144)] public igHandleMetaField _nearParallaxDataHandle = new();
        [FieldAttr(160)] public igMatrix44fMetaField _viewPrevious = new();
        [FieldAttr(224)] public igMatrix44fMetaField _viewInversePrevious = new();
    }
}
