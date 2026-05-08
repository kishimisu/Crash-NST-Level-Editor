namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 40, align: 8)]
    public class CLevelChunkInfo : CChunkInfo
    {
        [FieldAttr(nst: 32, ctr: 32)] public string? _levelName = null;
    }
}
