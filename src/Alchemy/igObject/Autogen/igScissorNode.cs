namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class igScissorNode : igGroup
    {
        [FieldAttr(64)] public igVec3fMetaField _min = new();
        [FieldAttr(76)] public igVec3fMetaField _max = new();
        [FieldAttr(88)] public igVec2fMetaField _screenSize = new();
    }
}
