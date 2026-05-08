namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class common_BossAttackDamageHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _AkuAkuMaskCount = new();
        [FieldAttr(nst: 48, ctr: 40)] public string? _CrashDeathDefaultBehaviorEvent = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _CrashDeathCustomAttackIdentifierList_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _CrashDeathCustomBehaviorEventList = new();
        [FieldAttr(nst: 72, ctr: 64)] public bool _Bool_0x48;
        [FieldAttr(nst: 76, ctr: 68)] public float _Float;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _CrashDeathCustomAttackIdentifierList_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public bool _Bool_0x58;
    }
}
