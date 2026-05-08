namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 40, align: 8)]
    public class CRailCameraPeachesCallback : igPeachesBaseCallback
    {
        [FieldAttr(nst: 16, ctr: 16, refCount: false)] public CRailCamera? _object;
        [FieldAttr(nst: 24, ctr: 24)] public uint _function;
    }
}
