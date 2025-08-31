namespace Alchemy
{
    // VSC object extracted from: Hazard_HavokBased_Behavior.igz

    [ObjectAttr(96, metaType: typeof(CVscComponentData))]
    public class Hazard_HavokBased_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public bool _Bool_0x28;
        [FieldAttr(41)] public bool _BouncePlayerUp;
        [FieldAttr(48)] public string? _String = null;
        [FieldAttr(56)] public string? _CrashDeath = null;
        [FieldAttr(64)] public bool _Bool_0x40;
        [FieldAttr(68)] public float _AttackDelay;
        [FieldAttr(72)] public float _Float;
        [FieldAttr(80)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
        [FieldAttr(88)] public igHandleMetaField _Game_Float_Variable = new();
    }
}
