namespace Alchemy
{
    // VSC object extracted from: common_Team_Faction_Material_Override_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class common_Team_Faction_Material_OverrideData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Faction2MaterialOverride = new();
        [FieldAttr(48)] public igHandleMetaField _Faction1MaterialOverride = new();
        [FieldAttr(56)] public igHandleMetaField _FxMaterial_Neutral = new();
    }
}
