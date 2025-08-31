namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igShaderConstantValueInt : igShaderConstantValue
    {
        [FieldAttr(24)] public int _value;
    }
}
