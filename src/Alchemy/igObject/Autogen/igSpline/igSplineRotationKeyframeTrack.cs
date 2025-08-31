namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igSplineRotationKeyframeTrack : igObject
    {
        [FieldAttr(16)] public igSplineRotationKeyframeList? _data;
        [FieldAttr(24)] public igOrderedMapMetaField _distanceTable = new();
        [FieldAttr(72)] public float _length;
        [FieldAttr(76)] public bool _looping;
    }
}
