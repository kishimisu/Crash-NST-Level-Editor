namespace Alchemy
{
    [ObjectAttr(64, 8, metaObject: true)]
    public class CSliderData : Object
    {
        [FieldAttr(32)] public float _startingValue;
        [FieldAttr(36)] public float _endingValue;
        [FieldAttr(40)] public float _totalDuration;
        [FieldAttr(44)] public float _easeInDuration;
        [FieldAttr(48)] public float _easeOutDuration;
        [FieldAttr(52)] public EigEaseType _easeType = EigEaseType.kEaseTypeQuadratic;
        [FieldAttr(56)] public ESliderMode _mode;
    }
}
