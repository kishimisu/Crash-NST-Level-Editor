namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CFadeInPresetData : igObject
    {
        [FieldAttr(16)] public float _duration;
        [FieldAttr(24)] public CAudioFadeData? _audioFadeData;
    }
}
