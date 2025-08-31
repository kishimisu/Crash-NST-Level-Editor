namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVertexData : igObject
    {
        [FieldAttr(16)] public EIG_VERTEX_USAGE _usage;
        [FieldAttr(20)] public uint _usageIndex;
        [FieldAttr(24)] public int _userID;
    }
}
