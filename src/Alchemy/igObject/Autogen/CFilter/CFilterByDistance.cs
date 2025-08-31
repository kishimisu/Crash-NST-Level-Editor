namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CFilterByDistance : CFilterMethod
    {
        [FieldAttr(24)] public float _rangeRestriction;
        [FieldAttr(28)] public bool _useExtents;
    }
}
