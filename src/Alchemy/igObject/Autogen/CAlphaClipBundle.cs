namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CAlphaClipBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public bool _enable;
        [FieldAttr(28)] public float _threshold = 0.5f;
    }
}
