namespace Alchemy
{
    // VSC object extracted from: Enemy_Shield_Push_Behavior_c.igz

    [ObjectAttr(232, metaType: typeof(CVscComponentData))]
    public class Enemy_Shield_Push_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public float _FlippedTimer;
        [FieldAttr(44)] public float _LaunchHeight;
        [FieldAttr(48)] public float _LaunchSpeed;
        [FieldAttr(52)] public float _PushOffset;
        [FieldAttr(56)] public string? _ShieldDown = null;
        [FieldAttr(64)] public string? _WalkBack = null;
        [FieldAttr(72)] public string? _TurnBack = null;
        [FieldAttr(80)] public string? _WalkForward = null;
        [FieldAttr(88)] public string? _TurnForward = null;
        [FieldAttr(96)] public string? _ShieldUpBounce_0x60 = null;
        [FieldAttr(104)] public string? _ShieldUp = null;
        [FieldAttr(112)] public string? _ShieldUpBounce_0x70 = null;
        [FieldAttr(120)] public string? _String_0x78 = null;
        [FieldAttr(128)] public string? _String_0x80 = null;
        [FieldAttr(136)] public igHandleMetaField _Rumble_Data = new();
        [FieldAttr(144)] public int _Int;
        [FieldAttr(152)] public igHandleMetaField _Sound = new();
        [FieldAttr(160)] public float _Float_0xa0;
        [FieldAttr(168)] public igHandleMetaField _Waypoint_List = new();
        [FieldAttr(176)] public string? _String_0xb0 = null;
        [FieldAttr(184)] public string? _String_0xb8 = null;
        [FieldAttr(192)] public float _Float_0xc0;
        [FieldAttr(196)] public float _Float_0xc4;
        [FieldAttr(200)] public igHandleMetaField _Game_Bool_Variable_0xc8 = new();
        [FieldAttr(208)] public igHandleMetaField _Game_Bool_Variable_0xd0 = new();
        [FieldAttr(216)] public string? _String_0xd8 = null;
        [FieldAttr(224)] public string? _String_0xe0 = null;
    }
}
