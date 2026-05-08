namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 8)]
    public class igProcGeometryDrawCallDataPool : igPool
    {
        [FieldAttr(nst: 80, ctr: 80)] public u64 _resetCallback = new();
    }
}
