namespace Alchemy
{
    [ObjectAttr(192, 16)]
    public class CBoltPoint : igObject
    {
        [FieldAttr(16)] public igVec3fMetaField _rotation = new();
        [FieldAttr(28)] public bool _flipX;
        [FieldAttr(29)] public bool _flipY;
        [FieldAttr(30)] public bool _flipZ;
        [FieldAttr(31)] public bool _verticalAlign;
        [FieldAttr(32)] public bool _worldAlign;
        [FieldAttr(33)] public bool _cameraAlign;
        [FieldAttr(34)] public bool _keepScale = true;
        [FieldAttr(35)] public bool _keepConstantSize;
        [FieldAttr(36)] public float _scale = 1.0f;
        [FieldAttr(40)] public igVec3fMetaField _offset = new();
        [FieldAttr(52)] public igVec3fMetaField _postOffset = new();
        [FieldAttr(64)] public igVec4fMetaField _vfxColor = new();
        [FieldAttr(80)] public igVec4fMetaField _vfxParameters = new();
        [FieldAttr(96)] public string? _boltName = "";
        [FieldAttr(104)] public string? _preserveBoltName = "";
        [FieldAttr(112)] public igMatrix44fMetaField _adjustmentMatrix = new();
        [FieldAttr(176)] public bool _useAdjustmentMatrix;
    }
}
