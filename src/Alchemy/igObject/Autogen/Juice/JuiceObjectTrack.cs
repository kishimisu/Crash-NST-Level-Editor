namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class JuiceObjectTrack : JuiceTrack
    {
        [FieldAttr(40)] public igHandleMetaField _object = new();
        [FieldAttr(48)] public float _startFrameFloat;
        [FieldAttr(52)] public float _endFrameFloat = -1.0f;
    }
}
