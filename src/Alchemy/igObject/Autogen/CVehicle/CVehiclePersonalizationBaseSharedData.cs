namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CVehiclePersonalizationBaseSharedData : igObject
    {
        [FieldAttr(16)] public EVehiclePersonalizationType _type = EVehiclePersonalizationType.eVPT_None;
        [FieldAttr(24)] public igHandleMetaField _iconGuiMaterial = new();
        [FieldAttr(32)] public string? _guiName = null;
    }
}
