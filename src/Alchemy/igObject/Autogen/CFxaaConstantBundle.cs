namespace Alchemy
{
    [ObjectAttr(160, 16)]
    public class CFxaaConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _fxaaQualityRcpFrame = new();
        [FieldAttr(48)] public igVec4fMetaField _fxaaConsoleRcpFrameOpt = new();
        [FieldAttr(64)] public igVec4fMetaField _fxaaConsoleRcpFrameOpt2 = new();
        [FieldAttr(80)] public igVec4fMetaField _fxaaConsole360RcpFrameOpt2 = new();
        [FieldAttr(96)] public float _fxaaQualitySubpix = 0.75f;
        [FieldAttr(100)] public float _fxaaQualityEdgeThreshold = 0.16599999f;
        [FieldAttr(104)] public float _fxaaQualityEdgeThresholdMin = 0.0833f;
        [FieldAttr(108)] public float _fxaaConsoleEdgeSharpness = 8.0f;
        [FieldAttr(112)] public float _fxaaConsoleEdgeThreshold = 0.125f;
        [FieldAttr(116)] public float _fxaaConsoleEdgeThresholdMin = 0.05f;
        [FieldAttr(128)] public igVec4fMetaField _fxaaConsole360ConstDir = new();
        [FieldAttr(144)] public bool _fxaaState = true;
    }
}
