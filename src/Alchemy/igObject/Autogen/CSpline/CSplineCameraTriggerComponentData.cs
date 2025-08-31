namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CSplineCameraTriggerComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CSplineCameraData? _blendTargetData;
        [FieldAttr(32)] public igHandleMetaField _splineTarget = new();
        [FieldAttr(40)] public igHandleMetaField _splineSource = new();
    }
}
