namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igGuiFieldTrack : igGuiTrack
    {
        [FieldAttr(24, false)] public igMetaFieldInstance? _targetField;
        [FieldAttr(32)] public int _fieldOffset;
        [FieldAttr(36)] public igGuiKeyframe.EInterpolationMode _interpolation = igGuiKeyframe.EInterpolationMode.kInterpolationLinear;
        [FieldAttr(40)] public bool _offsetMode;
    }
}
