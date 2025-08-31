namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVfxSpawnGroupPassInfo : igObject
    {
        [FieldAttr(16)] public igVectorMetaField<u8> _passIds = new();
        [FieldAttr(40)] public string? _modelClass = null;
    }
}
