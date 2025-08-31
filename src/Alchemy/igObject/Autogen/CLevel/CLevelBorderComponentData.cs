namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CLevelBorderComponentData : CEntityComponentData
    {
        public enum EBorderType : uint
        {
            eBT_Collision = 0,
            eBT_Trigger = 1,
        }

        [FieldAttr(24)] public CLevelBorder? _border;
        [FieldAttr(32)] public string? _borderPath = null;
        [FieldAttr(40)] public uint _stopFlags = 383;
        [FieldAttr(44)] public bool _airVehicleShouldTurnAround = true;
        [FieldAttr(48)] public igHandleMetaField _levelBorderVfxToSpawn = new();
        [FieldAttr(56)] public EBorderType _borderType;
    }
}
