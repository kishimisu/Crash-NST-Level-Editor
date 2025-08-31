namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igObjectAnnotationTable : igObject
    {
        [FieldAttr(16)] public igObjectList? _objects;
        [FieldAttr(24)] public igEffectAnnotationListList? _annotations;
    }
}
