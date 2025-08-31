namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CFxMaterialRedirectTable : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _default = new();
        [FieldAttr(24)] public igFxMaterialHandleList? _keys;
        [FieldAttr(32)] public igFxMaterialHandleList? _values;
        [FieldAttr(40)] public int _priority;
    }
}
