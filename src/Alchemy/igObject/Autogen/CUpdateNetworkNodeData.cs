namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CUpdateNetworkNodeData : igObject
    {
        [FieldAttr(16)] public igVscDelegateMetaField _onUpdate = new();
        [FieldAttr(32)] public igHandleMetaField _entity = new();
        [FieldAttr(40)] public float _interval;
    }
}
