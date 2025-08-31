namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CDspFlangeOverride : CDspOverride
    {
        [FieldAttr(32)] public float _dryMix = 0.44999999f;
        [FieldAttr(36)] public float _wetMix = 0.55f;
        [FieldAttr(40)] public float _depth = 1.0f;
        [FieldAttr(44)] public float _rate = 0.1f;
    }
}
