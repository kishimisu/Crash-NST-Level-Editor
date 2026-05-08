namespace Alchemy
{
    [ObjectAttr(nst: 144, ctr: 136, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class common_Meter_Bar_Root : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public igVec4ucMetaField _FillColor = new();
        [FieldAttr(nst: 52, ctr: 44)] public igVec4ucMetaField _SentColor = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _CurrentFillAmt;
        [FieldAttr(nst: 60, ctr: 52)] public float _AnimDelta;
        [FieldAttr(nst: 64, ctr: 56)] public float _AnimIncrement;
        [FieldAttr(nst: 68, ctr: 60)] public float _Initial_Fill_Amount;
        [FieldAttr(nst: 72, ctr: 64)] public float _FloatVariable_id_vwrx11vt_variable;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Bar_Fill_Anim = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _GuiPlaceableVariable_id_j0cwne6i_variable = new();
        [FieldAttr(nst: 96, ctr: 88)] public igObject? _Internal_TimerAction_id_rumrs5d5_timer = new();
        [FieldAttr(nst: 104, ctr: 96)] public igObject? _Internal_TimerAction_id_sdvyvkos_timer = new();
        [FieldAttr(nst: 112, ctr: 104)] public float _SentEndAmt;
        [FieldAttr(nst: 116, ctr: 108)] public float _SentDuration;
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Vfx_Spawned_Effect = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Sound_Instance = new();
    }
}
