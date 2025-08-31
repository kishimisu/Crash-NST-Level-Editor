namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CCutsceneActorData : igObject
    {
        [FieldAttr(16)] public string? _skin = null;
        [FieldAttr(24)] public CFxMaterialRedirectTable? _materialOverrides;
    }
}
