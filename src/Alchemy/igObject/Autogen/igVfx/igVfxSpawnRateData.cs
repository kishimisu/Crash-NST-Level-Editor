namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVfxSpawnRateData : igObject
    {
        public enum ETimeInput : uint
        {
            kPrimitiveTime = 0,
            kZeroTime = 1,
            kBolt1Input1 = 2,
            kBolt1Input2 = 3,
            kBolt1Input3 = 4,
            kBolt1Input4 = 5,
            kBolt2Input1 = 6,
            kBolt2Input2 = 7,
            kBolt2Input3 = 8,
            kBolt2Input4 = 9,
        }

        [FieldAttr(16)] public int _maxCount;
        [FieldAttr(20)] public int _minCount = 1;
        [FieldAttr(24)] public bool _sputter;
        [FieldAttr(25)] public bool _killOldest;
        [FieldAttr(28)] public ETimeInput _timeInput;
    }
}
