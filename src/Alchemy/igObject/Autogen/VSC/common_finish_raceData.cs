namespace Alchemy
{
    // VSC object extracted from: common_finish_race.igz

    [ObjectAttr(88, metaType: typeof(CVscComponentData))]
    public class common_finish_raceData : CVscComponentData
    {
        [FieldAttr(40)] public bool _Bool;
        [FieldAttr(48)] public igHandleMetaField _Entity = new();
        [FieldAttr(56)] public int _Int_0x38;
        [FieldAttr(64)] public igHandleMetaField _Zone_Info = new();
        [FieldAttr(72)] public int _Int_0x48;
        [FieldAttr(76)] public float _Float;
        [FieldAttr(80)] public EZoneCollectibleType _E_Zone_Collectible_Type;
    }
}
