namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 72, align: 8)]
    public class igDebugPrimitive : igObject
    {
        [FieldAttr(nst: 16, ctr: 12)] public int _framesRemaining;
        [FieldAttr(nst: 20, ctr: 16)] public EIG_GFX_DRAW _primType = EIG_GFX_DRAW.TRIANGLES;
        [FieldAttr(nst: 24, ctr: 24)] public igVectorMetaField<igVec3fMetaField> _positions = new();
        [FieldAttr(nst: 48, ctr: 48)] public igVectorMetaField<uint> _colors = new();
    }
}
