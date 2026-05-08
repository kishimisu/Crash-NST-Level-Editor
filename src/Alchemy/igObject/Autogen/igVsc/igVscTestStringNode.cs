namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 40, align: 8)]
    public class igVscTestStringNode : igVscActionNode
    {
        [FieldAttr(nst: 16)] public igVscStringAccessor? _string;
        [FieldAttr(nst: 24, refCount: false)] public igVscActionNode? _boolNonEmpty;
        [FieldAttr(nst: 32, refCount: false)] public igVscActionNode? _boolNullOrEmpty;
        [FieldAttr(ctr: 16)] public igVscStringAccessor? _inputString;
        [FieldAttr(ctr: 24, refCount: false)] public igVscActionNode? _boolNotEmpty;
        [FieldAttr(ctr: 32, refCount: false)] public igVscActionNode? _boolEmpty;
    }
}
