namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CFilterByVerticalRange : CFilterMethod
    {
        [FieldAttr(24)] public float _verticalRangeAbove;
        [FieldAttr(28)] public float _verticalRangeBelow;
        [FieldAttr(32)] public bool _relativeToCenter = true;
    }
}
