namespace Alchemy
{
    [ObjectAttr(160, 8)]
    public class igTransferRenderPass : igRenderPass
    {
        [FieldAttr(56)] public igRenderTargetInputData? _inputRenderTargetData;
        [FieldAttr(64)] public igRenderTargetOutputData? _outputRenderTargetData;
        [FieldAttr(72)] public igCommandCopyTextureParametersMetaField _copyCommand = new();
        [FieldAttr(128)] public igSortKeyCommandDelegateObject? _passDelegate;
        [FieldAttr(136)] public int _sourceX;
        [FieldAttr(140)] public int _sourceY;
        [FieldAttr(144)] public int _destX;
        [FieldAttr(148)] public int _destY;
        [FieldAttr(152)] public int _width = -1;
        [FieldAttr(156)] public int _height = -1;
    }
}
