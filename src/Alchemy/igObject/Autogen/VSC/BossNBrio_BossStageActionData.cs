namespace Alchemy
{
    // VSC object extracted from: BossNBrio_BossStageAction_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class BossNBrio_BossStageActionData : CVscComponentData
    {
        public enum EBossStageActionType
        {
            PotionThrowGreen = 0,
            PotionThrowPurple = 1,
            HulkTransform = 2,
        }

        [FieldAttr(40)] public EBossStageActionType _BossStageActionType;
        [FieldAttr(44)] public float _DelayStart;
        [FieldAttr(48)] public float _PotionThrowGreenPlayerDistanceInfluenceRatio;
        [FieldAttr(56)] public igHandleMetaField _GreenPotionThrowTargetWaypt = new();
    }
}
