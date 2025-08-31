namespace Alchemy
{
    // VSC object extracted from: Enemy_Offset_Attack_OnEnter_Behavior_c.igz

    [ObjectAttr(160, metaType: typeof(CVscComponentData))]
    public class Enemy_Offset_Attack_OnEnter_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public bool _UseTellDelay;
        [FieldAttr(41)] public bool _ResetOnExit;
        [FieldAttr(42)] public bool _IsTellLooping;
        [FieldAttr(43)] public bool _ResetAfterAttack;
        [FieldAttr(44)] public float _TellDuration;
        [FieldAttr(48)] public float _ResetDuration;
        [FieldAttr(52)] public float _MoveToOriginDuration;
        [FieldAttr(56)] public float _ExitResetDelay;
        [FieldAttr(60)] public float _RotateDelay;
        [FieldAttr(64)] public float _AttackResetDelay;
        [FieldAttr(72)] public string? _Tell = null;
        [FieldAttr(80)] public string? _Attack_0x50 = null;
        [FieldAttr(88)] public string? _Idle = null;
        [FieldAttr(96)] public string? _Ascending = null;
        [FieldAttr(104)] public igVec3fMetaField _Offset_Vector3 = new();
        [FieldAttr(120)] public igHandleMetaField _Tell_Vfx_Effect = new();
        [FieldAttr(128)] public bool _Bool_0x80;
        [FieldAttr(136)] public string? _Attack_0x88 = null;
        [FieldAttr(144)] public bool _Bool_0x90;
        [FieldAttr(148)] public float _Float_0x94;
        [FieldAttr(152)] public float _Float_0x98;
        [FieldAttr(156)] public bool _Bool_0x9c;
    }
}
