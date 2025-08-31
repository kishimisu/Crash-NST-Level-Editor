namespace Alchemy
{
    [ObjectAttr(64, 4)]
    public class igGuiVec2Keyframe : igGuiFieldKeyframe
    {
        [FieldAttr(32)] public float _handleInTime;
        [FieldAttr(36)] public float _handleOutTime;
        [FieldAttr(40)] public igVec2fMetaField _data = new();
        [FieldAttr(48)] public igVec2fMetaField _handleInData = new();
        [FieldAttr(56)] public igVec2fMetaField _handleOutData = new();
    }
}
