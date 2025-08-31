namespace Alchemy
{
    // VSC object extracted from: Enemy_Attack_Player_Timed_Behavior_c.igz

    [ObjectAttr(120, metaType: typeof(CVscComponentData))]
    public class Enemy_Attack_Player_Timed_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public bool _IsTellLooping;
        [FieldAttr(41)] public bool _UseTellDelay;
        [FieldAttr(44)] public float _TellDuration;
        [FieldAttr(48)] public float _DefaultDelay;
        [FieldAttr(52)] public float _InitialDelay;
        [FieldAttr(56)] public float _AttackDelay;
        [FieldAttr(64)] public string? _Tell = null;
        [FieldAttr(72)] public string? _Attack = null;
        [FieldAttr(80)] public string? _Idle = null;
        [FieldAttr(88)] public string? _CrashDeath = null;
        [FieldAttr(96)] public float _Float_0x60;
        [FieldAttr(100)] public float _Float_0x64;
        [FieldAttr(104)] public bool _Bool;
        [FieldAttr(108)] public float _Float_0x6c;
        [FieldAttr(112)] public float _Float_0x70;
        [FieldAttr(116)] public float _Float_0x74;
    }
}
