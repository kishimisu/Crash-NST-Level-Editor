namespace Alchemy
{
    // VSC object extracted from: Crash_Ride_Board_c.igz

    [ObjectAttr(200, metaType: typeof(CVscComponentData))]
    public class Crash_Ride_BoardData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _BoardRiderBolt = new();
        [FieldAttr(48)] public float _BoostVelocity;
        [FieldAttr(52)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(64)] public string? _RideBoardDismountCustomEvent = null;
        [FieldAttr(72)] public igHandleMetaField _Behavior_State_Group_0x48 = new();
        [FieldAttr(80)] public float _Float_0x50;
        [FieldAttr(84)] public float _Float_0x54;
        [FieldAttr(88)] public float _Float_0x58;
        [FieldAttr(92)] public float _Float_0x5c;
        [FieldAttr(96)] public float _Float_0x60;
        [FieldAttr(100)] public float _Float_0x64;
        [FieldAttr(104)] public float _Float_0x68;
        [FieldAttr(108)] public float _Float_0x6c;
        [FieldAttr(112)] public igHandleMetaField _Game_Bool_Variable_0x70 = new();
        [FieldAttr(120)] public igHandleMetaField _Game_Bool_Variable_0x78 = new();
        [FieldAttr(128)] public igHandleMetaField _Behavior_State_Group_0x80 = new();
        [FieldAttr(136)] public float _Float_0x88;
        [FieldAttr(140)] public float _Float_0x8c;
        [FieldAttr(144)] public float _Float_0x90;
        [FieldAttr(148)] public float _Float_0x94;
        [FieldAttr(152)] public float _Float_0x98;
        [FieldAttr(156)] public float _Float_0x9c;
        [FieldAttr(160)] public igHandleMetaField _Debug_Update_Channel = new();
        [FieldAttr(168)] public float _UMDAddPerFrameValue;
        [FieldAttr(176)] public igHandleMetaField _Vfx_Effect_0xb0 = new();
        [FieldAttr(184)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(192)] public igHandleMetaField _Vfx_Effect_0xc0 = new();
    }
}
