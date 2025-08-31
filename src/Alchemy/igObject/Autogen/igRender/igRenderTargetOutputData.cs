namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class igRenderTargetOutputData : igObject
    {
        [FieldAttr(16)] public igRenderTargetList? _colorTargets;
        [FieldAttr(24)] public igRenderTarget? _depthTarget;
        [FieldAttr(32)] public igSizeTypeMetaField[] _colorRenderTargetViews = new igSizeTypeMetaField[8];
        [FieldAttr(96)] public igSizeTypeMetaField _depthRenderTargetView = new();
        [FieldAttr(104)] public uint _colorRenderTargetViewCount;
        [FieldAttr(108)] public bool _outputToBackbufferColorSurface;
        [FieldAttr(109)] public bool _outputToBackbufferDepthSurface;
        [FieldAttr(110)] public bool _writesToDepth = true;
    }
}
