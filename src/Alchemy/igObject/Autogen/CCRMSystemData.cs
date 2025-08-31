namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CCRMSystemData : igObject
    {
        [FieldAttr(16)] public string? _context = null;
        [FieldAttr(24)] public igStringRefList? _movies;
        [FieldAttr(32)] public bool _enableDebugMessages;
        [FieldAttr(40)] public igStringRefList? _debugMessages;
    }
}
