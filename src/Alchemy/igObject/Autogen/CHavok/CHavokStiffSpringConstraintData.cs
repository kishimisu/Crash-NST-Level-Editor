namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CHavokStiffSpringConstraintData : CHavokConstraintData
    {
        [FieldAttr(32)] public float _minLength;
        [FieldAttr(36)] public float _maxLength;
    }
}
