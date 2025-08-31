namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CutsceneActionApplyIBLCubemap : CCutsceneAction
    {
        [FieldAttr(24)] public string? _cubemap = null;
        [FieldAttr(32)] public igObjectDirectory? _cubemapDirectory;
    }
}
