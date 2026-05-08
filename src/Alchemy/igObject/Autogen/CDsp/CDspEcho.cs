namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 8)]
    public class CDspEcho : CDsp
    {
        [FieldAttr(nst: 48, ctr: 40)] public float _delay = 500.0f;
        [FieldAttr(nst: 52, ctr: 44)] public float _decay = 0.5f;
        [FieldAttr(nst: 56, ctr: 48)] public float _maxChannels;
        [FieldAttr(nst: 60, ctr: 52)] public float _dryMix = 1.0f;
        [FieldAttr(nst: 64, ctr: 56)] public float _wetMix = 1.0f;
        [FieldAttr(nst: 68, ctr: 60)] public float _delayValue;
        [FieldAttr(nst: 72, ctr: 64)] public float _decayValue;
        [FieldAttr(nst: 76, ctr: 68)] public float _maxChannelsValue;
        [FieldAttr(nst: 80, ctr: 72)] public float _dryMixValue;
        [FieldAttr(nst: 84, ctr: 76)] public float _wetMixValue;
    }
}
