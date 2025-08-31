namespace Alchemy
{
    [ObjectAttr(608, 16)]
    public class CAmbientOcclusionRenderPass : igFullScreenRenderPass
    {
        [FieldAttr(592)] public CAmbientOcclusionShaderConstantBundle? _shaderParameters;
        [FieldAttr(600)] public igHandleMetaField _parameters = new();
    }
}
