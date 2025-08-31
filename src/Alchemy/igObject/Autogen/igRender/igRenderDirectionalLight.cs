namespace Alchemy
{
    [ObjectAttr(96, 16)]
    public class igRenderDirectionalLight : igRenderLight
    {
        [FieldAttr(80)] public igVec4fMetaField _direction = new();
    }
}
