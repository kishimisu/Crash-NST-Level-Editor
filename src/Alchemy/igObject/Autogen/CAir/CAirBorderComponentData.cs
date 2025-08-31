namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CAirBorderComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public bool _turnAround;
        [FieldAttr(32)] public igHandleMetaField _vfxToSpawn = new();
    }
}
