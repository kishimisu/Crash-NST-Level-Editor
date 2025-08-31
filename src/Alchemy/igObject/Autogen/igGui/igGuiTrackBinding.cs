namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igGuiTrackBinding : igObject
    {
        [FieldAttr(16, false)] public igObject? _object;
        [FieldAttr(24, false)] public igGuiTrack? _track;
    }
}
