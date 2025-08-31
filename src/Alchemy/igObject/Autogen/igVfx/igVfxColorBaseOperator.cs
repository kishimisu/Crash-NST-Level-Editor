namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVfxColorBaseOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class ColorFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public EModulation _colorModulation = EModulation.kModulate;
            [FieldAttr(3, size: 3)] public EModulation _alphaModulation = EModulation.kReplace;
        }

        [FieldAttr(24)] public ColorFlags _colorFlags = new();
    }
}
