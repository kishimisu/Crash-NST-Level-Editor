namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CGatedMusicComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CGameSoundMusicSettings? _onEnterMusicSettings;
        [FieldAttr(32)] public CGameSoundMusicSettings? _onExitMusicSettings;
    }
}
