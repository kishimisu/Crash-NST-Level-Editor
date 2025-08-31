namespace Alchemy
{
    [ObjectAttr(56, 4)]
    public class CFilterByVision : CFilterMethod
    {
        public enum EFacing : uint
        {
            eF_EntityDirection = 0,
            eF_LastPressedStickDirection = 1,
        }

        [FieldAttr(24)] public float _maxLeftRightDistance = 300.0f;
        [FieldAttr(28)] public float _forwardCutoff = 300.0f;
        [FieldAttr(32)] public float _maxForwardDistance = 1000.0f;
        [FieldAttr(36)] public float _maxVerticalDistance = 300.0f;
        [FieldAttr(40)] public float _lowerVerticalOffset;
        [FieldAttr(44)] public float _upperVerticalOffset;
        [FieldAttr(48)] public bool _circularSweep;
        [FieldAttr(49)] public bool _useYawOnly;
        [FieldAttr(52)] public EFacing _facing;
    }
}
