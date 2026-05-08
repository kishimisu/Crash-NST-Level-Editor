namespace Alchemy
{
    [ObjectAttr(nst: 160, ctr: 152, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Offset_Attack_OnEnter_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _UseTellDelay;
        [FieldAttr(nst: 41, ctr: 33)] public bool _ResetOnExit;
        [FieldAttr(nst: 42, ctr: 34)] public bool _IsTellLooping;
        [FieldAttr(nst: 43, ctr: 35)] public bool _ResetAfterAttack;
        [FieldAttr(nst: 44, ctr: 36)] public float _TellDuration;
        [FieldAttr(nst: 48, ctr: 40)] public float _ResetDuration;
        [FieldAttr(nst: 52, ctr: 44)] public float _MoveToOriginDuration;
        [FieldAttr(nst: 56, ctr: 48)] public float _ExitResetDelay;
        [FieldAttr(nst: 60, ctr: 52)] public float _RotateDelay;
        [FieldAttr(nst: 64, ctr: 56)] public float _AttackResetDelay;
        [FieldAttr(nst: 72, ctr: 64)] public string? _Tell = null;
        [FieldAttr(nst: 80, ctr: 72)] public string? _Attack_0x50 = null;
        [FieldAttr(nst: 88, ctr: 80)] public string? _Idle = null;
        [FieldAttr(nst: 96, ctr: 88)] public string? _Ascending = null;
        [FieldAttr(nst: 104, ctr: 96)] public igVec3fMetaField _Offset_Vector3 = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Tell_Vfx_Effect = new();
        [FieldAttr(nst: 128, ctr: 120)] public bool _Bool_0x80;
        [FieldAttr(nst: 136, ctr: 128)] public string? _Attack_0x88 = null;
        [FieldAttr(nst: 144, ctr: 136)] public bool _Bool_0x90;
        [FieldAttr(nst: 148, ctr: 140)] public float _Float_0x94;
        [FieldAttr(nst: 152, ctr: 144)] public float _Float_0x98;
        [FieldAttr(nst: 156, ctr: 148)] public bool _Bool_0x9c;
    }
}
