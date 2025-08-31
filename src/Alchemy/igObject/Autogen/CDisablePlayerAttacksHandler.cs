namespace Alchemy
{
    [ObjectAttr(88, 8, metaType: typeof(CDisablePlayerAttacksHandler))]
    public class CDisablePlayerAttacksHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public uint _attackTypes = 7;
        [FieldAttr(84)] public bool _cancelCurrentAttacks;
    }
}
