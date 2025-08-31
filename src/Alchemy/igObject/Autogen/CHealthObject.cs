namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CHealthObject : igObject
    {
        [FieldAttr(16, false)] public CPhysicalEntity? _entity;
        [FieldAttr(24)] public int _healthDelta;
    }
}
