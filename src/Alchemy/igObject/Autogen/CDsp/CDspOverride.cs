namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CDspOverride : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _dsp = new();
        [FieldAttr(24)] public bool _dirty;
    }
}
