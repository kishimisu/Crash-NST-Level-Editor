namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igRefMetaFieldInstance : igMetaFieldInstance
    {
        [FieldAttr(72)] public bool _construct;
        [FieldAttr(73)] public bool _destruct;
        [FieldAttr(74)] public bool _reconstruct;
        [FieldAttr(75)] public bool _refCounted = true;
    }
}
