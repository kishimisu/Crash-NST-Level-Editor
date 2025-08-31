namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CFilterByAngleRange : CFilterMethod
    {
        public enum EDirection : uint
        {
            ED_Forwards = 0,
            ED_Backwards = 1,
            ED_Leftwards = 2,
            ED_Rightwards = 3,
            ED_LastPressedStickDirection = 4,
        }

        [FieldAttr(24)] public EDirection _referenceDirection;
        [FieldAttr(28)] public float _minAngle;
        [FieldAttr(32)] public float _maxAngle;
    }
}
