namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 144, align: 16)]
    public class CTintSphereBundle : igShaderConstantBundle
    {
        [FieldAttr(nst: 32, ctr: 32)] public igMatrix44fMetaField _inverseModelMatrix = new();
        [FieldAttr(nst: 96, ctr: 96)] public igVec4fMetaField _color = new();
        [FieldAttr(ctr: 112)] public float _fadingDistance;
        [FieldAttr(ctr: 116)] public float _fadingRange;
        [FieldAttr(nst: 112, ctr: 120)] public float _additiveness = 1.0f;
        [FieldAttr(nst: 116, ctr: 124)] public float _invDepthSoftness = 1.0f;
        [FieldAttr(nst: 120, ctr: 128)] public bool _depthBlendingEnabled;
    }
}
