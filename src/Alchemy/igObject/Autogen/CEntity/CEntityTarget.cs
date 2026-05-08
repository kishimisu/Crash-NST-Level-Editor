namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 40, align: 8, meta: true)]
    public class CEntityTarget : Object
    {
        [FieldAttr(nst: 32, ctr: 32)] public igHandleMetaField _targetEntity = new();
    }
}
