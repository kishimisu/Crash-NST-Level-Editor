namespace Alchemy
{
    [ObjectAttr(12, 8)]
    public class igVfxCurveKeyframe : igMetaField
    {
        [FieldAttr(0)] public float _range;
        [FieldAttr(4)] public bool _linear;
        [FieldAttr(5)] public i8 _x;
        [FieldAttr(6)] public i8 _y;
        [FieldAttr(7)] public i8 _variance;
        [FieldAttr(8)] public i8 _data1;
        [FieldAttr(9)] public i8 _data2;
    }

    [ObjectAttr(84, 8)]
    public class igVfxRangedCurveMetaField : igMetaField
    {
        [FieldAttr(0)] public igVfxCurveKeyframe[] _keyframes = new igVfxCurveKeyframe[5];
        [FieldAttr(60)] public igVfxModulationHelper _modulationHelper = new();
        [FieldAttr(80)] public u16 _unknown_0x50;
        [FieldAttr(82)] public u16 _unknown_0x52;
    }
}
