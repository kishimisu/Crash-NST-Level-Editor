namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVscConstColorAccessor : igVscColorAccessor
    {
        [FieldAttr(24)] public igVec4ucMetaField _value = new();
    }
}
