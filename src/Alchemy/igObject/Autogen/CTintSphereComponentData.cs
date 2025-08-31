namespace Alchemy
{
    [ObjectAttr(64, 4)]
    public class CTintSphereComponentData : igComponentData
    {
        [FieldAttr(24)] public bool _ignoreOcclusionBoxes;
        [FieldAttr(28)] public float _radius = 1.0f;
        [FieldAttr(32)] public igVec3fMetaField _color = new();
        [FieldAttr(44)] public float _intensity = 1.0f;
        [FieldAttr(48)] public float _additiveness;
        [FieldAttr(52)] public bool _depthBlendingEnabled;
        [FieldAttr(56)] public float _depthBlendingSoftness = 14.0f;
    }
}
