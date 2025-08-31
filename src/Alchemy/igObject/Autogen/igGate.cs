namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class igGate : igObject
    {
        [FieldAttr(16)] public int _count;
        [FieldAttr(20)] public bool _open = true;
    }
}
