namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 32, align: 16)]
    public class igVscConstVec4fAccessor : igVscVec4fAccessor
    {
        [FieldAttr(nst: 32, ctr: 16)] public igVec4fMetaField _value = new();
    }
}
