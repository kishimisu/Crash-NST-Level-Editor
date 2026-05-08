namespace Alchemy
{
    [ObjectAttr(nst: 184, ctr: 176, align: 4, metaType: typeof(CVscComponentData))]
    public class Common_Enemy_Shooting_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _LookAtTarget;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _ProjectileData = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _FireRate;
        [FieldAttr(nst: 60, ctr: 52)] public float _AttackDuration;
        [FieldAttr(nst: 64, ctr: 56)] public float _LookAtTime;
        [FieldAttr(nst: 68, ctr: 60)] public float _InitialDelay;
        [FieldAttr(nst: 72, ctr: 64)] public float _AttackRange;
        [FieldAttr(nst: 76, ctr: 68)] public int _FiringPoints;
        [FieldAttr(nst: 80, ctr: 72)] public string? _Attack = null;
        [FieldAttr(nst: 88, ctr: 80)] public string? _TauntStart = null;
        [FieldAttr(nst: 96, ctr: 88)] public string? _TauntLoop = null;
        [FieldAttr(nst: 104, ctr: 96)] public string? _TauntEnd = null;
        [FieldAttr(nst: 112, ctr: 104)] public igVec3fMetaField _FiringPosition2 = new();
        [FieldAttr(nst: 124, ctr: 116)] public igVec3fMetaField _FiringPosition1 = new();
        [FieldAttr(nst: 136, ctr: 128)] public string? _String_0x88 = null;
        [FieldAttr(nst: 144, ctr: 136)] public string? _String_0x90 = null;
        [FieldAttr(nst: 152, ctr: 144)] public bool _Bool;
        [FieldAttr(nst: 160, ctr: 152)] public igHandleMetaField _Bolt_Point_0xa0 = new();
        [FieldAttr(nst: 168, ctr: 160)] public igHandleMetaField _Bolt_Point_0xa8 = new();
        [FieldAttr(nst: 176, ctr: 168)] public igHandleMetaField _Vfx_Effect = new();
    }
}
