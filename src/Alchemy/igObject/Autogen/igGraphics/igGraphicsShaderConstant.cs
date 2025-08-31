namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igGraphicsShaderConstant : igGraphicsObject
    {
        [FieldAttr(24)] public igSizeTypeMetaField _resource = new();
    }
}
