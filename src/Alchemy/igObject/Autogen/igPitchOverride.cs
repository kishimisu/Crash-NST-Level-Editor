namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igPitchOverride : igObject
    {
        [FieldAttr(16)] public float _pitch;
        [FieldAttr(24, false)] public CSoundInstance? _owner;
    }
}
