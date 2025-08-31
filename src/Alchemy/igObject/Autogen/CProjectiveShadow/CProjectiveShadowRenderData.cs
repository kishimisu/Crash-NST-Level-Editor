namespace Alchemy
{
    [ObjectAttr(56, 4)]
    public class CProjectiveShadowRenderData : igObject
    {
        [FieldAttr(16)] public float _range = 1000.0f;
        [FieldAttr(20)] public float _edgeFadeAmount = 0.1f;
        [FieldAttr(24)] public float _heightOffset = 1000.0f;
        [FieldAttr(28)] public float _farPlane = 2000.0f;
        [FieldAttr(32)] public float _fade = 1.0f;
        [FieldAttr(36)] public igVec3fMetaField _upVector = new();
        [FieldAttr(48)] public bool _enable = true;
        [FieldAttr(49)] public bool _forceVerticalShadows;
    }
}
