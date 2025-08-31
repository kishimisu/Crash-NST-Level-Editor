namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CModSoundEventData : igObject
    {
        [FieldAttr(16)] public CMod.EModLocation _modLocation = CMod.EModLocation.eML_Invalid;
        [FieldAttr(20)] public ESoundLoopEvent _loopEvent;
        [FieldAttr(24)] public CSoundUpdateMethodList? _updateMethodList;
        [FieldAttr(32)] public bool _playNameVO;
        [FieldAttr(33)] public bool _playTaglineVO;
        [FieldAttr(34)] public bool _playIdleSfx;
        [FieldAttr(35)] public bool _playOneShotSfx;
    }
}
