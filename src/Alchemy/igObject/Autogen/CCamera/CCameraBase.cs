namespace Alchemy
{
    [ObjectAttr(288, 16)]
    public class CCameraBase : igObject
    {
        [FieldAttr(16)] public igVec3fMetaField _position = new();
        [FieldAttr(28)] public igVec3fMetaField _rotation = new();
        [FieldAttr(40)] public string? _nameCache = null;
        [FieldAttr(48)] public CCameraModelMetaField _cameraModel = new();
        [FieldAttr(256)] public CTransformMetaField _transform = new();
        [FieldAttr(284)] public bool _ignoreTransformWhenBlending;
        [FieldAttr(285)] public bool _resetOnNextUpdate;
        [FieldAttr(286)] public bool _isActivated;
        [FieldAttr(287)] public bool _hasListener = true;
    }
}
