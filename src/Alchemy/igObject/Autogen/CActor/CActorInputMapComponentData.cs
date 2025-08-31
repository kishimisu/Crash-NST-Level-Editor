namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CActorInputMapComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CActorInputMap? _defaultActorInputMap;
    }
}
