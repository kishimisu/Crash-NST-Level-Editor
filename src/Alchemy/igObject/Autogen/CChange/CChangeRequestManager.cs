namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CChangeRequestManager : igObject
    {
        [FieldAttr(16)] public int _requestCounter;
        [FieldAttr(24)] public COnChangeDelegate? _onChange;
        [FieldAttr(32)] public COnChangeEventList? _onChangeEventList;
        [FieldAttr(40)] public igHandleMetaField _owner = new();
        [FieldAttr(48)] public uint _nonScopedRequests;
    }
}
