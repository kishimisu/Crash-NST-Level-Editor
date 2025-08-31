namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CVfxTextComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public bool _enabledAtStart = true;
        [FieldAttr(32)] public string? _displayText = null;
        [FieldAttr(40)] public CVfxFont? _vfxFont;
        [FieldAttr(48)] public ETextAlignment _textAlignment;
        [FieldAttr(52)] public float _secondsPerCharacter;
        [FieldAttr(56)] public igHandleMetaField _startBolt = new();
        [FieldAttr(64)] public igHandleMetaField _endBolt = new();
        [FieldAttr(72)] public float _maxWidth;
        [FieldAttr(76)] public float _maxHeight;
        [FieldAttr(80)] public float _curveRadius;
        [FieldAttr(84)] public bool _faceCamera;
    }
}
