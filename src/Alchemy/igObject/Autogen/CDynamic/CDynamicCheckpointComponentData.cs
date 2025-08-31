namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CDynamicCheckpointComponentData : CEntityComponentData
    {
        [ObjectAttr(1)]
        public class Storage : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _triggerOnEnter;
            [FieldAttr(1, size: 1)] public bool _triggerOnDamage;
            [FieldAttr(2, size: 1)] public bool _triggerOnDeath;
        }

        [FieldAttr(24)] public bool _startEnabled = true;
        [FieldAttr(32)] public CCameraBase? _camera;
        [FieldAttr(40)] public igHandleMetaField _checkpoint = new();
        [FieldAttr(48)] public igVec3fMetaField _dynamicCheckpointOffset = new();
        [FieldAttr(60)] public Storage _storage = new();
    }
}
