namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igGraphicsMaterialAnimation : igObject
    {
        [FieldAttr(16)] public igAnimatedTransformSource? _transform;
        [FieldAttr(24)] public EigGraphicsMaterialAnimationConstantType _constantType;
        [FieldAttr(32)] public string? _constantName = null;
        [FieldAttr(40)] public igSizeTypeMetaField _resource = new();
    }
}
