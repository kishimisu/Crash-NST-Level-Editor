namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CPrioritizedUpgrade : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _upgrade = new();
        [FieldAttr(24)] public int _priority;
    }
}
