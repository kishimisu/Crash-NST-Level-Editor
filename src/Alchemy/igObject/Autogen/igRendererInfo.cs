namespace Alchemy
{
    [ObjectAttr(200, 8)]
    public class igRendererInfo : igInfo
    {
        [FieldAttr(40)] public igRenderPass? _rendererDefault;
        [FieldAttr(48)] public igRenderPass? _rendererDx9;
        [FieldAttr(56)] public igRenderPass? _rendererAspen;
        [FieldAttr(64)] public igRenderPass? _rendererIpodTouch3;
        [FieldAttr(72)] public igRenderPass? _rendererIpodTouch4;
        [FieldAttr(80)] public igRenderPass? _rendererIphone3gs;
        [FieldAttr(88)] public igRenderPass? _rendererIphone4;
        [FieldAttr(96)] public igRenderPass? _rendererIphone4s;
        [FieldAttr(104)] public igRenderPass? _rendererIphone5;
        [FieldAttr(112)] public igRenderPass? _rendererIpad;
        [FieldAttr(120)] public igRenderPass? _rendererIpad2;
        [FieldAttr(128)] public igRenderPass? _rendererIpad3;
        [FieldAttr(136)] public igRenderPass? _rendererDurango;
        [FieldAttr(144)] public igRenderPass? _rendererPs4;
        [FieldAttr(152)] public igRenderPass? _rendererOsx;
        [FieldAttr(160)] public igRenderPass? _rendererWgl;
        [FieldAttr(168)] public igRenderPass? _rendererDx11;
        [FieldAttr(176)] public igRenderPass? _rendererLinux;
        [FieldAttr(184)] public igRenderPass? _rendererNull;
        [FieldAttr(192)] public igRenderPass? _rendererNx;
    }
}
