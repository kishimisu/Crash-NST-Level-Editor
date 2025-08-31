namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CEntityMessage))]
    public class Scripts_VictimEntityMessage : CEntityMessage
    {
        public enum EVictimStates : uint
        {
            None = 0,
            AirBlown = 1,
            Bubble = 2,
            CatchBomb = 3,
            CatchFirework = 4,
            Cower = 5,
            Dance = 6,
            Devour = 7,
            Electrified = 8,
            FirePanic = 9,
            Freeze = 10,
            Hypnotize = 11,
            Ill = 12,
            Ink = 13,
            Jaded = 14,
            LookAtThat = 15,
            Magnet_Levitate = 16,
            Magnet_Shake = 17,
            Smell = 18,
            Stoned = 19,
            Stunned = 20,
            StuckBall = 21,
            TornadoSpin = 22,
            Whirlwind = 23,
            WhirlwindWithFacing = 24,
            Golden = 25,
        }

        [FieldAttr(56)] public float TimeOverride = -1.0f;
        [FieldAttr(60)] public bool InfiniteTime;
        [FieldAttr(64)] public EVictimStates VictimState;
    }
}
