namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CFadeSequencePresetData : igObject
    {
        [FieldAttr(16)] public float _fadeOutDuration;
        [FieldAttr(24)] public CAudioFadeData? _fadeOutAudioFadeData;
        [FieldAttr(32)] public float _holdDuration;
        [FieldAttr(36)] public float _fadeInDuration;
        [FieldAttr(40)] public CAudioFadeData? _fadeInAudioFadeData;
        [FieldAttr(48)] public Color? _color;
    }
}
