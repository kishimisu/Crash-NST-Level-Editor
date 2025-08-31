namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CDspHighPassSimple : CDsp
    {
        [FieldAttr(48)] public float _cutoffFreq = 1000.0f;
        [FieldAttr(52)] public float _cutoffFreqValue;
    }
}
