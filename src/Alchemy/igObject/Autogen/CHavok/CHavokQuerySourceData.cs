namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CHavokQuerySourceData : CSourceData
    {
        [FieldAttr(16)] public float _raycastOffsetAbove = 1000.0f;
        [FieldAttr(20)] public float _raycastOffsetBelow = 1000.0f;
        [FieldAttr(24)] public igHandleMetaField _targetWaterSurfaceMaterial = new();
    }
}
