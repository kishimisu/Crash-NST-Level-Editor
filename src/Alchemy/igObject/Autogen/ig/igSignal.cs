namespace Alchemy
{
    [ObjectAttr(nst: 32, align: 8)]
    public class igSignal : igNamedObject
    {
        [FieldAttr(nst: 24)] public bool _autoReset;
    }
}
