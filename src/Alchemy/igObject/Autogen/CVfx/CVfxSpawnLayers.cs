namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class CVfxSpawnLayers : igObject
    {
        [ObjectAttr(2)]
        public class SpawnLayers : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _spawnLayer1 = true;
            [FieldAttr(1, size: 1)] public bool _spawnLayer2 = false;
            [FieldAttr(2, size: 1)] public bool _spawnLayer3 = false;
            [FieldAttr(3, size: 1)] public bool _spawnLayer4 = false;
            [FieldAttr(4, size: 1)] public bool _spawnLayer5 = false;
            [FieldAttr(5, size: 1)] public bool _spawnLayer6 = false;
            [FieldAttr(6, size: 1)] public bool _spawnLayer7 = false;
            [FieldAttr(7, size: 1)] public bool _spawnLayer8 = false;
            [FieldAttr(8, size: 1)] public bool _spawnLayer9 = false;
            [FieldAttr(9, size: 1)] public bool _spawnLayer10 = false;
            [FieldAttr(10, size: 1)] public bool _spawnLayer11 = false;
            [FieldAttr(11, size: 1)] public bool _spawnLayer12 = false;
            [FieldAttr(12, size: 1)] public bool _spawnLayer13 = false;
            [FieldAttr(13, size: 1)] public bool _spawnLayer14 = false;
            [FieldAttr(14, size: 1)] public bool _spawnLayer15 = false;
            [FieldAttr(15, size: 1)] public bool _spawnLayer16 = false;
        }

        [FieldAttr(16)] public SpawnLayers _spawnLayers = new();
    }
}
