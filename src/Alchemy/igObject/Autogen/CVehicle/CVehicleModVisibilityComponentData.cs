namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CVehicleModVisibilityComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public string? _modDiscriminator = "mod_";
    }
}
