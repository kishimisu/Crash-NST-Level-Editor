namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CVScriptFindGroundQueryHolder : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _query = new();
        [FieldAttr(24)] public igVscVec3fDelegateMetaField _groundPositionCallback = new();
        [FieldAttr(40)] public igVscVec3fDelegateMetaField _groundNormalCallback = new();
        [FieldAttr(56)] public igVscDelegateMetaField _finishedCallback = new();
        [FieldAttr(72)] public igVscDelegateMetaField _failedCallback = new();
    }
}
