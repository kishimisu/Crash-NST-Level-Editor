namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CLocalShadowInfluenceConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public float _localShadowInfluence;
    }
}
