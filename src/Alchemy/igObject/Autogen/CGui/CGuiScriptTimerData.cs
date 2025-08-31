namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CGuiScriptTimerData : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _timer = new();
        [FieldAttr(24)] public bool _countDown;
        [FieldAttr(32)] public igHandleMetaField _entity = new();
        [FieldAttr(40)] public igVec3fMetaField _offset = new();
    }
}
