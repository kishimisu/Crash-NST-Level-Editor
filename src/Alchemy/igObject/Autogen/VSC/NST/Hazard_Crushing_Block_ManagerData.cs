namespace Alchemy
{
    [ObjectAttr(nst: 144, ctr: 136, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_Crushing_Block_ManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _CameraShake;
        [FieldAttr(nst: 44, ctr: 36)] public float _ShakeMagnitude;
        [FieldAttr(nst: 48, ctr: 40)] public float _ShakeDuration;
        [FieldAttr(nst: 52, ctr: 44)] public float _ShakeSpeed;
        [FieldAttr(nst: 56, ctr: 48)] public string? _DeathState = null;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Entity_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public float _Float_0x50;
        [FieldAttr(nst: 84, ctr: 76)] public bool _Bool_0x54;
        [FieldAttr(nst: 88, ctr: 80)] public float _Float_0x58;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Entity_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public float _Float_0x68;
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(nst: 136, ctr: 128)] public bool _Bool_0x88;
    }
}
