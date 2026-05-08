namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class common_sprint_prototypeData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _SpeedBoost_CharacterAttributeList = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Sprint_Cooldown_Duration;
        [FieldAttr(nst: 52, ctr: 44)] public float _Sprint_Duration;
        [FieldAttr(nst: 56, ctr: 48)] public string? _SprintStart = null;
        [FieldAttr(nst: 64, ctr: 56)] public string? _SprintEnd = null;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Vfx_EffectVariable_id_cmpjcsln_variable = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Vfx_EffectVariable_id_sbxhg4f9_variable = new();
    }
}
