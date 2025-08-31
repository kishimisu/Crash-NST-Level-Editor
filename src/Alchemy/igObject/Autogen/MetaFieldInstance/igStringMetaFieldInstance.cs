namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igStringMetaFieldInstance : igRefMetaFieldInstance
    {
        [FieldAttr(56, false)] public igMemoryRef<string?> _default = new();
    }
}
