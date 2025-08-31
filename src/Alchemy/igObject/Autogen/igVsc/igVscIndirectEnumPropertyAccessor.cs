namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscIndirectEnumPropertyAccessor : igVscEnumAccessor
    {
        [FieldAttr(24)] public igVscObjectAccessor? _object;
        [FieldAttr(32, false)] public igMetaFunction? _get;
        [FieldAttr(40, false)] public igMetaFunction? _set;
    }
}
