namespace Alchemy
{
    [ObjectAttr(72, 4)]
    public class igVfxSpawnLocationData : igObject
    {
        [ObjectAttr(4)]
        public class SpawnLocationFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _hasPosition = true;
            [FieldAttr(1, size: 1)] public bool _hasRotation = false;
            [FieldAttr(2, size: 1)] public bool _dataFieldsCached;
        }

        [FieldAttr(16)] public igRangedVectorMetaField _offsetPos = new();
        [FieldAttr(40)] public igRangedVectorMetaField _offsetRot = new();
        [FieldAttr(64)] public SpawnLocationFlags _spawnLocationFlags = new();
    }
}
