namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igSplineEventTrack : igObject
    {
        [FieldAttr(16)] public igSplineEventList? _data;
        [FieldAttr(24)] public igOrderedMapMetaField _distanceTable = new();
        [FieldAttr(72)] public float _length;
        [FieldAttr(76)] public bool _looping;
    }
}
