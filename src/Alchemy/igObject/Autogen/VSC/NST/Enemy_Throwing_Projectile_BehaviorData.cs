namespace Alchemy
{
    [ObjectAttr(nst: 232, ctr: 224, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Throwing_Projectile_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Projectile_BoltPoint = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _SpawnData = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _ThrowLength;
        [FieldAttr(nst: 60, ctr: 52)] public float _ThrowPitch;
        [FieldAttr(nst: 64, ctr: 56)] public float _BeakerRange_0x40;
        [FieldAttr(nst: 68, ctr: 60)] public float _MixDuration;
        [FieldAttr(nst: 72, ctr: 64)] public float _PreThrowDelay;
        [FieldAttr(nst: 80, ctr: 72)] public string? _Throw = null;
        [FieldAttr(nst: 88, ctr: 80)] public float _Float_0x58;
        [FieldAttr(nst: 92, ctr: 84)] public float _BeakerRange_0x5c;
        [FieldAttr(nst: 96, ctr: 88)] public bool _Bool_0x60;
        [FieldAttr(nst: 104, ctr: 96)] public string? _String_0x68 = null;
        [FieldAttr(nst: 112, ctr: 104)] public string? _String_0x70 = null;
        [FieldAttr(nst: 120, ctr: 112)] public string? _String_0x78 = null;
        [FieldAttr(nst: 128, ctr: 120)] public string? _String_0x80 = null;
        [FieldAttr(nst: 136, ctr: 128)] public string? _String_0x88 = null;
        [FieldAttr(nst: 144, ctr: 136)] public string? _String_0x90 = null;
        [FieldAttr(nst: 152, ctr: 144)] public string? _String_0x98 = null;
        [FieldAttr(nst: 160, ctr: 152)] public float _Float_0xa0;
        [FieldAttr(nst: 164, ctr: 156)] public float _Float_0xa4;
        [FieldAttr(nst: 168, ctr: 160)] public float _Float_0xa8;
        [FieldAttr(nst: 172, ctr: 164)] public float _Float_0xac;
        [FieldAttr(nst: 176, ctr: 168)] public float _Float_0xb0;
        [FieldAttr(nst: 180, ctr: 172)] public float _Float_0xb4;
        [FieldAttr(nst: 184, ctr: 176)] public float _Float_0xb8;
        [FieldAttr(nst: 188, ctr: 180)] public float _Float_0xbc;
        [FieldAttr(nst: 192, ctr: 184)] public float _Float_0xc0;
        [FieldAttr(nst: 196, ctr: 188)] public bool _Bool_0xc4;
        [FieldAttr(nst: 197, ctr: 189)] public bool _Bool_0xc5;
        [FieldAttr(nst: 200, ctr: 192)] public float _Float_0xc8;
        [FieldAttr(nst: 208, ctr: 200)] public igHandleMetaField _Bolt_Point_0xd0 = new();
        [FieldAttr(nst: 216, ctr: 208)] public igHandleMetaField _Bolt_Point_0xd8 = new();
        [FieldAttr(nst: 224, ctr: 216)] public bool _Bool_0xe0;
        [FieldAttr(nst: 228, ctr: 220)] public float _FloatVariable_id_eu66ik90_variable;
    }
}
