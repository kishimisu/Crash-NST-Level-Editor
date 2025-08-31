namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class CAmbientBakeInfluenceBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _ambientBakeInfluence = new();
    }
}
