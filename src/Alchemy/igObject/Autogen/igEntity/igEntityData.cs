namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igEntityData : igObject
    {
        [FieldAttr(16)] public igComponentDataTable? _componentData;
        [FieldAttr(24)] public float _scale = 1.0f;
        [FieldAttr(28)] public uint _networkFlags;
    }
}
