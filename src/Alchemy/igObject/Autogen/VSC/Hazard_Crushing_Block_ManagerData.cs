namespace Alchemy
{
    // VSC object extracted from: Hazard_Crushing_Block_Manager_c.igz

    [ObjectAttr(144, metaType: typeof(CVscComponentData))]
    public class Hazard_Crushing_Block_ManagerData : CVscComponentData
    {
        [FieldAttr(40)] public bool _CameraShake;
        [FieldAttr(44)] public float _ShakeMagnitude;
        [FieldAttr(48)] public float _ShakeDuration;
        [FieldAttr(52)] public float _ShakeSpeed;
        [FieldAttr(56)] public string? _DeathState = null;
        [FieldAttr(64)] public igHandleMetaField _Entity_0x40 = new();
        [FieldAttr(72)] public igHandleMetaField _Entity_0x48 = new();
        [FieldAttr(80)] public float _Float_0x50;
        [FieldAttr(84)] public bool _Bool_0x54;
        [FieldAttr(88)] public float _Float_0x58;
        [FieldAttr(96)] public igHandleMetaField _Entity_0x60 = new();
        [FieldAttr(104)] public float _Float_0x68;
        [FieldAttr(112)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(120)] public igHandleMetaField _Sound = new();
        [FieldAttr(128)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(136)] public bool _Bool_0x88;
    }
}
