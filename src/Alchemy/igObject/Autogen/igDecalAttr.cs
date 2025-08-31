namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igDecalAttr : igVisualAttribute
    {
        [FieldAttr(24)] public float _decalOffset;
        [FieldAttr(28)] public float _decalSlope;
    }
}
