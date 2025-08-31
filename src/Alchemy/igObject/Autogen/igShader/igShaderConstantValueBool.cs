namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igShaderConstantValueBool : igShaderConstantValue
    {
        [FieldAttr(24)] public bool _value;
    }
}
