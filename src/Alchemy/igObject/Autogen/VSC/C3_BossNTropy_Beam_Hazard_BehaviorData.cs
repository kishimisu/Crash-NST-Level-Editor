namespace Alchemy
{
    // VSC object extracted from: C3_BossNTropy_Beam_Hazard_Behavior.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class C3_BossNTropy_Beam_Hazard_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Bolt_Point_0x28 = new();
        [FieldAttr(48)] public igHandleMetaField _Bolt_Point_0x30 = new();
        [FieldAttr(56)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(64)] public igHandleMetaField _Sound = new();
        [FieldAttr(72)] public float _Float;
    }
}
