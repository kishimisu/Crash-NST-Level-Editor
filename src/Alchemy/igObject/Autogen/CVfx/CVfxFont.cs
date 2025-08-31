namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CVfxFont : igObject
    {
        [FieldAttr(16)] public CCharacterInfoHashTable? _characterInfo;
        [FieldAttr(24)] public igHandleMetaField _textEffect = new();
        [FieldAttr(32)] public int _vfxTrackParameterIndex = 1;
        [FieldAttr(36)] public float _defaultCharacterWidth;
        [FieldAttr(40)] public int _numFrames = 1;
        [FieldAttr(44)] public float _lineHeight;
    }
}
