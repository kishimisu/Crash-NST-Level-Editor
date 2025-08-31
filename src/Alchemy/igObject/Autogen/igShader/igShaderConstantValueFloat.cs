namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igShaderConstantValueFloat : igShaderConstantValue
    {
        [FieldAttr(24)] public float _value;
    }
}
