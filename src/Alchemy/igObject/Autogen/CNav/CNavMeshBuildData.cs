namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CNavMeshBuildData : igObject
    {
        [FieldAttr(16)] public string? _inputMeshFile = null;
        [FieldAttr(24)] public igHandleMetaField _buildSettings = new();
    }
}
