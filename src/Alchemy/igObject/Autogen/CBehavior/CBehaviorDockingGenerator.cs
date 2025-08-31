namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CBehaviorDockingGenerator : igNamedObject
    {
        [FieldAttr(24)] public igRawRefMetaField _havokDockingGeneratorTemplate = new();
    }
}
