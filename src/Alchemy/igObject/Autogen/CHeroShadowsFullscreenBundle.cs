namespace Alchemy
{
    [ObjectAttr(176, 16)]
    public class CHeroShadowsFullscreenBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public bool _state;
        [FieldAttr(25)] public bool _coop;
        [FieldAttr(32)] public igMatrix44fMetaField _heroViewToLightMatrix1 = new();
        [FieldAttr(96)] public igMatrix44fMetaField _heroViewToLightMatrix2 = new();
        [FieldAttr(160)] public float _fade1 = 1.0f;
        [FieldAttr(164)] public float _fade2 = 1.0f;
        [FieldAttr(168)] public bool _fadeState;
    }
}
