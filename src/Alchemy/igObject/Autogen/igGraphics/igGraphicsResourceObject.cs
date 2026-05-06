namespace Alchemy
{
    [ObjectAttr(nst: 32, ctr: 32, align: 8)]
    public class igGraphicsResourceObject : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public igSizeTypeMetaField _resource = new();
        [FieldAttr(nst: 24, ctr: 24)] public EigGraphicsResourceType _type;
    }
}
