namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igSplineVec3fKeyframeTrack : igObject
    {
        [FieldAttr(16)] public igSplineVec3fKeyframeList? _data;
        [FieldAttr(24)] public igOrderedMapMetaField _distanceTable = new();
        [FieldAttr(72)] public float _length;
        [FieldAttr(76)] public bool _looping;
    }
}
