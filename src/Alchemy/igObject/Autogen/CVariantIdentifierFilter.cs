namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CVariantIdentifierFilter : igObject
    {
        public enum EVariantIdentifierFilterType : uint
        {
            eVIFT_VariantRequiredAsActive = 0,
            eVIFT_VariantRequiredAsInactive = 1,
        }

        [FieldAttr(16)] public EVariantIdentifierFilterType _variantIdentifierFilterType;
        [FieldAttr(24)] public igHandleMetaField _variantIdentifier = new();
        [FieldAttr(32)] public bool _onlyCompareDecoId;
    }
}
