namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 64, align: 8)]
    public class CTintSphereComponent : igComponent
    {
        [FieldAttr(nst: 40, ctr: 40)] public CRigidModelInstance? _model;
        [FieldAttr(nst: 48, ctr: 48, refCount: false)] public CTintSphereBundle? _tintSphereConstant;
        [FieldAttr(nst: 56, ctr: 56)] public bool _occlusionBoxHidden;
        [FieldAttr(nst: 57, ctr: 57)] public bool _lightState = true;
        [FieldAttr(nst: 58, ctr: 58)] public bool _isComponentEnabled;
        [FieldAttr(ctr: 59)] public bool _registered;
    }
}
