namespace Alchemy
{
    [ObjectAttr(160, 16)]
    public class igTransform : igGroup
    {
        [FieldAttr(64)] public igMatrix44fMetaField _m = new();
        [FieldAttr(128)] public int _target;
        [FieldAttr(136)] public igTransformSource? _transformInput;
        [FieldAttr(144)] public igTransformSource3? _transformInput3;
    }
}
