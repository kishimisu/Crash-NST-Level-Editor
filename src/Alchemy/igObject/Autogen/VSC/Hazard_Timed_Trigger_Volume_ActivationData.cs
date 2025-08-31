namespace Alchemy
{
    // VSC object extracted from: Enemy_Electric_Lab_Activation_c.igz

    [ObjectAttr(120, metaType: typeof(CVscComponentData))]
    public class Hazard_Timed_Trigger_Volume_ActivationData : CVscComponentData
    {
        [FieldAttr(40)] public bool _StartOn;
        [FieldAttr(44)] public float _Timer_0x2c;
        [FieldAttr(48)] public igHandleMetaField _Unnamed_Vfx_Effect = new();
        [FieldAttr(56)] public float _Timer_0x38;
        [FieldAttr(64)] public igHandleMetaField _Bolt_Point_0x40 = new();
        [FieldAttr(72)] public igHandleMetaField _Bolt_Point_0x48 = new();
        [FieldAttr(80)] public igHandleMetaField _Bolt_Point_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Vfx_Effect_0x58 = new();
        [FieldAttr(96)] public igHandleMetaField _Vfx_Effect_0x60 = new();
        [FieldAttr(104)] public igHandleMetaField _Bolt_Point_0x68 = new();
        [FieldAttr(112)] public bool _Bool;
    }
}
