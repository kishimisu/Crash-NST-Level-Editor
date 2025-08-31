namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CNetworkAnimationReplicaComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CAnimationSubStatesDataTable? _synchronizedStates;
        [FieldAttr(32)] public bool _forceNotify;
        [FieldAttr(33)] public bool _disableOnDeath;
    }
}
