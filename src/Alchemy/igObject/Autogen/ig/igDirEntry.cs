namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 40, align: 8)]
    public class igDirEntry : igNamedObject
    {
        [FieldAttr(nst: 24, ctr: 24)] public int _index = -1;
        [FieldAttr(nst: 32, ctr: 32)] public igRawRefMetaField _ref = new();
    }
}
