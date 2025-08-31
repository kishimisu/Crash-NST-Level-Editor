namespace Alchemy
{
    [ObjectAttr(168, 8)]
    public class CZoneInfoSave : igObject
    {
        [FieldAttr(16)] public string? _zoneName = null;
        [FieldAttr(24)] public CZoneInfoUserSession? _savedData;
        [FieldAttr(32)] public igObject[] _sessionData = new igObject[17];
    }
}
