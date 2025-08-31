namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igDepthBoundsStateAttr : igVisualAttribute
    {
        [FieldAttr(24)] public bool _enabled;
        [FieldAttr(28)] public float _minZ;
        [FieldAttr(32)] public float _maxZ = 1.0f;
    }
}
