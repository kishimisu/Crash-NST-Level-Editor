namespace Alchemy
{
    [ObjectAttr(88, 8, metaType: typeof(CChangeCollisionPriorityHandler))]
    public class CChangeCollisionPriorityHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public ECharacterCollisionPriority _collisionPriority = ECharacterCollisionPriority.eCCP_High;
    }
}
