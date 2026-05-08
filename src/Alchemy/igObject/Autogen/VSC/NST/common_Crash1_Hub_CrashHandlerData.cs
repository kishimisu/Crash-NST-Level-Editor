namespace Alchemy
{
    [ObjectAttr(nst: 192, ctr: 184, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Crash1_Hub_CrashHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _SplineMover = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _SplineMoveToRatioSpeed;
        [FieldAttr(nst: 56, ctr: 48)] public string? _AnimationIdle = null;
        [FieldAttr(nst: 64, ctr: 56)] public string? _AnimationRun = null;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 88, ctr: 80)] public string? _String = null;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Vfx_Effect_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Vfx_Effect_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Vfx_Effect_0x78 = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Vfx_Effect_0x80 = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Vfx_Effect_0x88 = new();
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Vfx_Effect_0x90 = new();
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _Vfx_Effect_0x98 = new();
        [FieldAttr(nst: 160, ctr: 152)] public igHandleMetaField _Vfx_Effect_0xa0 = new();
        [FieldAttr(nst: 168, ctr: 160)] public igHandleMetaField _Game_Bool_Variable_0xa8 = new();
        [FieldAttr(nst: 176, ctr: 168)] public igHandleMetaField _Game_Bool_Variable_0xb0 = new();
        [FieldAttr(nst: 184, ctr: 176)] public igHandleMetaField _Game_Bool_Variable_0xb8 = new();
    }
}
