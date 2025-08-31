namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscEntryPointNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscAccessorList? _accessors;
        [FieldAttr(24)] public igVscAccessorList? _filters;
        [FieldAttr(32)] public igVscIntAccessor? _timesFired;
        [FieldAttr(40)] public igVscIntAccessor? _timesToFire;
        [FieldAttr(48, false)] public igVscActionNode? _node;
    }
}
