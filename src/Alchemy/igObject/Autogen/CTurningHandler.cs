namespace Alchemy
{
    [ObjectAttr(120, 8, metaType: typeof(CTurningHandler))]
    public class CTurningHandler : CBehaviorLogic
    {
        public enum ETurningInputMethod : uint
        {
            eTIM_Directional = 0,
            eTIM_Additive = 1,
        }

        [FieldAttr(80)] public ETurningInputMethod _inputMethod;
        [FieldAttr(84)] public bool _canTurnWhileStanding;
        [FieldAttr(88)] public EAnalogStick _turningStick;
        [FieldAttr(92)] public float _stickThreshhold = 0.1f;
        [FieldAttr(96)] public float _maximumTurnRate = 10800.0f;
        [FieldAttr(100)] public float _modelTurnRate = 900.0f;
        [FieldAttr(104)] public float _priority;
        [FieldAttr(108)] public bool _overrideJumpTurning;
        [FieldAttr(109)] public bool _turningAxisIsLocalSpace;
        [FieldAttr(110)] public bool _leaningEnabled = true;
        [FieldAttr(112)] public float _leanAngleRate = 2.5f;
        [FieldAttr(116)] public float _leanAngleThreshhold = 10.0f;
    }
}
