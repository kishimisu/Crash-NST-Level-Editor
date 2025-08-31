namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igDepthEncodingBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public float _farPlane = 1.0f;
        [FieldAttr(28)] public float _farDiv255 = 39.21569061f;
        [FieldAttr(32)] public float _oneDivFarPlane = 0.0f;
        [FieldAttr(36)] public float _255DivFarPlane = 0.0255f;
    }
}
