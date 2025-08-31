namespace Alchemy
{
    [ObjectAttr(56, 4)]
    public class igGuiFloatKeyframe : igGuiFieldKeyframe
    {
        [FieldAttr(32)] public float _handleInTime;
        [FieldAttr(36)] public float _handleOutTime;
        [FieldAttr(40)] public float _data;
        [FieldAttr(44)] public float _handleInData;
        [FieldAttr(48)] public float _handleOutData;
    }
}
