namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CFilterByTags : CFilterMethod
    {
        [FieldAttr(24)] public CEntityTagSet? _tags;
    }
}
