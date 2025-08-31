namespace Alchemy
{
    [ObjectAttr(80, 16)]
    public class CVertexWibbleParametersBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _amplitude = new();
        [FieldAttr(48)] public igVec4fMetaField _frequency = new();
        [FieldAttr(64)] public igVec4fMetaField _phase = new();
    }
}
