namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscMetaFunctionDelegator : igVscDelegator
    {
        [FieldAttr(24)] public igVscObjectAccessor? _target;
        [FieldAttr(32, false)] public igMetaFunction? _registerMetaFunction;
        [FieldAttr(40, false)] public igMetaFunction? _unregisterMetaFunction;
    }
}
