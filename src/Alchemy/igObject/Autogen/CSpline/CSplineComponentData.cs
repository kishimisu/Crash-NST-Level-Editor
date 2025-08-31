namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CSplineComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public igSpline2? _spline;
        [FieldAttr(32)] public igSpline? _deprecatedSpline;
    }
}
