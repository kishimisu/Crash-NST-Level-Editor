namespace Alchemy
{
    [ObjectAttr(96, 16)]
    public class igGuiVec4Keyframe : igGuiFieldKeyframe
    {
        [FieldAttr(32)] public float _handleInTime;
        [FieldAttr(36)] public float _handleOutTime;
        [FieldAttr(48)] public igVec4fMetaField _data = new();
        [FieldAttr(64)] public igVec4fMetaField _handleInData = new();
        [FieldAttr(80)] public igVec4fMetaField _handleOutData = new();
    }
}
