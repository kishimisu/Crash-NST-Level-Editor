namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CVScriptCastQueryHolder : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _query = new();
        [FieldAttr(24)] public CNovaCollisionInfoListVscDelegateMetaField _collisionListDelegate = new();
        [FieldAttr(40)] public igVscDelegateMetaField _finishedCallback = new();
        [FieldAttr(56)] public igVscDelegateMetaField _failedCallback = new();
    }
}
