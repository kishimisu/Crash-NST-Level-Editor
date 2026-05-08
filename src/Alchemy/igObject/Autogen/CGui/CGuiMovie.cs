namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 80, align: 16)]
    public class CGuiMovie : igGuiSprite
    {
        [FieldAttr(nst: 64, ctr: 64)] public string? _url = null;
        [FieldAttr(nst: 72, ctr: 72)] public CGuiMovieSpriteDrawCallModifier? _drawCallModifier;
    }
}
