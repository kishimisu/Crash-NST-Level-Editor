namespace Alchemy
{
    [ObjectAttr(208, 4)]
    public class CVfxDrawForceFeedbackOperator : igVfxDrawOperator
    {
        [FieldAttr(32)] public igVfxRangedCurveMetaField _rumbleMagnitude = new();
        [FieldAttr(116)] public igVfxRangedCurveMetaField _vibrationMagnitude = new();
        [FieldAttr(200)] public EOperatorCurveInput _rumbleInput;
        [FieldAttr(204)] public bool _playerOne;
        [FieldAttr(205)] public bool _playerTwo;
        [FieldAttr(206)] public bool _currentPlayer = true;
    }
}
