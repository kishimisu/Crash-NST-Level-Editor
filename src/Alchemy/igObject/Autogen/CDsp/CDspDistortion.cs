namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CDspDistortion : CDsp
    {
        [FieldAttr(48)] public float _level = 0.5f;
        [FieldAttr(52)] public float _levelValue;
    }
}
