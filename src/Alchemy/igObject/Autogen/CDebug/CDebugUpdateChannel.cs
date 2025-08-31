namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CDebugUpdateChannel : igNamedObject
    {
        [FieldAttr(24)] public bool _enabled;
        [FieldAttr(32)] public CDebugUpdateDelegate? _onDebugUpdate;
        [FieldAttr(40)] public CDebugUpdateEventList? _onDebugUpdateList;
    }
}
