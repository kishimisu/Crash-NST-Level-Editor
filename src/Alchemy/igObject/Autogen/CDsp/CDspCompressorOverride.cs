namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 48, align: 8)]
    public class CDspCompressorOverride : CDspOverride
    {
        [FieldAttr(nst: 32, ctr: 28)] public float _threshold;
        [FieldAttr(nst: 36, ctr: 32)] public float _attack = 50.0f;
        [FieldAttr(nst: 40, ctr: 36)] public float _release = 50.0f;
        [FieldAttr(nst: 44, ctr: 40)] public float _makeUpGain;
    }
}
