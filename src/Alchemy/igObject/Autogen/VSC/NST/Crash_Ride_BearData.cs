namespace Alchemy
{
    [ObjectAttr(nst: 224, ctr: 216, align: 4, metaType: typeof(CVscComponentData))]
    public class Crash_Ride_BearData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _RideLCRBlendWeight_0x28 = null;
        [FieldAttr(nst: 48, ctr: 40)] public string? _RideLandEvent = null;
        [FieldAttr(nst: 56, ctr: 48)] public float _MaxDeathVelocity;
        [FieldAttr(nst: 60, ctr: 52)] public float _MinDeathVelocity;
        [FieldAttr(nst: 64, ctr: 56)] public float _AmountToAdd;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Entity_Tag_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public float _Float_0x50;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _HogRiderBolt_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Behavior_State_Group_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public float _Float_0x68;
        [FieldAttr(nst: 108, ctr: 100)] public float _Float_0x6c;
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Behavior_State_Group_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public float _ReverseMovementMultiplier;
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Entity_Tag_0x80 = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Zone_Info_0x90 = new();
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _Zone_Info_0x98 = new();
        [FieldAttr(nst: 160, ctr: 152)] public igHandleMetaField _Zone_Info_0xa0 = new();
        [FieldAttr(nst: 168, ctr: 160)] public igHandleMetaField _Zone_Info_0xa8 = new();
        [FieldAttr(nst: 176, ctr: 168)] public igHandleMetaField _Zone_Info_0xb0 = new();
        [FieldAttr(nst: 184, ctr: 176)] public igHandleMetaField _HogRiderBolt_0xb8 = new();
        [FieldAttr(nst: 192, ctr: 184)] public float _Float_0xc0;
        [FieldAttr(nst: 196, ctr: 188)] public float _Float_0xc4;
        [FieldAttr(nst: 200, ctr: 192)] public float _Float_0xc8;
        [FieldAttr(nst: 208, ctr: 200)] public string? _RideLCRBlendWeight_0xd0 = null;
        [FieldAttr(nst: 216, ctr: 208)] public igHandleMetaField _Debug_Update_Channel = new();
    }
}
