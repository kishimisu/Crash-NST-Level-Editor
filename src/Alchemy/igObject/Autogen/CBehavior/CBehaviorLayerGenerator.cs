namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CBehaviorLayerGenerator : igNamedObject
    {
        [FieldAttr(24)] public CBehaviorLayerList? _layers;
        [FieldAttr(32)] public igRawRefMetaField _havokLayerGenerator = new();
    }
}
