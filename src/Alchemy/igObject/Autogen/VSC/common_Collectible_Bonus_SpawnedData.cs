namespace Alchemy
{
    // VSC object extracted from: common_Collectible_Bonus_Spawned_c.igz

    [ObjectAttr(48, metaType: typeof(CVscComponentData))]
    public class common_Collectible_Bonus_SpawnedData : CVscComponentData
    {
        public enum EBonusRoundType
        {
            defaultValue = 0,
            Tawna = 1,
            Brio = 2,
            Cortex = 3,
        }

        [FieldAttr(40)] public EBonusRoundType _BonusRoundType;
    }
}
