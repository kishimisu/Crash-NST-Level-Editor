namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 88, align: 8)]
    public class SurfaceVfxSpec : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public igHandleMetaField _materialHandle = new();
        [FieldAttr(nst: 24, ctr: 24)] public igVfxEffect? _surfaceVfx;
        [FieldAttr(ctr: 32)] public igVfxEffect? _nonLocalSurfaceVfx;
        [FieldAttr(ctr: 40)] public bool _shouldTriggerSurfaceSound;
        [FieldAttr(nst: 32, ctr: 48)] public igHandleMetaField _surfaceSfx = new();
        [FieldAttr(ctr: 56)] public igHandleMetaField _nonLocalSurfaceSfx = new();
        [FieldAttr(ctr: 64)] public igHandleMetaField _oneShotSurfaceSfx = new();
        [FieldAttr(ctr: 72)] public igHandleMetaField _nonLocalOneShotSurfaceSfx = new();
        [FieldAttr(nst: 40, ctr: 80)] public CSoundUpdateMethodList? _sfxUpdateMethodList;
    }
}
