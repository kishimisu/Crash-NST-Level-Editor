namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class Jungle_Enemy_HavokBehavior_FlyTrap_Spitter_SpawnedMineData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float_0x28;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float_0x2c;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Damage_Data = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _ThrowLength;
        [FieldAttr(nst: 68, ctr: 60)] public float _ThrowPitch;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 80, ctr: 72)] public bool _Bool_0x50;
        [FieldAttr(nst: 88, ctr: 80)] public string? _String = null;
        [FieldAttr(nst: 96, ctr: 88)] public bool _Bool_0x60;
        [FieldAttr(nst: 97, ctr: 89)] public bool _Bool_0x61;
    }
}
