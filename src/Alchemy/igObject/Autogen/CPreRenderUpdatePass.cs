namespace Alchemy
{
    [ObjectAttr(640, 16)]
    public class CPreRenderUpdatePass : CPreRenderUpdatePassBase
    {
        [FieldAttr(288)] public int _updatePassIndex = -1;
        [FieldAttr(292)] public float _cameraAspectRatioMultiplier = 1.0f;
        [FieldAttr(296)] public float _viewportRelativeX;
        [FieldAttr(300)] public float _viewportRelativeWidth = 1.0f;
        [FieldAttr(304)] public float _viewportRelativeY;
        [FieldAttr(308)] public float _viewportRelativeHeight = 1.0f;
        [FieldAttr(312)] public string? _cameraName = "main";
        [FieldAttr(320)] public igHandleMetaField _composeSceneRenderPass = new();
        [FieldAttr(328)] public igHandleMetaField _pointLightsHandle = new();
        [FieldAttr(336)] public bool _isReflectionPass;
        [FieldAttr(340)] public int _unreflectedCameraPassIndex = -1;
        [FieldAttr(344)] public igModelInstance.EViewportID _viewportID;
        [FieldAttr(352)] public igHandleMetaField _cameraSystemInstanceHandle = new();
        [FieldAttr(360)] public igRenderCamera? _renderCamera;
        [FieldAttr(368)] public igObject[] _cameraPlanes = new igObject[6];
        [FieldAttr(416)] public igAABox? _cameraNearBox;
        [FieldAttr(424)] public igVec3fMetaField _hero1CloudFadePositionNear = new();
        [FieldAttr(436)] public igVec3fMetaField _hero2CloudFadePositionNear = new();
        [FieldAttr(448)] public igVec3fMetaField _hero1CloudFadePositionFar = new();
        [FieldAttr(460)] public igVec3fMetaField _hero2CloudFadePositionFar = new();
        [FieldAttr(472)] public igHandleMetaField _cascadeShadowRenderDataHandle = new();
        [FieldAttr(480)] public igHandleMetaField _projectiveShadowRenderDataHandle = new();
        [FieldAttr(488)] public igRenderAuxiliaryCullingParameters? _auxiliaryCullingParameters;
        [FieldAttr(496)] public igRenderLodParameters? _lodParameters;
        [FieldAttr(504)] public igHandleMetaField _heroShadowDataHandle = new();
        [FieldAttr(512)] public igRay? _heroShadowRay;
        [FieldAttr(520)] public igRenderCamera? _hero1ShadowCamera;
        [FieldAttr(528)] public igRenderCamera? _hero2ShadowCamera;
        [FieldAttr(536)] public igAABox? _heroShadowIntersectionBox;
        [FieldAttr(544)] public string? _hero1ShadowString = null;
        [FieldAttr(552)] public string? _hero2ShadowString = null;
        [FieldAttr(560)] public string? _parametersString = null;
        [FieldAttr(568)] public string? _sunString = null;
        [FieldAttr(576)] public igSceneRenderPassEnableData? _depthOfFieldEnableData;
        [FieldAttr(584)] public igSceneRenderPassEnableData? _toonEnableData;
        [FieldAttr(592)] public igSceneRenderPassEnableData? _obscuredEnableData;
        [FieldAttr(600)] public igSceneRenderPassEnableData? _waterSimuluationEnableData;
        [FieldAttr(608)] public igSceneRenderPassEnableData? _sunshaftEnableData;
        [FieldAttr(616)] public igSceneRenderPassEnableData? _highResolutionVfxEnableData;
        [FieldAttr(624)] public bool _isEnabled = true;
        [FieldAttr(632)] public igRenderPassList? _flattenedChildren;
    }
}
