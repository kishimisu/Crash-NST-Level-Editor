namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class JuiceAnimation : JuiceTrackList
    {
        [FieldAttr(40)] public string? _name = null;
        [FieldAttr(48)] public igHandleMetaField _scene = new();
        [FieldAttr(56)] public float _lengthFloat;
        [FieldAttr(60)] public bool _loop;
        [FieldAttr(64)] public float _startTimeFloat;
    }
}
