namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 64, align: 16)]
    public class igVfxOrbitAxisAngleRangeDistanceRangeOperator : igVfxOrbitAxisAngleDistanceBaseOperator
    {
        [FieldAttr(nst: 64, ctr: 48)] public igRangedFloatMetaField _angle = new();
        [FieldAttr(nst: 72, ctr: 56)] public igRangedFloatMetaField _radius = new();
    }
}
