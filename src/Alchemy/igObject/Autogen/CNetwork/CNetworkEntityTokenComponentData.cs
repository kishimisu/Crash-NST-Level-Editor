namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 8)]
    public class CNetworkEntityTokenComponentData : CEntityComponentData
    {
        public enum EDropOnDamageScale
        {
            kDropOnDamageAbsolute = 0,
            kDropOnDamagePercentOfMax = 1,
        }

        [FieldAttr(nst: 24, ctr: 16)] public bool _attackerAcquires;
        [FieldAttr(nst: 28, ctr: 20)] public float _exclusiveAcquireTimeout;
        [FieldAttr(nst: 32, ctr: 24)] public float _reacquireTimeout;
        [FieldAttr(nst: 36, ctr: 28)] public bool _allowRemoteAcquireRequest = true;
        [FieldAttr(nst: 37, ctr: 29)] public bool _useAcquireCounter;
        [FieldAttr(ctr: 30)] public bool _hideOnAcquire;
        [FieldAttr(nst: 38, ctr: 31)] public bool _dropOnDamage;
        [FieldAttr(nst: 40, ctr: 32)] public EDropOnDamageScale _dropOnDamageScale;
        [FieldAttr(nst: 44, ctr: 36)] public float _damageDropAmount = 1.0f;
        [FieldAttr(nst: 48, ctr: 40)] public bool _allowRemoteDropRequest = true;
        [FieldAttr(nst: 49, ctr: 41)] public bool _hostOnly;
        [FieldAttr(nst: 50, ctr: 42)] public bool _boltToAcquiringEntity;
        [FieldAttr(nst: 56, ctr: 48)] public CBoltPoint? _tokenBolt;
    }
}
