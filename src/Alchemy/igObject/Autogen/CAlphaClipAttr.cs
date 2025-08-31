namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CAlphaClipAttr : igVisualAttribute
    {
        [FieldAttr(24)] public bool _enable;
        [FieldAttr(28)] public float _threshold = 0.5f;
    }
}
