namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_Timed_Trigger_Volume_ActivationData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _StartOn;
        [FieldAttr(nst: 44, ctr: 36)] public float _Timer_0x2c;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Unnamed_Vfx_Effect = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Timer_0x38;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Bolt_Point_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Bolt_Point_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Bolt_Point_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Vfx_Effect_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Vfx_Effect_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Bolt_Point_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public bool _Bool;
    }
}
