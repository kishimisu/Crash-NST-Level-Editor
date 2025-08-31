namespace Alchemy
{
    [ObjectAttr(256, 16)]
    public class igRenderCamera : igNamedObject
    {
        public enum ECameraMode : uint
        {
            kPerspective = 0,
            kOrthographic = 1,
        }

        [FieldAttr(24)] public igVec3fMetaField _up = new();
        [FieldAttr(36)] public igVec3fMetaField _lookAtPos = new();
        [FieldAttr(48)] public igVec3fMetaField _pos = new();
        [FieldAttr(60)] public float _fov = 45.0f;
        [FieldAttr(64)] public float _aspect = 1.0f;
        [FieldAttr(68)] public float _left;
        [FieldAttr(72)] public float _right;
        [FieldAttr(76)] public float _bottom;
        [FieldAttr(80)] public float _top;
        [FieldAttr(84)] public int _viewportX;
        [FieldAttr(88)] public int _viewportY;
        [FieldAttr(92)] public int _viewportWidth = 640;
        [FieldAttr(96)] public int _viewportHeight = 480;
        [FieldAttr(100)] public float _near = 1.0f;
        [FieldAttr(104)] public float _far = 1.0f;
        [FieldAttr(108)] public ECameraMode _mode;
        [FieldAttr(112)] public igMatrix44fMetaField _viewMatrix = new();
        [FieldAttr(176)] public igMatrix44fMetaField _projectionMatrix = new();
        [FieldAttr(240)] public bool _fixedViewport;
        [FieldAttr(241)] public bool _updateProjectionOnSizeChange = true;
        [FieldAttr(242)] public bool _enabled = true;
    }
}
