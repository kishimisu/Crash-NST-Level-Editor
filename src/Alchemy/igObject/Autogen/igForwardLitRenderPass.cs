namespace Alchemy
{
    [ObjectAttr(528, 16)]
    public class igForwardLitRenderPass : igParallaxRenderPass
    {
        [FieldAttr(480)] public igHandleMetaField _sunLightHandle = new();
        [FieldAttr(488)] public igHandleMetaField _renderData = new();
        [FieldAttr(496)] public bool _lightingEnabled = true;
        [FieldAttr(497)] public bool _enablePrepassDepth;
        [FieldAttr(504)] public igOutdoorLightConstantBundle? _outdoorLightConstantBundle;
        [FieldAttr(512)] public igAtmosphericsConstantBundle? _atmosphericsConstantBundle;
    }
}
