namespace Alchemy
{
    [ObjectAttr(nst: 32, ctr: 48, align: 8)]
    public class CSurfaceVfxComponentData : CEntityComponentData
    {
        [FieldAttr(nst: 24, ctr: 16)] public SurfaceVfxSpecList? _surfaceVfxs;
        [FieldAttr(ctr: 24)] public SurfaceVfxSpecList? _landingVfxs;
        [FieldAttr(ctr: 32)] public CSurfaceMaterialAccumulationOverrideList? _surfaceAccumulationOverrides;
        [FieldAttr(ctr: 40)] public bool _canDriveIntoWater;
    }
}
