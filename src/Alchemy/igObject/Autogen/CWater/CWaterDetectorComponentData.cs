namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CWaterDetectorComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CSourceData? _sourceData;
    }
}
