namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CLatchableComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CBoltPointList? _latchPoints;
    }
}
