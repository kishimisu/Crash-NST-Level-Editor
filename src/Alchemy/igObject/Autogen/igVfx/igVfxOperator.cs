namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class igVfxOperator : igObject
    {
        [ObjectAttr(4)]
        public class OperatorFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _enabled = true;
            [FieldAttr(1, size: 1)] public bool _visualize = false;
            [FieldAttr(2, size: 1)] public bool _valid;
            [FieldAttr(3, size: 2)] public EStackType _stackType = EStackType.kStackEffect;
            [FieldAttr(5, size: 1)] public bool _dirty;
        }

        [FieldAttr(16)] public OperatorFlags _operatorFlags = new();
    }
}
