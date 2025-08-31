namespace Alchemy
{
    [ObjectAttr(88, 8, metaType: typeof(CTrajectoryAlignmentHandler))]
    public class CTrajectoryAlignmentHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public float _maxTurnRate = 360.0f;
    }
}
