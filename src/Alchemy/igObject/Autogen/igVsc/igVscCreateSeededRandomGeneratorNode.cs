namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 40, align: 8)]
    public class igVscCreateSeededRandomGeneratorNode : igVscActionNode
    {
        [FieldAttr(nst: 16, ctr: 16, refCount: false)] public igVscIntAccessor? _seed;
        [FieldAttr(nst: 24, ctr: 24, refCount: false)] public igVscObjectAccessor? _randomGenerator;
        [FieldAttr(nst: 32, ctr: 32, refCount: false)] public igVscActionNode? _out;
    }
}
