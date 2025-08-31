namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class COptionalRenderPass : igRenderPass
    {
        [FieldAttr(56)] public COptionalRenderPassEnabledDataHandleList? _enabledDataList;
    }
}
