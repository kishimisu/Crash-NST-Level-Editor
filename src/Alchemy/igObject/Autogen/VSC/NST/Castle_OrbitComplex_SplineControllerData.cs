namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class Castle_OrbitComplex_SplineControllerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _StartingRatio;
        [FieldAttr(nst: 44, ctr: 36)] public bool _Bool_0x2c;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Spline_Velocity_Mover = new();
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool_0x40;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Sound_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Vfx_Effect_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Sound_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Vfx_Effect_0x60 = new();
    }
}
