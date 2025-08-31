namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CVfxDrawEntityFadeOperator : igVfxDrawOperator
    {
        [FieldAttr(32)] public bool _applyToBoltOns = true;
        [FieldAttr(36)] public u32 /* igStructMetaField */ _primitive;
    }
}
