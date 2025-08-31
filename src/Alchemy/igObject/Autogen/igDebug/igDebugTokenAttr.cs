namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igDebugTokenAttr : igAttr
    {
        [FieldAttr(24)] public int _tag = -1;
        [FieldAttr(28)] public bool _breakOnToken;
    }
}
