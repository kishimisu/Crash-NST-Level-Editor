namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CNextGenStateBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public bool _state;
    }
}
