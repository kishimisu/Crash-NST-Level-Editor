namespace Alchemy
{
    [ObjectAttr(nst: 176, ctr: 168, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Attack_Player_OnEnter_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _IsTellLooping;
        [FieldAttr(nst: 41, ctr: 33)] public bool _UseTellDelay;
        [FieldAttr(nst: 44, ctr: 36)] public float _TellDuration;
        [FieldAttr(nst: 48, ctr: 40)] public float _AttackDelay;
        [FieldAttr(nst: 56, ctr: 48)] public string? _Tell = null;
        [FieldAttr(nst: 64, ctr: 56)] public string? _Attack_0x40 = null;
        [FieldAttr(nst: 72, ctr: 64)] public string? _Idle = null;
        [FieldAttr(nst: 80, ctr: 72)] public string? _CrashDeath = null;
        [FieldAttr(nst: 88, ctr: 80)] public bool _Bool_0x58;
        [FieldAttr(nst: 92, ctr: 84)] public float _Float_0x5c;
        [FieldAttr(nst: 96, ctr: 88)] public float _Float_0x60;
        [FieldAttr(nst: 104, ctr: 96)] public string? _Attack_0x68 = null;
        [FieldAttr(nst: 112, ctr: 104)] public float _Float_0x70;
        [FieldAttr(nst: 116, ctr: 108)] public float _Float_0x74;
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(nst: 136, ctr: 128)] public bool _Bool_0x88;
        [FieldAttr(nst: 137, ctr: 129)] public bool _Bool_0x89;
        [FieldAttr(nst: 140, ctr: 132)] public float _FloatVariable_id_jgwd7fvw_variable;
        [FieldAttr(nst: 144, ctr: 136)] public bool _Bool_0x90;
        [FieldAttr(nst: 152, ctr: 144)] public string? _String_0x98 = null;
        [FieldAttr(nst: 160, ctr: 152)] public string? _String_0xa0 = null;
        [FieldAttr(nst: 168, ctr: 160)] public string? _String_0xa8 = null;
    }
}
