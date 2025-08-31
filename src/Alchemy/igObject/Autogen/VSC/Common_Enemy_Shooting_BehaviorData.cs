namespace Alchemy
{
    // VSC object extracted from: Factory_Enemy_Shooting_GangsterRat_Behavior.igz

    [ObjectAttr(184, metaType: typeof(CVscComponentData))]
    public class Common_Enemy_Shooting_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public bool _LookAtTarget;
        [FieldAttr(48)] public igHandleMetaField _ProjectileData = new();
        [FieldAttr(56)] public float _FireRate;
        [FieldAttr(60)] public float _AttackDuration;
        [FieldAttr(64)] public float _LookAtTime;
        [FieldAttr(68)] public float _InitialDelay;
        [FieldAttr(72)] public float _AttackRange;
        [FieldAttr(76)] public int _FiringPoints;
        [FieldAttr(80)] public string? _Attack = null;
        [FieldAttr(88)] public string? _TauntStart = null;
        [FieldAttr(96)] public string? _TauntLoop = null;
        [FieldAttr(104)] public string? _TauntEnd = null;
        [FieldAttr(112)] public igVec3fMetaField _FiringPosition2 = new();
        [FieldAttr(124)] public igVec3fMetaField _FiringPosition1 = new();
        [FieldAttr(136)] public string? _String_0x88 = null;
        [FieldAttr(144)] public string? _String_0x90 = null;
        [FieldAttr(152)] public bool _Bool;
        [FieldAttr(160)] public igHandleMetaField _Bolt_Point_0xa0 = new();
        [FieldAttr(168)] public igHandleMetaField _Bolt_Point_0xa8 = new();
        [FieldAttr(176)] public igHandleMetaField _Vfx_Effect = new();
    }
}
