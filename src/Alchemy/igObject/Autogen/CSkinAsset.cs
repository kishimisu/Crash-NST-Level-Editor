namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CSkinAsset : CAsset
    {
        [FieldAttr(24)] public CGraphicsSkinInfo? _skinInfo;
    }
}
