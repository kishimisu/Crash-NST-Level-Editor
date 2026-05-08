namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_HavokBased_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _Bool_0x28;
        [FieldAttr(nst: 41, ctr: 33)] public bool _BouncePlayerUp;
        [FieldAttr(nst: 48, ctr: 40)] public string? _String = null;
        [FieldAttr(nst: 56, ctr: 48)] public string? _CrashDeath = null;
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool_0x40;
        [FieldAttr(nst: 68, ctr: 60)] public float _AttackDelay;
        [FieldAttr(nst: 72, ctr: 64)] public float _Float;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Game_Float_Variable = new();
    }
}
