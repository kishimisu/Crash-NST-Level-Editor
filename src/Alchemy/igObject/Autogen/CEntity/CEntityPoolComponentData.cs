namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CEntityPoolComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public int _poolSize = 5;
        [FieldAttr(32)] public string? _poolName = null;
        [FieldAttr(40)] public u64 _poolId;
    }
}
