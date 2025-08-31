namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class HavokConstraint : igObject
    {
        [FieldAttr(16)] public CHavokConstraintMetaField _storage = new();
    }
}
