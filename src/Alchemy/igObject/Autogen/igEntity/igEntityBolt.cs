namespace Alchemy
{
    [ObjectAttr(24, 8)]
    public class igEntityBolt : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _entityToBoltTo = new();
    }
}
