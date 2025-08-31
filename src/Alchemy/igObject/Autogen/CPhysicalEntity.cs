namespace Alchemy
{
    [ObjectAttr(296, 8)]
    public class CPhysicalEntity : CGameEntity
    {
        [ObjectAttr(1)]
        public class RuntimeFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _removeOnDeath = true;
            [FieldAttr(1, size: 1)] public bool _netDeath;
            [FieldAttr(2, size: 1)] public bool _hasDied;
            [FieldAttr(3, size: 1)] public bool _immunityCallbackRegistered;
        }

        [FieldAttr(224)] public igVectorMetaField<CHealthObject> _healthObjects = new();
        [FieldAttr(248)] public int _healthMax = -1;
        [FieldAttr(252)] public int _unadjustedMaxHealth = -1;
        [FieldAttr(256)] public float _lastBeamAttackedTime;
        [FieldAttr(260)] public EVulnerability _vulnerability = EVulnerability.eV_Invalid;
        [FieldAttr(264)] public CEnableRequestManager? _invulnerable;
        [FieldAttr(272)] public CAttackNumberTimestampTable? _recentAttackNumberTimestampTable;
        [FieldAttr(280)] public CAttackImmunityTimestampTable? _recentAttackImmunityTimestampTable;
        [FieldAttr(288)] public RuntimeFlags _runtimeFlags = new();
    }
}
