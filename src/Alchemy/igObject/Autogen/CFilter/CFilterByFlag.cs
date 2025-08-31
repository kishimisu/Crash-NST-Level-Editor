namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CFilterByFlag : CFilterMethod
    {
        [FieldAttr(24)] public EFlags _flag = EFlags.FLAG_INVALID;
    }
}
