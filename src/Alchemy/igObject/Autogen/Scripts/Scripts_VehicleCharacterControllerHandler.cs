namespace Alchemy
{
    [ObjectAttr(88, 8, metaType: typeof(CBehaviorLogic))]
    public class Scripts_VehicleCharacterControllerHandler : CBehaviorLogic
    {
        public enum EControllerMotionTypeEnum : uint
        {
            AnimationDriven = 0,
            Dynamic = 1,
        }

        [FieldAttr(80)] public EControllerMotionTypeEnum MotionTypeEnum;
        [FieldAttr(84)] public bool ForceDownwardMomentum = true;
        [FieldAttr(85)] public bool ApplyGravity = true;
        [FieldAttr(86)] public bool SetInitalVelocity;
    }
}
