namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class common_finish_raceData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _Bool;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 56, ctr: 48)] public int _Int_0x38;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Zone_Info = new();
        [FieldAttr(nst: 72, ctr: 64)] public int _Int_0x48;
        [FieldAttr(nst: 76, ctr: 68)] public float _Float;
        [FieldAttr(nst: 80, ctr: 72)] public EZoneCollectibleType _E_Zone_Collectible_Type;
    }
}
