namespace Alchemy
{
    [ObjectAttr(624, 16)]
    public class igCheckerboardResolvePass : igFullScreenRenderPass
    {
        [FieldAttr(592)] public igCheckerboardConstantBundle? _checkerboardParameters;
        [FieldAttr(600)] public igSizeTypeMetaField _historyTexture = new();
        [FieldAttr(608)] public igCheckerboardSetupCall? _setupCall;
    }
}
