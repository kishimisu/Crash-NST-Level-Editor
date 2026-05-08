namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 40, align: 8)]
    public class igVscIndirectColorPropertyAccessor : igVscColorAccessor
    {
        [FieldAttr(nst: 24, ctr: 16)] public igVscObjectAccessor? _object;
        [FieldAttr(nst: 32, ctr: 24, refCount: false)] public igMetaFunction? _get;
        [FieldAttr(nst: 40, ctr: 32, refCount: false)] public igMetaFunction? _set;
    }
}
