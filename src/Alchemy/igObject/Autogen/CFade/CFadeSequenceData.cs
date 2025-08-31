namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CFadeSequenceData : igObject
    {
        [FieldAttr(16)] public float _holdDuration;
        [FieldAttr(20)] public float _fadeInDuration;
        [FieldAttr(24, false)] public CAudioFadeData? _fadeInAudioFadeData;
        [FieldAttr(32)] public igVscDelegateMetaField _holdComplete = new();
        [FieldAttr(48)] public igVscDelegateMetaField _fadeInComplete = new();
        [FieldAttr(64)] public CScopedScheduledFunction? _holdScheduledFunction;
    }
}
