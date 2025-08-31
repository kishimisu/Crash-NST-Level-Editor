namespace Alchemy
{
    [ObjectAttr(96, 8, metaType: typeof(CBehaviorLogic))]
    public class Scripts_CDropSlamHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public int _damageAmount = 999;
        [FieldAttr(84)] public int _damageRadius = 300;
        [FieldAttr(88)] public float _sidewaysMoveSpeed = 250.0f;
        [FieldAttr(92)] public float _downwardMoveSpeed = -900.0f;
    }
}
