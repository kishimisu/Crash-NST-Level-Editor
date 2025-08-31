namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CVehicleHornComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public string? _hornSoundStart = null;
        [FieldAttr(32)] public string? _hornSoundLoop = null;
        [FieldAttr(40)] public string? _hornSoundEnd = null;
        [FieldAttr(48)] public EXBUTTON _hornButton = EXBUTTON.L3;
        [FieldAttr(52)] public bool _isHornOverride;
    }
}
