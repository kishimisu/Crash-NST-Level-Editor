namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CFilterByEntityFlags : CFilterMethod
    {
        [FieldAttr(24)] public uint _flags;
    }
}
