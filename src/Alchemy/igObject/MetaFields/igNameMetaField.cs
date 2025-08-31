namespace Alchemy
{
    [ObjectAttr(16)]
    public class igNameMetaField : igCompoundMetaField
    {
        [FieldAttr(0)] public string? _name;
        [FieldAttr(8)] public u64 _nameHash;

        public igNameMetaField() { }
        public igNameMetaField(string name) => _name = name;

        public string? GetName() => _name;
        public void SetName(string name) => _name = name;

        public override void Write(IgzWriter writer)
        {
            _nameHash = _name == null ? 0 : NamespaceUtils.ComputeHash(_name);

            base.Write(writer);
        }
    }
}
