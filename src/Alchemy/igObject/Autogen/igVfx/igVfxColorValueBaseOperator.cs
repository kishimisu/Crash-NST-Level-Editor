namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igVfxColorValueBaseOperator : igVfxFrameOperator
    {
        public enum EMode : uint
        {
            kValue = 0,
            kLightness = 1,
            kSaturation = 2,
        }

        [ObjectAttr(4)]
        public class ColorValueFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 2)] public igVfxColorValueBaseOperator.EMode _mode;
            [FieldAttr(2, size: 3)] public EModulation _modulation;
        }

        [FieldAttr(32)] public ColorValueFlags _colorValueFlags = new();
    }
}
