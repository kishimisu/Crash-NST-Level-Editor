namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CBoltPointContainerComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CBoltPointList? _boltPoints;
    }
}
