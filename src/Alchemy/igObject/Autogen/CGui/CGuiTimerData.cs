namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CGuiTimerData : igObject
    {
        [FieldAttr(16)] public CTimer? _timer;
        [FieldAttr(24)] public float _timerDuration;
        [FieldAttr(32)] public igHandleMetaField _entity = new();
        [FieldAttr(40)] public CBoltPoint? _boltPoint;
    }
}
