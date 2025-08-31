namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CGraphicsPresetData : igObject
    {
        [FieldAttr(16)] public CGraphicsSettingTable? _graphicsPresetLow;
        [FieldAttr(24)] public CGraphicsSettingTable? _graphicsPresetMedium;
        [FieldAttr(32)] public CGraphicsSettingTable? _graphicsPresetHigh;
        [FieldAttr(40)] public CGraphicsSettingTable? _graphicsPresetUltra;
    }
}
