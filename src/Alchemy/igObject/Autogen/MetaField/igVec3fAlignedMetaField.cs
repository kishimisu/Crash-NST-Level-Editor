namespace Alchemy
{
    [ObjectAttr(16, 8)]
    public class igVec3fAlignedMetaField : igVec3fMetaField
    {
        [FieldAttr(12)] public u32 _padding;
    }
}
