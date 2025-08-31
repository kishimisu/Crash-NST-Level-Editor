namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVfxAlphaBaseOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class ColorFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public EModulation _alphaModulation = EModulation.kModulate;
        }

        [FieldAttr(24)] public ColorFlags _colorFlags = new();
    }
}
