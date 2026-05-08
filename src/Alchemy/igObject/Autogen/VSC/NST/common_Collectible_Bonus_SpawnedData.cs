namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 40, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Collectible_Bonus_SpawnedData : CVscComponentData
    {
        public enum EBonusRoundType
        {
            defaultValue = 0,
            Tawna = 1,
            Brio = 2,
            Cortex = 3,
        }

        [FieldAttr(nst: 40, ctr: 32)] public EBonusRoundType _BonusRoundType;
    }
}
