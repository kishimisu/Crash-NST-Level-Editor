namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class igShaderConstantVector : igShaderConstantData
    {
        [FieldAttr(32)] public igVec4fMetaField _data = new();
    }
}
