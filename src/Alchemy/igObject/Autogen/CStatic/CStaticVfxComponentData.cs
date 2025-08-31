namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CStaticVfxComponentData : igComponentData
    {
        [FieldAttr(24)] public igHandleMetaField _effect = new();
        [FieldAttr(32)] public bool _startSpawned = true;
        [FieldAttr(40)] public igHandleMetaField _boltPoint2 = new();
        [FieldAttr(48)] public igHandleMetaField _boltObject2 = new();
    }
}
