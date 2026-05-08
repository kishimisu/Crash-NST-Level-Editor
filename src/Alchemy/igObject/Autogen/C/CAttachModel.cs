namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 104, align: 8)]
    public class CAttachModel : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public igHandleMetaField _parent = new();
        [FieldAttr(nst: 24, ctr: 24)] public string? _modelName = null;
        [FieldAttr(nst: 32, ctr: 32)] public igVec3fMetaField _position = new();
        [FieldAttr(nst: 44, ctr: 44)] public igVec3fMetaField _rotation = new();
        [FieldAttr(nst: 56, ctr: 56)] public igVec3fMetaField _scale = new();
        [FieldAttr(nst: 72, ctr: 72)] public CModelInstance? _model;
        [FieldAttr(nst: 80, ctr: 80, refCount: false)] public CFxMaterialRedirectTable? _dynamicMaterialOverride;
        [FieldAttr(nst: 88, ctr: 88)] public CFxMaterialRedirectTable? _materialOverrides;
        [FieldAttr(nst: 96, ctr: 96)] public CBoltPoint? _bolt;
    }
}
