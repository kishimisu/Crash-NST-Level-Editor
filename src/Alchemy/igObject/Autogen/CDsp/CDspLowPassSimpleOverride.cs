namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CDspLowPassSimpleOverride : CDspOverride
    {
        [FieldAttr(32)] public float _cutoffFreq = 5000.0f;
    }
}
