namespace Alchemy
{
    [ObjectAttr(8, 8)]
    public class igRangedFloatMetaField : igMetaField
    {
        [FieldAttr(0)] public float _max;
        [FieldAttr(4)] public float _min;
    }
}
