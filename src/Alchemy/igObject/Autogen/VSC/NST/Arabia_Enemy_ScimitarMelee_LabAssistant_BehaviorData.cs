namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class Arabia_Enemy_ScimitarMelee_LabAssistant_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(nst: 52, ctr: 44)] public bool _Bool;
        [FieldAttr(nst: 56, ctr: 48)] public float _Enemy_Basic_BehaviorDatas002;
        [FieldAttr(nst: 60, ctr: 52)] public float _Float;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity = new();
    }
}
