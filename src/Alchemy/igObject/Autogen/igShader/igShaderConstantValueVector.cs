namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class igShaderConstantValueVector : igShaderConstantValue
    {
        [FieldAttr(32)] public igVec4fMetaField _value = new();
    }
}
