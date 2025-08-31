namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igEffectAnnotation : igObject
    {
        [FieldAttr(16)] public string? _name = null;
        [FieldAttr(24)] public string? _value = null;
    }
}
