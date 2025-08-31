namespace Alchemy
{
    [ObjectAttr(128, 16)]
    public class igEntityTransform : igObject
    {
        [FieldAttr(16)] public igQuaternionfMetaField _parentSpaceOrientation = new();
        [FieldAttr(32)] public igMatrix44fMetaField _parentSpaceTransform = new();
        [FieldAttr(96)] public igVec3fMetaField _parentSpaceRotation = new();
        [FieldAttr(108)] public float _runtimeParentSpaceScale = 1.0f;
        [FieldAttr(112)] public igVec3fMetaField _nonUniformPersistentParentSpaceScale = new();
        [FieldAttr(124)] public bool _isDirty = true;
    }
}
