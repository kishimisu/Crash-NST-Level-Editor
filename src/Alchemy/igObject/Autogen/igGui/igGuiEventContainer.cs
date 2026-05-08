namespace Alchemy
{
    [ObjectAttr(nst: 24, ctr: 24, align: 8)]
    public class igGuiEventContainer : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public igGuiEventDelegate? _received;
    }
}
