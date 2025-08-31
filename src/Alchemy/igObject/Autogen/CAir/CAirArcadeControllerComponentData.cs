namespace Alchemy
{
    [ObjectAttr(64, 4)]
    public class CAirArcadeControllerComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public EXBUTTON _barrelRollButton = EXBUTTON.JUMP;
        [FieldAttr(28)] public EXBUTTON _barrelRollButtonSecondary = EXBUTTON.L2;
        [FieldAttr(32)] public float _barrelRollPushForce = 1.5f;
        [FieldAttr(36)] public float _barrelRollTime = 0.5f;
        [FieldAttr(40)] public float _barrelRollCooldownTime = 0.75f;
        [FieldAttr(44)] public float _vehicleScreenMovementSpeed = 1.5f;
        [FieldAttr(48)] public float _screenLeftLimit = -0.89999998f;
        [FieldAttr(52)] public float _screenRightLimit = 0.89999998f;
        [FieldAttr(56)] public float _screenTopLimit = 0.89999998f;
        [FieldAttr(60)] public float _screenBottomLimit = -0.89999998f;
    }
}
