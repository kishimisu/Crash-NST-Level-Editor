namespace Alchemy
{
    [ObjectAttr(96, 8, metaType: typeof(CBehaviorLogic))]
    public class Scripts_TimeOutHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public RangedFloat? TimeOutTime;
        [FieldAttr(88)] public float InputCheckTime = 1.0f;
        [FieldAttr(92)] public bool AllowRandomStartState = true;
    }
}
