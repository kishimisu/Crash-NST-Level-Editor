namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CDspLowPassSimple : CDsp
    {
        [FieldAttr(48)] public float _cutoffFreq = 5000.0f;
        [FieldAttr(52)] public float _cutoffFreqValue;
    }
}
