namespace Alchemy
{
    [ObjectAttr(448, 8)]
    public class CRenderConstantBundles : CRenderBaseConstantBundles
    {
        [FieldAttr(128)] public igObject[] _velocityConstantBundle = new igObject[2];
        [FieldAttr(144)] public igObject[] _obscuredConstantBundle = new igObject[2];
        [FieldAttr(160)] public igObject[] _skyboxConstantBundle = new igObject[2];
        [FieldAttr(176)] public igObject[] _bloomConstantBundle = new igObject[2];
        [FieldAttr(192)] public igObject[] _pixelCostConstantBundle = new igObject[2];
        [FieldAttr(208)] public igObject[] _heroShadowsFullscreenBundle = new igObject[2];
        [FieldAttr(224)] public igObject[] _sceneShadowBundle = new igObject[2];
        [FieldAttr(240)] public igObject[] _timeBundle = new igObject[2];
        [FieldAttr(256)] public igObject[] _defocusConstantBundle = new igObject[2];
        [FieldAttr(272)] public igObject[] _depthEncodingBundle = new igObject[2];
        [FieldAttr(288)] public igObject[] _cloudShadingBundle = new igObject[2];
        [FieldAttr(304)] public igObject[] _globalNormalMapScale = new igObject[2];
        [FieldAttr(320)] public igObject[] _linearDepthBundle = new igObject[2];
        [FieldAttr(336)] public igObject[] _sceneViewInverseBundle = new igObject[2];
        [FieldAttr(352)] public igObject[] _bilateralDepthToleranceBundle = new igObject[2];
        [FieldAttr(368)] public igObject[] _ambientBakeInfluenceBundle = new igObject[2];
        [FieldAttr(384)] public igObject[] _toonBundle = new igObject[2];
        [FieldAttr(400)] public igObject[] _vfxQualityBundle = new igObject[2];
        [FieldAttr(416)] public igObject[] _mobileLightRig = new igObject[2];
        [FieldAttr(432)] public igObject[] _furBlurConstantBundle = new igObject[2];
    }
}
