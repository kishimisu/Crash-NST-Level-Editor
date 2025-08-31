namespace Alchemy
{
    [ObjectAttr(624, 16)]
    public class CCombinePostRenderPass : igFullScreenRenderPass
    {
        [FieldAttr(592)] public igHandleMetaField _sunLightHandle = new();
        [FieldAttr(600)] public igHandleMetaField _renderData = new();
        [FieldAttr(608)] public igAtmosphericsConstantBundle? _atmosphericsParameters;
    }
}
