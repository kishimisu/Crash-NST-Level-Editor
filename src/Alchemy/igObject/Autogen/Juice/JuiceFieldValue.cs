namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 40, align: 8)]
    public class JuiceFieldValue : igObject
    {
        [FieldAttr(nst: 16, ctr: 16, refCount: false)] public igCinematicObject? _object;
        [FieldAttr(nst: 24, ctr: 24)] public igFloatMetaFieldInstance? _field;
        [FieldAttr(nst: 32, ctr: 32)] public float _value;
    }
}
