namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVfxRuntimeObjectInfo : igObject
    {
        [FieldAttr(16)] public igMetaObject? _runtimeType;
        [FieldAttr(24)] public igVfxRuntimeObjectPool? _runtimePool;
        [FieldAttr(32)] public uint _runtimePoolSize = 32;
        [FieldAttr(36)] public igStatHandleMetaField _countStat = new();
        [FieldAttr(40)] public igStatHandleMetaField _budgetStat = new();
        [FieldAttr(44)] public bool _reporting = true;
    }
}
