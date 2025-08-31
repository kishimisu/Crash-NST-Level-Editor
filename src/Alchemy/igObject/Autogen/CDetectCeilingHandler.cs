namespace Alchemy
{
    [ObjectAttr(104, 8, metaType: typeof(CDetectCeilingHandler))]
    public class CDetectCeilingHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public float _traceDistanceAccurate = 171.0f;
        [FieldAttr(84)] public float _traceDistanceLoose = 110.0f;
        [FieldAttr(88)] public float _sphereRadius = 25.0f;
        [FieldAttr(96)] public CCollisionMaterialHandleList? _excludeCollisionMaterialList;
    }
}
