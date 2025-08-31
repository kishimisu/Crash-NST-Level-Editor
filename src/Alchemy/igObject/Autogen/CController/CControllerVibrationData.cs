namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CControllerVibrationData : igObject
    {
        public enum EControllerVibrationPreset : int
        {
            eCVP_Invalid = -1,
            eCVP_Weakest = 0,
            eCVP_Weak = 1,
            eCVP_Medium = 2,
            eCVP_Strong = 3,
            eCVP_Strongest = 4,
            eCVP_WeakPain = 5,
            eCVP_MediumPain = 6,
            eCVP_StrongPain = 7,
        }

        [FieldAttr(16)] public EMotor _motor = EMotor.EMOTOR_RUMBLE;
        [FieldAttr(20)] public float _strength = 0.5f;
        [FieldAttr(24)] public float _duration = 0.5f;
    }
}
