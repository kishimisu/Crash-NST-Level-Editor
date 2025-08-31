namespace Alchemy
{
    [ObjectAttr(112, 4)]
    public class igVfxSphericalSpawnLocationData : igVfxVolumetricSpawnLocationData
    {
        [FieldAttr(88)] public float _radius = 50.0f;
        [FieldAttr(92)] public igRangedFloatMetaField _cosPhi = new();
        [FieldAttr(100)] public igRangedFloatMetaField _theta = new();
    }
}
