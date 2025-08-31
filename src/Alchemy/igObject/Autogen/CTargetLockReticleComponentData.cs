namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CTargetLockReticleComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public int _maxNumberOfTargets = 1;
        [FieldAttr(32)] public igHandleMetaField _reticleEffect = new();
        [FieldAttr(40)] public CBoltPoint? _reticleBolt;
        [FieldAttr(48)] public ECombatTargetList _targetList;
    }
}
