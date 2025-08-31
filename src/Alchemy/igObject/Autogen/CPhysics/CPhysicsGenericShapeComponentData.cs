namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CPhysicsGenericShapeComponentData : CPhysicsShapeComponentData
    {
        [FieldAttr(72)] public CShape? _shape;
    }
}
