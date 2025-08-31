namespace Alchemy
{
    [ObjectAttr(88, 4)]
    public class igVfxVolumetricSpawnLocationData : igVfxSpawnLocationData
    {
        [ObjectAttr(1)]
        public class FlagStorage : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _applyNormal;
        }

        [FieldAttr(72)] public igRangedFloatMetaField _volumeScalar = new();
        [FieldAttr(80)] public FlagStorage _flagStorage = new();
    }
}
