namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 40, align: 8)]
    public class CNetworkDisableDefaultReplicationComponentData : CEntityComponentData
    {
        [FieldAttr(nst: 24, ctr: 16)] public bool _startEnabled = true;
        [FieldAttr(nst: 25, ctr: 17)] public bool _allowDisable;
        [FieldAttr(nst: 28, ctr: 20)] public EReplication _positionReplication;
        [FieldAttr(nst: 32, ctr: 24)] public EReplication _rotationReplication;
        [FieldAttr(nst: 36, ctr: 28)] public EReplication _scaleReplication;
        [FieldAttr(nst: 40, ctr: 32)] public CNetworkDisableDefaultReplicationTable? _otherFieldsReplication;
    }
}
