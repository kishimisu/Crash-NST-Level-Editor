namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 64, align: 8)]
    public class CCombatTargetData : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public igHandleMetaField _targetEntity = new();
        [FieldAttr(nst: 24, ctr: 24)] public igVec3fMetaField _aimedPosition = new();
        [FieldAttr(nst: 36, ctr: 36)] public igVec3fMetaField _targetNormal = new();
        [FieldAttr(nst: 48, ctr: 48)] public float _priority = -3.4028234663852886e+38f;
        [FieldAttr(nst: 56, ctr: 56)] public igHandleMetaField _registeredDelegatesComponent = new();
    }
}
