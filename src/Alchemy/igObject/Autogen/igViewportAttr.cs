namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class igViewportAttr : igVisualAttribute
    {
        [FieldAttr(24)] public int _x;
        [FieldAttr(28)] public int _y;
        [FieldAttr(32)] public int _w;
        [FieldAttr(36)] public int _h;
        [FieldAttr(40)] public float _nearZ;
        [FieldAttr(44)] public float _farZ = 1.0f;
    }
}
