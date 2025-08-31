namespace Alchemy
{
    [ObjectAttr(112, 16)]
    public class igAnimatedTransform : igNamedObject
    {
        [FieldAttr(32)] public igMatrix44fMetaField _matrix = new();
        [FieldAttr(96)] public igAnimatedTransformSource? _source;
    }
}
