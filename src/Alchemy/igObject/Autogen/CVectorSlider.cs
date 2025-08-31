namespace Alchemy
{
    [ObjectAttr(120, 8, metaObject: true)]
    public class CVectorSlider : Object
    {
        [FieldAttr(32)] public igVec3fMetaField _vector = new();
        [FieldAttr(48)] public Vector3? _vectorArg;
        [FieldAttr(56)] public igVec3fMetaField _startingVector = new();
        [FieldAttr(68)] public igVec3fMetaField _endingVector = new();
        [FieldAttr(80)] public CSlider? _slider;
        [FieldAttr(88)] public igHandleMetaField _callbackOwner = new();
        [FieldAttr(96)] public igRawRefMetaField _onUpdate = new();
        [FieldAttr(104)] public igRawRefMetaField _onCompletion = new();
        [FieldAttr(112)] public igRawRefMetaField _onStartReached = new();
    }
}
