namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CToonConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public float fade = 1.0f;
        [FieldAttr(28)] public float lineWidth = 1.0f;
    }
}
