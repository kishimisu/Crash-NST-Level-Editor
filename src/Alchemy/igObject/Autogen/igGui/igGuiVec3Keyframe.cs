namespace Alchemy
{
    [ObjectAttr(80, 4)]
    public class igGuiVec3Keyframe : igGuiFieldKeyframe
    {
        [FieldAttr(32)] public float _handleInTime;
        [FieldAttr(36)] public float _handleOutTime;
        [FieldAttr(40)] public igVec3fMetaField _data = new();
        [FieldAttr(52)] public igVec3fMetaField _handleInData = new();
        [FieldAttr(64)] public igVec3fMetaField _handleOutData = new();
    }
}
