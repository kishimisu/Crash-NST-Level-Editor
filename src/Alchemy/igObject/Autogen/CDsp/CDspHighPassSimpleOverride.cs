namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CDspHighPassSimpleOverride : CDspOverride
    {
        [FieldAttr(32)] public float _cutoffFreq = 1000.0f;
    }
}
