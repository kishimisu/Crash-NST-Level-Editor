namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 80, align: 16)]
    public class igVfxOrbitAxisAngleRangedRampDistanceRangedRampOperator : igVfxOrbitAxisAngleDistanceBaseOperator
    {
        [FieldAttr(nst: 64, ctr: 48)] public igVfxRangedRampMetaField _angle = new();
        [FieldAttr(nst: 80, ctr: 64)] public igVfxRangedRampMetaField _radius = new();
    }
}
