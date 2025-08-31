namespace Alchemy
{
    [ObjectAttr(416, 16)]
    public class CCamera : CCameraBase
    {
        [FieldAttr(288)] public float _dampingFactor = 0.2f;
        [FieldAttr(292)] public float _fovStorage = 1.396f;
        [FieldAttr(296)] public float _maxZoomOutDistance = 1024.0f;
        [FieldAttr(300)] public bool _depthOfFieldEnabled = true;
        [FieldAttr(304)] public igVec4fMetaField _focusPlanes = new();
        [FieldAttr(320)] public CCameraClipSettings? _clipSettings;
        [FieldAttr(328)] public CCameraDistanceCullSettings? _distanceCullSettings;
        [FieldAttr(336)] public float _depthTetherDistance = 800.0f;
        [FieldAttr(340)] public bool _shadowSettingsState;
        [FieldAttr(344)] public float _shadowRange = 3000.0f;
        [FieldAttr(352)] public igVec4fMetaField _shadowBias = new();
        [FieldAttr(368)] public float _vfxCullRadiusScale = 1.0f;
        [FieldAttr(372)] public float _mobileShaderLodDistance = 1200.0f;
        [FieldAttr(376)] public float _mobileShadowRange = 1000.0f;
        [FieldAttr(380)] public float _mobileShadowHeightOffset = 1000.0f;
        [FieldAttr(384)] public float _mobileShadowFarPlane = 1500.0f;
        [FieldAttr(388)] public CTransformMetaField _transformVelocity = new();
    }
}
