namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CSceneShadowBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public bool _state;
        [FieldAttr(25)] public bool _fadeState;
        [FieldAttr(28)] public float _fade = 1.0f;
    }
}
