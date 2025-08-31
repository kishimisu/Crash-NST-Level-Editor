namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igInfo : igReferenceResolver
    {
        [FieldAttr(24, false)] public igDirectory? _directory;
        [FieldAttr(32)] public bool _resolveState = true;
    }
}
