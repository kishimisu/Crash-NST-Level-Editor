namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class igSpline2 : igObject
    {
        [FieldAttr(16)] public igSplineControlPoint2List? _data;
        [FieldAttr(24)] public igOrderedMapMetaField _distanceTable = new();
        [FieldAttr(72)] public igSplineFloatKeyframeTrackTable? _floatTracks;
        [FieldAttr(80)] public igSplineVec3fKeyframeTrackTable? _vec3fTracks;
        [FieldAttr(88)] public igSplineRotationKeyframeTrackTable? _rotationTracks;
        [FieldAttr(96)] public igSplineEventTrack? _events;
        [FieldAttr(104)] public float _length;
        [FieldAttr(108)] public bool _looping;
        [FieldAttr(109)] public bool _precacheBezierPositions;
    }
}
