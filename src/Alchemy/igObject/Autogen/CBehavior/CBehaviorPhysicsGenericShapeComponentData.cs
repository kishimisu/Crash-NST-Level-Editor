namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CBehaviorPhysicsGenericShapeComponentData : CBehaviorPhysicsComponentData
    {
        [FieldAttr(72)] public CShape? _shape;
    }
}
