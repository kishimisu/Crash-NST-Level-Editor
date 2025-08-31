namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVfxSpawnRate : igVfxRuntimeObject
    {
        [FieldAttr(16)] public igVfxSpawnRateData? _source;
        [FieldAttr(24)] public float _remainder;
        [FieldAttr(28)] public igRandomMetaField _random = new();
    }
}
