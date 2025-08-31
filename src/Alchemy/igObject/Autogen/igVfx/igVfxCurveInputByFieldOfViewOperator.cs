namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igVfxCurveInputByFieldOfViewOperator : igVfxFrameOperator
    {
        public enum EFieldOfViewInput : uint
        {
            kHorizontalFOV = 0,
            kHorizontalTanFOV = 1,
            kVerticalFOV = 2,
            kVerticalTanFOV = 3,
        }

        [FieldAttr(32)] public EFieldOfViewInput _fovInput;
        [FieldAttr(36)] public EOperatorCurveOutput _outputParameter = EOperatorCurveOutput.kSetTrackParameter1;
    }
}
