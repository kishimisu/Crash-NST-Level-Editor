namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CGuiBehaviorSubtitles : igGuiBehavior
    {
        [FieldAttr(16, false)] public igGuiPlaceable? _placeable;
        [FieldAttr(24)] public igStringRefList? _displayedSubtitleLines;
        [FieldAttr(32)] public string? _currentFullSubtitleLine = null;
        [FieldAttr(40)] public string? _currentPartialSubtitleLine = null;
        [FieldAttr(48)] public CTimer? _textInterpolationTimer;
        [FieldAttr(56)] public float _charactersPerSecond;
        [FieldAttr(60)] public int _currentFullSubtitleLineLength;
        [FieldAttr(64)] public int _displayedSubtitleLinesLength;
    }
}
