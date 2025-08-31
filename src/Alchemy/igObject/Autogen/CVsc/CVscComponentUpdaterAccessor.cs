namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CVscComponentUpdaterAccessor : igVscObjectAccessor
    {
        [FieldAttr(24)] public igVscObjectAccessor? _accessor;
    }
}
