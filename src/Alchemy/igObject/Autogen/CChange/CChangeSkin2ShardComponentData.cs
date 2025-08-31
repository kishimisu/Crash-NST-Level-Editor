namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CChangeSkin2ShardComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CChangeSkin2ComponentItemHashTable? _skinShards;
    }
}
