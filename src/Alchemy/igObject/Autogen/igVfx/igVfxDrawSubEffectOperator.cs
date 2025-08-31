namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igVfxDrawSubEffectOperator : igVfxDrawOperator
    {
        public enum ESubEffectSecondBolt : uint
        {
            kBoltNone = 0,
            kBolt1Follow = 1,
            kBolt1Position = 2,
            kSpawnPosition = 3,
            kBolt2Follow = 4,
            kBolt2Position = 5,
        }

        public enum ESubEffectChildKill : uint
        {
            kDontKill = 0,
            kSoftKill = 1,
            kHardKill = 2,
        }

        public enum ESubEffectChainMode : uint
        {
            kChainNone = 0,
            kChainTail = 1,
            kChainHead = 2,
        }

        public enum ESubEffectChainOrientationMode : uint
        {
            kChainOrientationForward = 0,
            kChainOrientationReverse = 1,
            kChainOrientationAlternate = 2,
            kChainOrientationRandom = 3,
        }

        [ObjectAttr(2)]
        public class SubEffectFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public igVfxDrawSubEffectOperator.ESubEffectSecondBolt _secondBolt = igVfxDrawSubEffectOperator.ESubEffectSecondBolt.kBolt2Follow;
            [FieldAttr(3, size: 2)] public igVfxDrawSubEffectOperator.ESubEffectChildKill _childKill = igVfxDrawSubEffectOperator.ESubEffectChildKill.kDontKill;
            [FieldAttr(5, size: 2)] public igVfxDrawSubEffectOperator.ESubEffectChainMode _chain;
            [FieldAttr(7, size: 2)] public igVfxDrawSubEffectOperator.ESubEffectChainOrientationMode _chainOrientation;
            [FieldAttr(9, size: 1)] public bool _floatingChain = false;
        }

        [FieldAttr(32)] public SubEffectFlags _subEffectFlags = new();
        [FieldAttr(36)] public u32 /* igStructMetaField */ _instanceData;
        [FieldAttr(40)] public u32 /* igStructMetaField */ _primitiveData;
        [FieldAttr(48)] public igHandleMetaField _effect = new();
        [FieldAttr(56)] public igRangedFloatMetaField _chainLength = new();
    }
}
