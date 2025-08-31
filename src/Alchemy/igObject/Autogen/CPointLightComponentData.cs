namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class CPointLightComponentData : igComponentData
    {
        [FieldAttr(32)] public igVec4fMetaField _color = new();
        [FieldAttr(48)] public float _intensity = 1.0f;
        [FieldAttr(52)] public float _radius = 200.0f;
        [FieldAttr(56)] public EBakeLight _lightBakeType;
        [FieldAttr(60)] public bool _distanceCull = true;
    }
}
