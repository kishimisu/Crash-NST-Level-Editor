namespace Alchemy
{
    [ObjectAttr(48, 8, metaType: typeof(Object))]
    public class Scripts_SpawnCollectiblesComponentData_RandomRangedSelectionMethod : Scripts_SpawnCollectiblesComponentData_CollectibleSelectionMethod
    {
        [FieldAttr(32)] public igEntityList? Collectibles;
        [FieldAttr(40)] public RangedFloat? NumCollectiblesToSpawn;
    }
}
