namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igVelocityFrameReference : igFrameReferenceBase
    {
        [FieldAttr(24)] public igVec3fMetaField _lastPosition = new();
    }
}
