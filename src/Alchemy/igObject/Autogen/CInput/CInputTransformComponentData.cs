namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CInputTransformComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CBaseInputTransformControllerList? _controllerList;
    }
}
