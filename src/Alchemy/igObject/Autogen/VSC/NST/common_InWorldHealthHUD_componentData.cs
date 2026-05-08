namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class common_InWorldHealthHUD_componentData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _DisplayOnProximity;
        [FieldAttr(nst: 44, ctr: 36)] public float _HealthHudVisibilityDuration;
        [FieldAttr(nst: 48, ctr: 40)] public float _ProximityCheckUpdateFrequency;
        [FieldAttr(nst: 52, ctr: 44)] public float _ProximityRange;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _ProximityChecksEnabled = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _GuiProjectVariable_id_sc7bbthz_variable = new();
        [FieldAttr(nst: 72, ctr: 64)] public igVec3fMetaField _WorldspaceOffset = new();
    }
}
