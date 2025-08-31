namespace Alchemy
{
    [ObjectAttr(8, 8)]
    public class igRandomMetaField : igCompoundMetaField
    {
        [FieldAttr(0)] public float _min;
        [FieldAttr(4)] public float _max;
    }
}
