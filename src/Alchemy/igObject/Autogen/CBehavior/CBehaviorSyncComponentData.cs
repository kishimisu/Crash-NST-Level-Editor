namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CBehaviorSyncComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public bool _enableNetworkReplication = true;
        [FieldAttr(32)] public string? _layerName = null;
    }
}
