namespace Alchemy
{
    [ObjectAttr(nst: 192, ctr: 184, align: 4, metaType: typeof(CVscComponentData))]
    public class Crash_Ride_TigerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _ReverseMovementMultiplier;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float_0x2c;
        [FieldAttr(nst: 48, ctr: 40)] public string? _RideLCRBlendWeight = null;
        [FieldAttr(nst: 56, ctr: 48)] public string? _RideLandEvent = null;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Zone_Info_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _AmountToAdd;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Behavior_State_Group_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Zone_Info_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _HogRiderBolt = new();
        [FieldAttr(nst: 104, ctr: 96)] public float _Float_0x68;
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Behavior_State_Group_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public float _Float_0x78;
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Zone_Info_0x80 = new();
        [FieldAttr(nst: 136, ctr: 128)] public float _Float_0x88;
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(nst: 152, ctr: 144)] public float _Float_0x98;
        [FieldAttr(nst: 156, ctr: 148)] public float _Float_0x9c;
        [FieldAttr(nst: 160, ctr: 152)] public float _MaxDeathVelocity;
        [FieldAttr(nst: 164, ctr: 156)] public float _Float_0xa4;
        [FieldAttr(nst: 168, ctr: 160)] public float _Float_0xa8;
        [FieldAttr(nst: 172, ctr: 164)] public float _Float_0xac;
        [FieldAttr(nst: 176, ctr: 168)] public float _Float_0xb0;
        [FieldAttr(nst: 180, ctr: 172)] public float _Float_0xb4;
        [FieldAttr(nst: 184, ctr: 176)] public igHandleMetaField _Shape = new();
    }
}
