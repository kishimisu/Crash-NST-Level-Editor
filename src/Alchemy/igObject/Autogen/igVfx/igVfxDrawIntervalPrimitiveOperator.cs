namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVfxDrawIntervalPrimitiveOperator : igVfxOperator
    {
        [FieldAttr(24)] public igHandleMetaField _primitiveData = new();
        [FieldAttr(32)] public u32 /* igStructMetaField */ _instanceData;
    }
}
