namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CVfxDrawEntityMaterialOverrideOperator : igVfxDrawOperator
    {
        [FieldAttr(32)] public bool _applyToBoltOns = true;
        [FieldAttr(40)] public CFxMaterialRedirectTable? _materialOverrides;
        [FieldAttr(48)] public u32 /* igStructMetaField */ _primitive;
    }
}
