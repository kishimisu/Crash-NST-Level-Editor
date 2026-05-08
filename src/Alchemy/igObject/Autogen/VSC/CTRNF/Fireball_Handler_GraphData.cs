namespace Alchemy
{
    [ObjectAttr(nst: 112, ctr: 104, align: 4, metaType: typeof(CVscComponentData))]
    public class Fireball_Handler_GraphData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float_0x20;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float_0x24;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect_0x28 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Spline_Event = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Vfx_Effect_0x38 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Vfx_Effect_0x40 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Sound_0x48 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Sound_0x50 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Entity = new();
    }
}
