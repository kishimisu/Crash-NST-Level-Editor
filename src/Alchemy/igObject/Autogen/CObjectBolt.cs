namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CObjectBolt : igObject
    {
        [FieldAttr(16)] public EBoltonModels _boltOn = EBoltonModels.EBOLTON_NONE;
        [FieldAttr(24)] public igHandleMetaField _owner = new();
        [FieldAttr(32)] public igHandleMetaField _modelBoltPoint = new();
        [FieldAttr(40)] public igHandleMetaField _boltOnBoltPoint = new();
        [FieldAttr(48)] public EObjectBoltType _type;
        [FieldAttr(52)] public bool _warned;
        [FieldAttr(53)] public bool _isFakeBolt;
        [FieldAttr(56)] public igVec3fMetaField _boltOffset = new();
        [FieldAttr(68)] public bool _worldAlign;
    }
}
