namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class Prehistoric_Enemy_Bandifish_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _Idle_0x28 = null;
        [FieldAttr(nst: 48, ctr: 40)] public string? _Idle_0x30 = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _SplineAttachBehaviorVariable_id_dmv9oeuf_variable = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _SplineRotationMoverVariable_id_adexbjvm_variable = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _SplineVelocityMover = new();
        [FieldAttr(nst: 80, ctr: 72)] public float _Float;
        [FieldAttr(nst: 88, ctr: 80)] public string? _String = null;
    }
}
