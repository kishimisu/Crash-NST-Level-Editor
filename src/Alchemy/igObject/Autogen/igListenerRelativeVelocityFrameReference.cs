namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class igListenerRelativeVelocityFrameReference : igFrameReferenceBase
    {
        [FieldAttr(24)] public igVec3fMetaField _lastPosition = new();
        [FieldAttr(36)] public igVec3fMetaField _lastListenerPosition = new();
    }
}
