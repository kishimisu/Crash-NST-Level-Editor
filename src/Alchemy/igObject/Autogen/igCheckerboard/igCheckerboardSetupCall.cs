namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igCheckerboardSetupCall : igDrawCall
    {
        [FieldAttr(24)] public igCommandCopyTextureParametersMetaField _copyCommand = new();
    }
}
