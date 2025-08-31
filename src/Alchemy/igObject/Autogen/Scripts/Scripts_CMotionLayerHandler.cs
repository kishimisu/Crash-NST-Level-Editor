namespace Alchemy
{
    [ObjectAttr(88, 8, metaType: typeof(CBehaviorLogic))]
    public class Scripts_CMotionLayerHandler : CBehaviorLogic
    {
        public enum EMotionLayerOptions : uint
        {
            None = 0,
            Body = 1,
            Legs = 2,
            Turbo = 3,
            PrimaryMotion = 4,
            SecondaryMotion = 5,
            TertiaryMotion = 6,
            ModWeaponizedMotion = 7,
        }

        [FieldAttr(80)] public EMotionLayerOptions MotionOption;
    }
}
