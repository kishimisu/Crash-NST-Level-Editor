namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class EFlagsWrapper : igObject
    {
        [FieldAttr(16)] public EFlags _flag = EFlags.FLAG_INVALID;
    }
}
