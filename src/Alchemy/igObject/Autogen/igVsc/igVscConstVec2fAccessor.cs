namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVscConstVec2fAccessor : igVscVec2fAccessor
    {
        [FieldAttr(24)] public igVec2fMetaField _value = new();
    }
}
