namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class CBloomRenderPass : igRenderPass
    {
        [FieldAttr(56)] public igHandleMetaField _bloomMaterial = new();
        [FieldAttr(64)] public igHandleMetaField _bloomUpsampleMaterial = new();
        [FieldAttr(72)] public string? _downsample0Technique = "Downsample0";
        [FieldAttr(80)] public string? _downsample1Technique = "Downsample1";
        [FieldAttr(88)] public string? _downsample2Technique = "Downsample2";
        [FieldAttr(96)] public string? _upsampleTechnique = "Upsample";
        [FieldAttr(104)] public igHandleMetaField _inputRenderTarget = new();
        [FieldAttr(112)] public igHandleMetaField _maskRenderTarget = new();
        [FieldAttr(120)] public igHandleMetaField _outputRenderTarget = new();
    }
}
