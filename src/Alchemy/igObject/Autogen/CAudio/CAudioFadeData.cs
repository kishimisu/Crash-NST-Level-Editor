namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CAudioFadeData : igObject
    {
        [FieldAttr(16)] public float _duration;
        [FieldAttr(24)] public igStringFloatHashTable? _channelGroupVolumes;
    }
}
