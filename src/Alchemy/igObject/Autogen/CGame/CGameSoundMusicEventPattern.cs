namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CGameSoundMusicEventPattern : igObject
    {
        [FieldAttr(16)] public string? _eventName = null;
        [FieldAttr(24)] public int _repeatedMeasureLength;
        [FieldAttr(28)] public float _beatOffset;
        [FieldAttr(32)] public CGameSoundMusicEventBeatDataList? _beatDataList;
    }
}
