namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class CDebugMipmapClampAttr : igVisualAttribute
    {
        [FieldAttr(32)] public igVec4fMetaField _clamp = new();
        [FieldAttr(48)] public igVec4fMetaField _clamp2 = new();
    }
}
