namespace Alchemy
{
    [ObjectAttr(nst: 32, ctr: 24, align: 4)]
    public class CPlatformAudioSettingsOverride : igObject
    {
        [FieldAttr(nst: 16, ctr: 12)] public EIG_CORE_PLATFORM _platform;
        [FieldAttr(nst: 20, ctr: 16)] public int _sampleRate = 48000;
        [FieldAttr(nst: 24, ctr: 20)] public int _quality = 40;
    }
}
