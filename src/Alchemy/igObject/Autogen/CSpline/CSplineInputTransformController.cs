namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CSplineInputTransformController : CBaseInputTransformController
    {
        [FieldAttr(16, false)] public CEntity? _splineEntity;
        [FieldAttr(24)] public bool _reversed;
    }
}
