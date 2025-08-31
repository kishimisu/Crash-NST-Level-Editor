namespace Alchemy
{
    [ObjectAttr(88, 8, metaType: typeof(CRespawnHistoryRecorderHandler))]
    public class CRespawnHistoryRecorderHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public float _updateInterval = 0.1f;
    }
}
