namespace Alchemy
{
    [ObjectAttr(nst: 232, ctr: 224, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Shield_Push_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _FlippedTimer;
        [FieldAttr(nst: 44, ctr: 36)] public float _LaunchHeight;
        [FieldAttr(nst: 48, ctr: 40)] public float _LaunchSpeed;
        [FieldAttr(nst: 52, ctr: 44)] public float _PushOffset;
        [FieldAttr(nst: 56, ctr: 48)] public string? _ShieldDown = null;
        [FieldAttr(nst: 64, ctr: 56)] public string? _WalkBack = null;
        [FieldAttr(nst: 72, ctr: 64)] public string? _TurnBack = null;
        [FieldAttr(nst: 80, ctr: 72)] public string? _WalkForward = null;
        [FieldAttr(nst: 88, ctr: 80)] public string? _TurnForward = null;
        [FieldAttr(nst: 96, ctr: 88)] public string? _ShieldUpBounce_0x60 = null;
        [FieldAttr(nst: 104, ctr: 96)] public string? _ShieldUp = null;
        [FieldAttr(nst: 112, ctr: 104)] public string? _ShieldUpBounce_0x70 = null;
        [FieldAttr(nst: 120, ctr: 112)] public string? _String_0x78 = null;
        [FieldAttr(nst: 128, ctr: 120)] public string? _String_0x80 = null;
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Rumble_Data = new();
        [FieldAttr(nst: 144, ctr: 136)] public int _Int;
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 160, ctr: 152)] public float _Float_0xa0;
        [FieldAttr(nst: 168, ctr: 160)] public igHandleMetaField _Waypoint_List = new();
        [FieldAttr(nst: 176, ctr: 168)] public string? _String_0xb0 = null;
        [FieldAttr(nst: 184, ctr: 176)] public string? _String_0xb8 = null;
        [FieldAttr(nst: 192, ctr: 184)] public float _Float_0xc0;
        [FieldAttr(nst: 196, ctr: 188)] public float _Float_0xc4;
        [FieldAttr(nst: 200, ctr: 192)] public igHandleMetaField _Game_Bool_Variable_0xc8 = new();
        [FieldAttr(nst: 208, ctr: 200)] public igHandleMetaField _Game_Bool_Variable_0xd0 = new();
        [FieldAttr(nst: 216, ctr: 208)] public string? _String_0xd8 = null;
        [FieldAttr(nst: 224, ctr: 216)] public string? _String_0xe0 = null;
    }
}
