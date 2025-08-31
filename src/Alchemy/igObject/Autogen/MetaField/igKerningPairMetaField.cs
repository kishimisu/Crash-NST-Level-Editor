namespace Alchemy
{
    [ObjectAttr(8, 8)]
    public class igKerningPairMetaField : igMetaField
    {
        [FieldAttr(0)] public u32 _first;
        [FieldAttr(4)] public u32 _second;
    }
}
