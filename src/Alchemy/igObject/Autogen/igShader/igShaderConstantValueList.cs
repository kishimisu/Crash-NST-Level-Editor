namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igShaderConstantValueList : igGraphicsObject
    {
        [FieldAttr(24)] public igVectorMetaField<igShaderConstantValue> _values = new();
    }
}
