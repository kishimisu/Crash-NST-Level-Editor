namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igVfxCurveInputByAngleOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class Flags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public ESourceAxis _instanceAxis = ESourceAxis.eSA_ZAxis;
            [FieldAttr(3, size: 1)] public bool _instanceFlip;
            [FieldAttr(4, size: 4)] public EReferenceFrame _referenceFrame = EReferenceFrame.eRF_World;
            [FieldAttr(8, size: 3)] public ESourceAxis _referenceAxis = ESourceAxis.eSA_XAxis;
            [FieldAttr(11, size: 1)] public bool _referenceFlip;
        }

        [FieldAttr(24)] public Flags _flags = new();
        [FieldAttr(28)] public EOperatorCurveOutput _outputParameter = EOperatorCurveOutput.kSetTrackParameter1;
        [FieldAttr(32)] public float _minAngle;
        [FieldAttr(36)] public float _maxAngle = 180.0f;
    }
}
