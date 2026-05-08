namespace Alchemy
{
    [ObjectAttr(nst: 32, ctr: 32, align: 8)]
    public class CGuiEventButtonPress : igGuiEvent
    {
        [FieldAttr(nst: 24, ctr: 24, refCount: false)] public CGuiButtonDef? _buttonDef;
    }
}
