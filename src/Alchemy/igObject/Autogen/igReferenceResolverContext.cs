namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igReferenceResolverContext : igObject
    {
        [FieldAttr(16)] public igObjectList? _rootObjects;
        [FieldAttr(24)] public igMemoryRef<i8> _basePath = new();
        [FieldAttr(40)] public igStringObjectHashTable? _data;
    }
}
