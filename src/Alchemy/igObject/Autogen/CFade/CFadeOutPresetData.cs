namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CFadeOutPresetData : igObject
    {
        [FieldAttr(16)] public float _duration;
        [FieldAttr(24)] public Color? _color;
        [FieldAttr(32)] public CAudioFadeData? _audioFadeData;
    }
}
