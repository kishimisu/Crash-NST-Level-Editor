namespace Alchemy
{
    [ObjectAttr(640, 16)]
    public class CFxaaRenderPass : igFullScreenRenderPass
    {
        [FieldAttr(592)] public CFxaaConstantBundle? _shaderParameters;
        [FieldAttr(600)] public float _sharpness = 2.0f;
        [FieldAttr(608)] public igHandleMetaField _fxaaLowMaterial = new();
        [FieldAttr(616)] public igHandleMetaField _fxaaMediumMaterial = new();
        [FieldAttr(624)] public igHandleMetaField _fxaaHighMaterial = new();
    }
}
