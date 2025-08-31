namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CVehicleSwapData : igObject
    {
        [FieldAttr(16)] public EXBUTTON _swapButton = EXBUTTON.L1;
        [FieldAttr(20)] public float _swapCooldown = 2.5f;
        [FieldAttr(24)] public float _swapRequestDuration = 2.0f;
        [FieldAttr(32)] public igHandleMetaField _playerSwapEffect = new();
        [FieldAttr(40)] public igHandleMetaField _swapSound = new();
    }
}
