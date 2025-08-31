namespace Alchemy
{
    [ObjectAttr(112, 16)]
    public class CBoxLightComponentData : igComponentData
    {
        [FieldAttr(32)] public igVec4fMetaField _color = new();
        [FieldAttr(48)] public float _intensity = 1.0f;
        [FieldAttr(52)] public igVec3fMetaField _dimensions = new();
        [FieldAttr(64)] public float _nearAttenuation;
        [FieldAttr(68)] public float _attenuation;
        [FieldAttr(72)] public float _xFalloff;
        [FieldAttr(76)] public float _yFalloff;
        [FieldAttr(80)] public float _wrap;
        [FieldAttr(88)] public string? _cookieTextureName = "loosetextures";
        [FieldAttr(96)] public igVfxAnimatedFrame? _uvAnimation;
        [FieldAttr(104)] public EBakeLight _lightBakeType;
        [FieldAttr(108)] public bool _distanceCull = true;
    }
}
