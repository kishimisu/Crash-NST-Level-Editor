namespace Alchemy
{
    [ObjectAttr(120, 4)]
    public class igVfxRangedCurveSpawnRateData : igVfxSpawnRateData
    {
        [FieldAttr(32)] public igVfxRangedCurveMetaField _rateCurve = new();
    }
}
