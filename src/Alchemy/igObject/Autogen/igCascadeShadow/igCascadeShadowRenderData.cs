namespace Alchemy
{
    [ObjectAttr(112, 16)]
    public class igCascadeShadowRenderData : igObject
    {
        [FieldAttr(16)] public bool _scaleZBias;
        [FieldAttr(32)] public igVec4fMetaField _zBias = new();
        [FieldAttr(48)] public float _blendDistance = 12.0f;
        [FieldAttr(52)] public bool _cullingEnabled;
        [FieldAttr(56)] public EIG_GFX_CULL_FACE_MODE _cullingMode;
        [FieldAttr(60)] public float _lastSplit = 1.0f;
        [FieldAttr(64)] public float _fadeStart = 1.0f;
        [FieldAttr(68)] public float _splitDistribution = 0.5f;
        [FieldAttr(72)] public float _scaleQuantizer = 64.0f;
        [FieldAttr(76)] public float _pancakeThickness = 32.0f;
        [FieldAttr(80)] public igVec4fMetaField _smallObjectThreshold = new();
        [FieldAttr(96)] public igVec3fMetaField _upVector = new();
        [FieldAttr(108)] public bool _enable = true;
        [FieldAttr(109)] public bool _drawFrustums;
        [FieldAttr(110)] public bool _drawRectangles;
    }
}
