namespace Alchemy
{
    [ObjectAttr(96, 16)]
    public class COutdoorLightComponentData : igComponentData
    {
        [FieldAttr(32)] public igVec4fMetaField _color = new();
        [FieldAttr(48)] public float _intensity = 1.0f;
        [FieldAttr(64)] public igVec4fMetaField _bias = new();
        [FieldAttr(80)] public float _shadowRange = 3000.0f;
        [FieldAttr(84)] public float _shadowSplitDistribution = 0.89999998f;
    }
}
