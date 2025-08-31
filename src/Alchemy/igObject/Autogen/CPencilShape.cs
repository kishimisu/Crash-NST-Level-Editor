namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CPencilShape : CShape
    {
        [FieldAttr(16)] public float _radius = 60.0f;
        [FieldAttr(20)] public float _totalHeight = 100.0f;
        [FieldAttr(24)] public float _heightOfEnds = 25.0f;
    }
}
