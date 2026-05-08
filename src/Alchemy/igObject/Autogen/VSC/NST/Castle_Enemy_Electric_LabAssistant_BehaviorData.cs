namespace Alchemy
{
    [ObjectAttr(nst: 160, ctr: 152, align: 4, metaType: typeof(CVscComponentData))]
    public class Castle_Enemy_Electric_LabAssistant_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _TakeHitDelay;
        [FieldAttr(nst: 44, ctr: 36)] public float _Range;
        [FieldAttr(nst: 48, ctr: 40)] public float _StartingRatio;
        [FieldAttr(nst: 52, ctr: 44)] public float _StartThreshold;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _SplineAttachBehaviorVariable_id_2bbhj85d_variable = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _SplineRotationMoverVariable_id_pbydg16p_variable = new();
        [FieldAttr(nst: 72, ctr: 64)] public string? _SpinDeath = null;
        [FieldAttr(nst: 80, ctr: 72)] public string? _TakeHit001 = null;
        [FieldAttr(nst: 88, ctr: 80)] public string? _Idle = null;
        [FieldAttr(nst: 96, ctr: 88)] public string? _Fall001 = null;
        [FieldAttr(nst: 104, ctr: 96)] public string? _Walk_0x68 = null;
        [FieldAttr(nst: 112, ctr: 104)] public float _FloatVariable;
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _SplineVelocityMover = new();
        [FieldAttr(nst: 128, ctr: 120)] public bool _Bool;
        [FieldAttr(nst: 136, ctr: 128)] public string? _Walk_0x88 = null;
        [FieldAttr(nst: 144, ctr: 136)] public float _Float_0x90;
        [FieldAttr(nst: 148, ctr: 140)] public float _Float_0x94;
        [FieldAttr(nst: 152, ctr: 144)] public float _Float_0x98;
    }
}
