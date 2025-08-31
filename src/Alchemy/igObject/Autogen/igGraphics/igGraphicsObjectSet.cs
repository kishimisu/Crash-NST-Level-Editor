namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igGraphicsObjectSet : igObject
    {
        [FieldAttr(16)] public igVectorMetaField<igGraphicsObject> _objects = new();
    }
}
