namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CPriorityDspOverrideSet : CDspOverrideSet
    {
        [FieldAttr(48)] public int _priority = -1;
        [FieldAttr(52)] public float _activeTime = -1.0f;
        [FieldAttr(56)] public float _fadeOutTime = 2.0f;
    }
}
