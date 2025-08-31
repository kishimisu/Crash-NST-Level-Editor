namespace Alchemy
{
    [ObjectAttr(56, 8, metaObject: true)]
    public class CActorTimeScale : Object
    {
        [FieldAttr(32)] public igHandleMetaField _actor = new();
        [FieldAttr(40)] public float _timeScale = 1.0f;
        [FieldAttr(44)] public bool _addedToActor;
        [FieldAttr(45)] public bool _activated;
        [FieldAttr(48)] public float _priority;
        [FieldAttr(52)] public bool _critical;
    }
}
