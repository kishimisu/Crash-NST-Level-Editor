namespace Alchemy
{
    // VSC object extracted from: Standard_Enemy_Death_c.igz

    [ObjectAttr(256, metaType: typeof(CVscComponentData))]
    public class Standard_Enemy_Death_c_Standard_Enemy_DeathData : CVscComponentData
    {
        public enum ENewEnum3_id_4cdoc9cv
        {
            noOverride = 0,
            launchInCollisionDirection = 1,
            launchTowardsCamera = 2,
            launchTowardNearestEnemy = 3,
            LaunchTowardNearestCrate = 4,
            NoLaunchDeath = 5,
        }

        [FieldAttr(40)] public bool _LaunchDeathOnly;
        [FieldAttr(48)] public igHandleMetaField _Count = new();
        [FieldAttr(56)] public igHandleMetaField _DeathBySpinHandle_0x38 = new();
        [FieldAttr(64)] public igHandleMetaField _DeathByJumpHandle = new();
        [FieldAttr(72)] public string? _DeathByJumpString = null;
        [FieldAttr(80)] public string? _DeathBySpinString = null;
        [FieldAttr(88)] public string? _DeathDefault = null;
        [FieldAttr(96)] public string? _DeathJump = null;
        [FieldAttr(104)] public string? _DeathSpin = null;
        [FieldAttr(112)] public ENewEnum3_id_4cdoc9cv _NewEnum3_id_4cdoc9cv;
        [FieldAttr(116)] public bool _Bool_0x74;
        [FieldAttr(120)] public igHandleMetaField _Havok_Linear_Cast_Query_Parameters = new();
        [FieldAttr(128)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(136)] public string? _String = null;
        [FieldAttr(144)] public igHandleMetaField _Entity = new();
        [FieldAttr(152)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(160)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(168)] public bool _Bool_0xa8;
        [FieldAttr(176)] public igHandleMetaField _Query_Filter_0xb0 = new();
        [FieldAttr(184)] public igHandleMetaField _Query_Filter_0xb8 = new();
        [FieldAttr(192)] public bool _Bool_0xc0;
        [FieldAttr(200)] public igHandleMetaField _Sound = new();
        [FieldAttr(208)] public igHandleMetaField _DeathBySpinHandle_0xd0 = new();
        [FieldAttr(216)] public float _Float;
        [FieldAttr(220)] public bool _Bool_0xdc;
        [FieldAttr(224)] public igHandleMetaField _Game_Int_Variable_0xe0 = new();
        [FieldAttr(232)] public igHandleMetaField _Game_Int_Variable_0xe8 = new();
        [FieldAttr(240)] public igHandleMetaField _Game_Int_Variable_0xf0 = new();
        [FieldAttr(248)] public igHandleMetaField _Game_Int_Variable_0xf8 = new();
    }
}
