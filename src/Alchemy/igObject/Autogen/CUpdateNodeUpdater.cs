namespace Alchemy
{
    [ObjectAttr(88, 8, metaType: typeof(CUpdateNodeUpdater))]
    public class CUpdateNodeUpdater : igUpdateable
    {
        [FieldAttr(32)] public igHandleMetaField _updater = new();
        [FieldAttr(40)] public igVscDelegateMetaField _updateCallback = new();
        [FieldAttr(56)] public igVscFloatDelegateMetaField _updateDeltaCallback = new();
        [FieldAttr(72)] public float _interval = -1.0f;
        [FieldAttr(76)] public float _elapsedTime;
        [FieldAttr(80)] public float _previousFireTime;
    }
}
