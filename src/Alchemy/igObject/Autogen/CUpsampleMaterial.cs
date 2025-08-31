namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class CUpsampleMaterial : igFxMaterial
    {
        [FieldAttr(120)] public bool _largeRadius;
        [FieldAttr(121)] public bool _fastFilter;
    }
}
