namespace Alchemy
{
    [ObjectAttr(ctr: 32, align: 8)]
    public class igGraphicsResourceObject : igObject
    {
        [FieldAttr(ctr: 16)] public igSizeTypeMetaField _resource = new();
        [FieldAttr(ctr: 24)] public EigGraphicsResourceType _type;
    }
}
