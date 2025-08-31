namespace Alchemy
{
    // VSC object extracted from: common_InWorldHealthHUD_component_c.igz

    [ObjectAttr(88, metaType: typeof(CVscComponentData))]
    public class common_InWorldHealthHUD_componentData : CVscComponentData
    {
        [FieldAttr(40)] public bool _DisplayOnProximity;
        [FieldAttr(44)] public float _HealthHudVisibilityDuration;
        [FieldAttr(48)] public float _ProximityCheckUpdateFrequency;
        [FieldAttr(52)] public float _ProximityRange;
        [FieldAttr(56)] public igHandleMetaField _ProximityChecksEnabled = new();
        [FieldAttr(64)] public igHandleMetaField _GuiProjectVariable_id_sc7bbthz_variable = new();
        [FieldAttr(72)] public igVec3fMetaField _WorldspaceOffset = new();
    }
}
