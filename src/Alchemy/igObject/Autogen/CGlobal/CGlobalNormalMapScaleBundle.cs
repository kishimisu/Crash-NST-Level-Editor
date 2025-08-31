namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CGlobalNormalMapScaleBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public float _globalNormalMapScale = 1.0f;
    }
}
