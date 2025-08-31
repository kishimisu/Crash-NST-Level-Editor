namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVfxSizeBaseOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class SizeFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public EModulation _modulation = EModulation.kModulate;
        }

        [FieldAttr(24)] public SizeFlags _sizeFlags = new();
    }
}
