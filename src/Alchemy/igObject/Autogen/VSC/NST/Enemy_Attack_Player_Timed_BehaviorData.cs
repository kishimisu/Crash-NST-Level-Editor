namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Attack_Player_Timed_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _IsTellLooping;
        [FieldAttr(nst: 41, ctr: 33)] public bool _UseTellDelay;
        [FieldAttr(nst: 44, ctr: 36)] public float _TellDuration;
        [FieldAttr(nst: 48, ctr: 40)] public float _DefaultDelay;
        [FieldAttr(nst: 52, ctr: 44)] public float _InitialDelay;
        [FieldAttr(nst: 56, ctr: 48)] public float _AttackDelay;
        [FieldAttr(nst: 64, ctr: 56)] public string? _Tell = null;
        [FieldAttr(nst: 72, ctr: 64)] public string? _Attack = null;
        [FieldAttr(nst: 80, ctr: 72)] public string? _Idle = null;
        [FieldAttr(nst: 88, ctr: 80)] public string? _CrashDeath = null;
        [FieldAttr(nst: 96, ctr: 88)] public float _Float_0x60;
        [FieldAttr(nst: 100, ctr: 92)] public float _Float_0x64;
        [FieldAttr(nst: 104, ctr: 96)] public bool _Bool;
        [FieldAttr(nst: 108, ctr: 100)] public float _Float_0x6c;
        [FieldAttr(nst: 112, ctr: 104)] public float _Float_0x70;
        [FieldAttr(nst: 116, ctr: 108)] public float _Float_0x74;
    }
}
