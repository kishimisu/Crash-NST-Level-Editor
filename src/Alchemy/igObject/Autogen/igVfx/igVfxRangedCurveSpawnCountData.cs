namespace Alchemy
{
    [ObjectAttr(120, 4)]
    public class igVfxRangedCurveSpawnCountData : igVfxSpawnRateData
    {
        [FieldAttr(32)] public igVfxRangedCurveMetaField _countCurve = new();
    }
}
