namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CVfxQualityBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public float _quality = 1.0f;
        [FieldAttr(28)] public bool _edgeDetectEnabled = true;
    }
}
