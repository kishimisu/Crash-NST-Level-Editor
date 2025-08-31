namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVfxDrawDeathEffectOperator : igVfxOperator
    {
        [FieldAttr(24)] public igHandleMetaField _effect = new();
        [FieldAttr(32)] public u32 /* igStructMetaField */ _primitiveData;
    }
}
