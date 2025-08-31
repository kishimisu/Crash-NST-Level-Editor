namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CChangeSkin2ComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CChangeSkin2ComponentItemHashTable? _skins;
        [FieldAttr(32)] public string? _setSkinOnEnable = null;
    }
}
