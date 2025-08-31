namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CHavokLimitedHingeConstraintData : CHavokConstraintData
    {
        [FieldAttr(32)] public float _minAngle = -180.0f;
        [FieldAttr(36)] public float _maxAngle = 180.0f;
        [FieldAttr(40)] public float _angularStrengthFactor = 1.0f;
        [FieldAttr(44)] public float _maxFrictionTorque;
    }
}
