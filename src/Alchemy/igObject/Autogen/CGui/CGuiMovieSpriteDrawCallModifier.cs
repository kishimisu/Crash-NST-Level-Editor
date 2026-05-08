namespace Alchemy
{
    [ObjectAttr(nst: 24, ctr: 24, align: 8)]
    public class CGuiMovieSpriteDrawCallModifier : igSpriteDrawCallModifier
    {
        [FieldAttr(nst: 16, ctr: 16, refCount: false)] public CStreamingMovie? _movie;
    }
}
