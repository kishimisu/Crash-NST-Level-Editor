namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CNetworkVisualizationComponentData : igComponentData
    {
        [FieldAttr(24)] public igHandleMetaField _packetCost = new();
    }
}
