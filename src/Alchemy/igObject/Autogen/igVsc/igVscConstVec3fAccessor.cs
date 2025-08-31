namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igVscConstVec3fAccessor : igVscVec3fAccessor
    {
        [FieldAttr(24)] public igVec3fMetaField _value = new();
    }
}
