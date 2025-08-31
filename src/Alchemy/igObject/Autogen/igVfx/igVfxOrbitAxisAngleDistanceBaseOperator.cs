namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class igVfxOrbitAxisAngleDistanceBaseOperator : igVfxOrbitBaseOperator
    {
        [FieldAttr(48)] public igVec3fAlignedMetaField _axis = new();
    }
}
