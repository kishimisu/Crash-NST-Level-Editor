namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CModsComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CMod.EModLocation _modLocation;
        [FieldAttr(32)] public CModList? _mods;
    }
}
