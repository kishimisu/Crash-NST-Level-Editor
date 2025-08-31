namespace Alchemy
{
    [ObjectAttr(976, 16)]
    public class CMobileSceneRenderPass : igForwardLitRenderPass
    {
        public enum EFilterType : uint
        {
            eFT_Default = 0,
            eFT_IncludeFading = 1,
            eFT_ExcludeFading = 2,
        }

        [FieldAttr(528)] public EFilterType _filterType;
        [FieldAttr(536)] public string? _shadowCameraName = null;
        [FieldAttr(544)] public igHandleMetaField _pointLights = new();
        [FieldAttr(552)] public int _allocatorCapacity = 8192;
        [FieldAttr(560)] public igFrustumCullerMetaField _projectiveShadowFrustum = new();
        [FieldAttr(960)] public igObject[] _pointLightDataAllocator = new igObject[2];
    }
}
