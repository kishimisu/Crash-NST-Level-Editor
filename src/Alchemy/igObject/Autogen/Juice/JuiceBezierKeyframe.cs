namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class JuiceBezierKeyframe : JuiceFloatKeyframe
    {
        [FieldAttr(32)] public igVec2fMetaField _handleIn = new();
        [FieldAttr(40)] public igVec2fMetaField _handleOut = new();
    }
}
