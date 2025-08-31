namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CEntityBolt : igEntityBolt
    {
        [FieldAttr(24)] public CBoltPoint? _boltSelect;
        [FieldAttr(32)] public CObjectBolt? _objectBolt;
        [FieldAttr(40)] public bool _dirty = true;
    }
}
