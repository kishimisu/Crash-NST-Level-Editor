namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 40, align: 8)]
    public class CSurfaceLinearMotion : CSurfaceMotion
    {
        [FieldAttr(nst: 24, ctr: 24)] public igVec3fMetaField _velocity = new();
    }
}
