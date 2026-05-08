namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 48, align: 16)]
    public class CDebugHighlightColorBundle : igShaderConstantBundle
    {
        [FieldAttr(nst: 32, ctr: 32)] public igVec4fMetaField _color = new();
    }
}
