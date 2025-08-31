namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CHavokPrismaticConstraintData : CHavokConstraintData
    {
        [FieldAttr(32)] public EConstraintAxis _movementAxis;
        [FieldAttr(36)] public EConstraintAxis _rotationAxis;
        [FieldAttr(40)] public bool _allowRotationAroundAxis;
    }
}
