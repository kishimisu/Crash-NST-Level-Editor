namespace Alchemy
{
    [ObjectAttr(112, 4)]
    public class igVfxCylindricalSpawnLocationData : igVfxVolumetricSpawnLocationData
    {
        [FieldAttr(88)] public float _height = 50.0f;
        [FieldAttr(92)] public float _bottomRadius = 25.0f;
        [FieldAttr(96)] public float _topRadius = 25.0f;
        [FieldAttr(100)] public igRangedFloatMetaField _theta = new();
    }
}
