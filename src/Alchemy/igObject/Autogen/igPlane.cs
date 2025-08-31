namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igPlane : igVolume
    {
        [FieldAttr(16)] public igVec3fMetaField _norm = new();
        [FieldAttr(28)] public float _offset;
        [FieldAttr(32)] public EIG_MATH_SPATIAL_REGION _octant;
    }
}
