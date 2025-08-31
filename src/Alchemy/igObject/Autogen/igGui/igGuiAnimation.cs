namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igGuiAnimation : igObject
    {
        [FieldAttr(16)] public igGuiAnimationTag? _tag;
        [FieldAttr(24)] public igGuiTrackList? _tracks;
        [FieldAttr(32)] public float _length;
    }
}
